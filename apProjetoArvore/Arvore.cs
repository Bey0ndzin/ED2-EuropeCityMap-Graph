using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apProjetoArvore
{
    public class Arvore<Dado> : IArvore<Dado> where Dado : IComparable<Dado>, IRegistro<Dado>, new()
    {
        NoArvore<Dado> atual, antecessor, raiz;
        Situacao situacao = Situacao.navegando;
        public Arvore()
        {
            raiz = atual = antecessor = null;
        }

        public NoArvore<Dado> Raiz { get { return raiz; } set { raiz = value; } }
        public NoArvore<Dado> Atual { get { return atual; } set { atual = value; } }
        public NoArvore<Dado> Antecessor { get { return antecessor; } set { antecessor = value; } }
        public Situacao SituacaoAtual { get => situacao; set => situacao = value; }
        public bool Existe(Dado procurado)
        {
            antecessor = null;
            atual = raiz;
            while (atual != null)
            {
                if (atual.Info.CompareTo(procurado) == 0)
                    return true;
                else
                {
                    antecessor = atual;
                    if (procurado.CompareTo(atual.Info) < 0)
                        atual = atual.Esq;
                    else
                        atual = atual.Dir;
                }
            }
            return false;
        }
        public bool Existe(NoArvore<Cidade> atual, double porcX, double porcY, double raio)
        {
            if (atual != null)
            {
                double distX = Math.Abs(porcX - atual.Info.X);
                double distY = Math.Abs(porcY - atual.Info.Y);
                if (distX <= raio
                    && distY <= raio)
                {
                    return true;
                }
                Existe(atual.Esq, porcX, porcY, raio);
                Existe(atual.Dir, porcX, porcY, raio);
            }
            return false;
        }
        public void Inserir(Dado novosDados)
        {
            bool achou = false, fim = false;
            NoArvore<Dado> novoNo = new NoArvore<Dado>(novosDados);
            if (raiz == null)
                raiz = novoNo;
            else
            {
                antecessor = null;
                atual = raiz;
                while (!achou && !fim)
                {
                    antecessor = atual;
                    if (novosDados.CompareTo(atual.Info) < 0)
                    {
                        atual = atual.Esq;
                        if (atual == null)
                        {
                            antecessor.Esq = novoNo;
                            fim = true;
                        }
                    }
                    if (novosDados.CompareTo(atual.Info) > 0)
                    {
                        atual = atual.Dir;
                        if (atual == null)
                        {
                            antecessor.Dir = novoNo;
                            fim = true;
                        }
                    }
                    else
                    {
                        achou = true;
                    }
                }
            }
        }
        public void IncluirNovoRegistro(Dado novoRegistro)
        {
            if (Existe(novoRegistro))
                throw new Exception("Registro com chave repetida!");
            else
            {
                // o novoRegistro tem uma chave inexistente, então criamos um
                // novo nó para armazená-lo e depois ligamos esse nó na árvore
                var novoNo = new NoArvore<Dado>(novoRegistro);
                // se a árvore está vazia, a raiz passará a apontar esse novo nó
                if (raiz == null)
                    raiz = novoNo;
                else
                // nesse caso, antecessor aponta o pai do novo registro e
                // verificamos em qual ramo o novo nó será ligado
                if (novoRegistro.CompareTo(antecessor.Info) < 0) // novo é menor que antecessor 
                    antecessor.Esq = novoNo; // vamos para a esquerda
                else
                    antecessor.Dir = novoNo; // ou vamos para a direita
            }
        }
        public void DesenharArvore(int x, int y, Graphics g)
        {
            DesenharArvore(true, raiz, x, y, 60, 0.5, 400, g);
        }
        public void DesenharArvore(bool primeiraVez, NoArvore<Dado> raiz,
                            int x, int y, double angulo, double incremento,
                               double comprimento, Graphics g)
        {
            int xf, yf;
            if (raiz != null)
            {
                Pen caneta = new Pen(Color.Green);
                xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
                yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento/2);
                if (primeiraVez)
                {
                    yf = 25;
                    xf = x;
                }
                g.DrawLine(caneta, x, y, xf, yf);
                DesenharArvore(false, raiz.Esq, xf, yf, Math.PI / 2 + incremento,
                incremento * 0.6, comprimento*0.8, g);
                DesenharArvore(false, raiz.Dir, xf, yf, Math.PI / 2 - incremento,
                incremento * 0.6, comprimento*0.8, g);
                SolidBrush preenchimento = new SolidBrush(Color.Blue);
                g.FillEllipse(preenchimento, xf - 25, yf - 15, 64, 30);
                g.DrawString(Convert.ToString(raiz.Info.ToString().Substring(0, 15)), new Font("Comic Sans", 10),
                new SolidBrush(Color.Yellow), xf - 20, yf - 7);
            }
        }

        public void DesenharMapa(bool primeiraVez, int larguraMapa, int alturaMapa, Pen caneta, NoArvore<Cidade> raiz,
                            int espessura, Graphics g)
        {
            if (raiz != null)
            {
                float x = (larguraMapa * float.Parse(raiz.Info.X.ToString())) - espessura/2;
                float y = (alturaMapa * float.Parse(raiz.Info.Y.ToString())) - espessura/2;
                g.DrawEllipse(caneta, x, y, espessura, espessura);
                DesenharMapa(false, larguraMapa, alturaMapa, caneta, raiz.Esq, espessura, g);
                DesenharMapa(false, larguraMapa, alturaMapa, caneta, raiz.Dir, espessura, g);
            }
        }
        public void LerArquivoDeRegistros(string nomeArquivo)
        {
            raiz = null;
            Dado dado = new Dado();
            var origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
            var arquivo = new BinaryReader(origem);
            int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
            Particionar(1, posicaoFinal, ref raiz);
            origem.Close();
            void Particionar(long inicio, long fim, ref NoArvore<Dado> atual)
            {
                if (inicio <= fim)
                {
                    long meio = (inicio + fim) / 2;
                    dado = new Dado();
                    dado.LerRegistro(arquivo, meio); // 
                    atual = new NoArvore<Dado>(dado);
                    var novoEsq = atual.Esq;
                    Particionar(inicio, meio - 1, ref novoEsq); // Particiona à esquerda 
                    atual.Esq = novoEsq;
                    var novoDir = atual.Dir;
                    Particionar(meio + 1, fim, ref novoDir); // Particiona à direita 
                    atual.Dir = novoDir;
                }
            }
        }
        public void GravarArquivoDeRegistros(string nomeArquivo)
        {
            var destino = new FileStream(nomeArquivo, FileMode.Create);
            var arquivo = new BinaryWriter(destino);
            GravarInOrdem(raiz);
            arquivo.Close();
            void GravarInOrdem(NoArvore<Dado> r)
            {
                if (r != null)
                {
                    GravarInOrdem(r.Esq);
                    r.Info.GravarRegistro(arquivo);
                    GravarInOrdem(r.Dir);
                }
            }
        }
        public void ExibirDados(ListBox lista, NoArvore<Dado> atual)  // lista os dados armazenados na lista no listbox passado como parâmetro
        {
            if (atual != null)
            {
                lista.Items.Add(atual.Info.ToString());
                ExibirDados(lista, atual.Esq);
                ExibirDados(lista, atual.Dir);
            }
        }

        public void PosicionarNaRaiz()
        {
            antecessor = null;
            atual = raiz;
        }
        public Dado DadoAtual()
        {
            return atual.Info;
        }

        public bool ApagarNo(Dado registroARemover)
        {
            atual = raiz;
            antecessor = null;
            bool ehFilhoEsquerdo = true;
            while (atual.Info.CompareTo(registroARemover) != 0) // enqto não acha a chave a remover
            {
                antecessor = atual;
                if (atual.Info.CompareTo(registroARemover) > 0)
                {
                    ehFilhoEsquerdo = true;
                    atual = atual.Esq;
                }
                else
                {
                    ehFilhoEsquerdo = false;
                    atual = atual.Dir;
                }
                if (atual == null) // neste caso, a chave a remover não existe e não pode
                    return false; // ser excluída, dai retornamos falso indicando isso
            } // fim do while
              // se fluxo de execução vem para este ponto, a chave a remover foi encontrada
              // e o ponteiro atual indica o nó que contém essa chave
            if ((atual.Esq == null) && (atual.Dir == null)) // é folha, nó com 0 filhos
            {
                if (atual == raiz)
                    raiz = null; // exclui a raiz e a árvore fica vazia
                else
                if (ehFilhoEsquerdo) // se for filho esquerdo, o antecessor deixará
                    antecessor.Esq = null; // de ter um descendente esquerdo
                else // se for filho direito, o antecessor deixará de
                    antecessor.Dir = null; // apontar para esse filho
                atual = antecessor; // feito para atual apontar um nó válido ao sairmos do método
            }
            else // verificará as duas outras possibilidades, exclusão de nó com 1 ou 2 filhos
            if (atual.Dir == null) // neste caso, só tem o filho esquerdo
            {
                if (atual == raiz)
                    raiz = atual.Esq;
                else
                if (ehFilhoEsquerdo)
                    antecessor.Esq = atual.Esq;
                else
                    antecessor.Dir = atual.Esq;
                atual = antecessor;
            }
            else
            if (atual.Esq == null) // neste caso, só tem o filho direito
            {
                if (atual == raiz)
                    raiz = atual.Dir;
                else
                if (ehFilhoEsquerdo)
                    antecessor.Esq = atual.Dir;
                else
                    antecessor.Dir = atual.Dir;
                atual = antecessor;
            }
            else // tem os dois descendentes
            {
                NoArvore<Dado> menorDosMaiores = MenorDosMaioresDescendentes(atual);
                atual.Info = menorDosMaiores.Info;
                menorDosMaiores = null; // para liberar o nó trocado da memória
            }
            return true;
        }
        public NoArvore<Dado> MenorDosMaioresDescendentes(NoArvore<Dado> noAExcluir)
        {
            NoArvore<Dado> paiDoSucessor = noAExcluir;
            NoArvore<Dado> sucessor = noAExcluir;
            NoArvore<Dado> atual = noAExcluir.Dir; // vai ao ramo direito do nó a ser excluído,
                                                   // pois este ramo contém os descendentes que
                                                   // são maiores que o nó a ser excluído
            while (atual != null)
            {
                if (atual.Esq != null)
                    paiDoSucessor = atual;
                sucessor = atual;
                atual = atual.Esq;
            }
            if (sucessor != noAExcluir.Dir)
            {
                paiDoSucessor.Esq = sucessor.Dir;
                sucessor.Dir = noAExcluir.Dir;
            }
            return sucessor;
        }
        public List<Cidade> ObterListaDeCidades()
        {
            List<Cidade> cidades = new List<Cidade>();
            return cidades;
        }

    }
}

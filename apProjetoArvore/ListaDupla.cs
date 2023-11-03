using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class ListaDupla<Dado> : IDados<Dado>, IEnumerable<Dado>
                where Dado : IComparable<Dado>, IRegistro<Dado>, new()
{
    NoDuplo<Dado> primeiro, ultimo, atual;
    int quantosNos;
    Situacao situacao = Situacao.navegando;

    public ListaDupla()
    {
        primeiro = ultimo = atual = null;
        quantosNos = 0; 
    }

    public Situacao SituacaoAtual { get => situacao; set => situacao = value; }
    public int PosicaoAtual { 
        get 
        {
            int pos = 0;
            Dado dado = new Dado();
            dado = DadoAtual();
            PosicionarNoPrimeiro();
            while(atual != null)
            {
                if(atual.Info.CompareTo(dado) == 0)
                {
                    break;
                }
                AvancarPosicao();
                pos++;
            }
            return pos;
        }
        set
        {
            for(int i = 0; i < value; i++)
            {
                AvancarPosicao();
            }
        } 
    }
    public bool EstaNoInicio => atual == primeiro;
    public bool EstaNoFim => atual == ultimo;
    public bool EstaVazio => quantosNos <= 0;         // (bool) Verificar se está vazia
    public int Tamanho => quantosNos;

    public void LerDados(string nomeArquivo)    // fará a leitura e armazenamento dos dados do arquivo cujo nome é passado por parâmetro
    {
        StreamReader leitor = new StreamReader(nomeArquivo);
        while (!leitor.EndOfStream)
        {
            Dado novoDado = new Dado();
            //novoDado.LerRegistro(leitor);
            IncluirAposFim(novoDado);
        }
        leitor.Close();
    }
    public void GravarDados(string nomeArquivo)  // gravará sequencialmente, no arquivo cujo nome é passado por parâmetro, os dados armazenados na lista
    {
        StreamWriter gravador = new StreamWriter(nomeArquivo);
        gravador.Flush();
        PosicionarNoPrimeiro();
        while(!EstaNoFim)
        {
            gravador.WriteLine(DadoAtual().ToString());
            AvancarPosicao();
        }
        gravador.WriteLine(DadoAtual().ToString());
        gravador.Close();
    }
    public void PosicionarNoPrimeiro()        // Posicionar atual no primeiro nó para ser acessado
    {
        atual = primeiro;
    }
    public void RetrocederPosicao()        // Retroceder atual para o nó anterior para ser acessado
    {
        if (!EstaNoInicio)
            atual = atual.Anterior;
    }
    public void AvancarPosicao()
    {
        atual = atual.Prox;
    }
    public void PosicionarNoUltimo()        // posicionar atual no último nó para ser acessado
    {
        atual = ultimo;
    }
    public void PosicionarEm(int posicaoDesejada)
    {
        PosicionarNoPrimeiro();
        for(int i = 0; i < posicaoDesejada; i++)
        {
            AvancarPosicao();
        }
    }

    // (bool) Pesquisar Dado procurado em ordem crescente; a pesquisa
    // posicionará o ponteiro atual no nó procurado quando este
    // or encontrado ou, se não achar, no nó seguinte a local
    // onde deveria estar o nó procurado
    public bool Existe(Dado procurado, out int ondeEsta)
    {
        ondeEsta = 0;
        atual = null;
        if (!EstaVazio)
        {
            if (procurado.CompareTo(primeiro.Info) < 0)
                return false;
            else if (procurado.CompareTo(ultimo.Info) > 0)
            {
                return false;
            }
            atual = primeiro;
            bool achou = false;
            bool fim = false;
            while (!achou && !fim)
            {
                if (atual == null)
                    fim = true;
                else if (atual.Info.CompareTo(procurado) > 0)
                    fim = true;
                else if (atual.Info.CompareTo(procurado) == 0)
                    achou = true;
                else
                {
                    atual = atual.Prox;
                    ondeEsta++;
                }
            }
            if (!achou)
                ondeEsta = -1;
            return achou;
        }
        return false;
    }
    public bool Excluir(Dado dadoAExcluir)
    {
        bool excluiu = false;
        Existe(dadoAExcluir, out int pos);
        if (pos <= -1)
            return excluiu;
        else
        {
            PosicionarEm(pos);
            if (!EstaNoInicio && !EstaNoFim)
            {
                atual.Anterior.Prox = atual.Prox;
                atual.Prox.Anterior = atual.Anterior;
                PosicionarEm(pos + 1);
            }
            else if (EstaNoInicio)
            {
                primeiro = atual.Prox;
                atual.Prox.Anterior = null;
                PosicionarNoPrimeiro();
            }
            else if (EstaNoFim)
            {
                ultimo = atual.Anterior;
                atual.Anterior.Prox = null;
                PosicionarNoUltimo();
            }
            excluiu = true;
        }
        return excluiu;
    }
    public bool IncluirNoInicio(Dado novoValor)
    {
        var novoNo = new NoDuplo<Dado>(novoValor);
        if (EstaVazio)
            ultimo = novoNo;

        novoNo.Anterior = null;
        novoNo.Prox = primeiro;
        primeiro.Anterior = novoNo;
        primeiro = novoNo;
        quantosNos++;

        return true;
    }
    public bool IncluirAposFim(Dado novoValor)
    {
        var novoNo = new NoDuplo<Dado>(novoValor);
        if (EstaVazio)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        novoNo.Prox = null;
        novoNo.Anterior = ultimo;
        ultimo = novoNo;
        quantosNos++;

        return true;
    }
    public bool Incluir(Dado novoValor)         // (bool) Inserir nó com Dado em ordem crescente
    {
        if (EstaVazio)
            IncluirNoInicio(novoValor);

        else if (novoValor.CompareTo(primeiro.Info) < 0)
            IncluirNoInicio(novoValor);

        else if (novoValor.CompareTo(ultimo.Info) > 0)
            IncluirAposFim(novoValor);

        else if (!Existe(novoValor, out int pos))
        {
            Incluir(novoValor, PosicaoAtual-1);
        }
        return true;
    }
    public bool Incluir(Dado novoValor, int posicaoDeInclusao)  // inclui novo nó na posição indicada da lista
    {
        var novo = new NoDuplo<Dado>(novoValor);
        PosicionarNoPrimeiro();
        for(int i = 0; i < posicaoDeInclusao; i++)
        {
            AvancarPosicao();
        }
        novo.Prox = atual.Prox;
        atual.Prox.Anterior = novo;
        novo.Anterior = atual;
        atual.Prox = novo;
        return true;
    }
    public Dado this[int indice]
    {
        get
        {
            if (indice < 0 || indice > quantosNos) throw new IndexOutOfRangeException();
            atual = primeiro;
            int idAtual = 0;
            while(atual != null)
            {
                atual = atual.Prox;
                if(idAtual < indice)
                    idAtual++;
            }
            return atual.Info;
        }
        set {
                if (indice < 0 || indice > quantosNos) throw new IndexOutOfRangeException();
                atual = primeiro;
                int idAtual = 0;
                while (atual != null)
                {
                    atual = atual.Prox;
                    if (idAtual < indice)
                        idAtual++;
                }
                atual.Info = value;
            }
        }
    public Dado DadoAtual()  // retorna o dado atualmente visitado
    {
        return atual.Info;
    }
    public void ExibirDados()   // lista os dados armazenados na lista em modo console
    {
        atual = primeiro;
        while(atual != null)
        {
            Console.WriteLine(atual.Info.ToString());
            atual = atual.Prox;
        }
    }
    public void ExibirDados(ListBox lista)  // lista os dados armazenados na lista no listbox passado como parâmetro
    {
        lista.Items.Clear();
        atual = primeiro;
        while (atual != null)
        {
            lista.Items.Add(atual.Info.ToString());
            atual = atual.Prox;
        }
    }
    public void ExibirDados(ComboBox lista) // lista os dados armazenados na lista no combobox passado como parâmetro
    {
        lista.Items.Clear();
        atual = primeiro;
        while(atual != null)
        {
            lista.Items.Add(atual.Info.ToString());
            atual = atual.Prox;
        }
    }
    public void ExibirDados(TextBox lista)
    {
        atual = primeiro;
        while (atual != null)
        {
            lista.Text = atual.Info.ToString();
            atual = atual.Prox;
        }
    }
    public void Ordenar()
    {
        throw new NotImplementedException();
    }
    public bool PodePercorrer()
    {
        return atual != null;
    }
    public IEnumerator<Dado> GetEnumerator()
    {
        var current = primeiro;
        while (current != null)
        {
            yield return current.Info;
            current = current.Prox;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
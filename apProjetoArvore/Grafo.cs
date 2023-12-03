using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apProjetoArvore
{
    class Grafo<Dado> where Dado : IComparable<Dado>, IRegistro<Dado>, new()
    {
        private const int NUM_VERTICES = 999;
        private Vertice<Dado>[] vertices;
        private int[,] adjMatrix;
        int numVerts;
        DataGridView dgv;
        Situacao situacao = Situacao.navegando;

        public Grafo(DataGridView dgv)
        {
            this.dgv = dgv;
            vertices = new Vertice<Dado>[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            for (int j = 0; j < NUM_VERTICES; j++) // zera toda a matriz
                for (int k = 0; k < NUM_VERTICES; k++)
                    adjMatrix[j, k] = 0;
        }

        public Situacao SituacaoAtual { get => situacao; set => situacao = value; }
        public int NumVerts { get { return numVerts; } }
        public int[,] AdjMatrix { get { return adjMatrix; } }

        public void LerArquivoDeRegistros(string nomeArquivo)
        {
            Dado dado = new Dado();
            var origem = new FileStream(nomeArquivo, FileMode.OpenOrCreate);
            var arquivo = new BinaryReader(origem);
            int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
            int i = 1;
            while(i < posicaoFinal)
            {
                dado = new Dado();
                dado.LerRegistro(arquivo, i);
                NovoVertice(dado);
                i++;
            }
            origem.Close();
        }
        public void NovoVertice(Dado label)
        {
            vertices[numVerts] = new Vertice<Dado>(label);
            numVerts++;
            if (dgv != null) // se foi passado como parâmetro um dataGridView para exibição
            { // se realiza o seu ajuste para a quantidade de vértices
                dgv.RowCount = numVerts + 1;
                dgv.ColumnCount = numVerts + 1;
                dgv.Columns[numVerts].Width = 45;
            }
        }
        public void NovaAresta(int start, int eend)
        {
            adjMatrix[start, eend] = 1; // adjMatrix[eend, start] = 1; ISSO GERA CICLOS!!!
        }
        public void ExibirVertice(int v)
        {
            Console.Write(vertices[v].rotulo + " ");
        }
        public void ExibirVertice(int v, TextBox txt)
        {
            txt.Text += vertices[v].rotulo + " ";
        }
        public int SemSucessores() // encontra e retorna a linha de um vértice sem sucessores
        {
            bool temAresta;
            for (int linha = 0; linha < numVerts; linha++)
            {
                temAresta = false;
                for (int col = 0; col < numVerts; col++)
                    if (adjMatrix[linha, col] > 0)
                    {
                        temAresta = true;
                        break;
                    }
                if (!temAresta)
                    return linha;
            }
            return -1;
        }

        public void RemoverVertice(int vert)
        {
            /*if (dgv != null)
            {
                MessageBox.Show($"Matriz de Adjacências antes de remover vértice {vert}");
                ExibirAdjacencias();
            }*/
            if (vert != numVerts - 1)
            {
                for (int j = vert; j < numVerts - 1; j++)// remove vértice do vetor
                    vertices[j] = vertices[j + 1];
                // remove vértice da matriz
                for (int row = vert; row < numVerts; row++)
                    MoverLinhas(row, numVerts - 1);
                for (int col = vert; col < numVerts; col++)
                    MoverColunas(col, numVerts - 1);
            }

            numVerts--;
            /*if (dgv != null)
            {
                MessageBox.Show($"Matriz de Adjacências após remover vértice {vert}");
                ExibirAdjacencias();
                MessageBox.Show("Retornando à ordenação");
            }*/
        }

        private void MoverLinhas(int row, int length)
        {
            if (row != numVerts - 1)
                for (int col = 0; col < length; col++)
                    adjMatrix[row, col] = adjMatrix[row + 1, col]; // desloca para excluir
        }
        private void MoverColunas(int col, int length)
        {
            if (col != numVerts - 1)
                for (int row = 0; row < length; row++)
                    adjMatrix[row, col] = adjMatrix[row, col + 1]; // desloca para excluir
        }
        public void ExibirAdjacencias()
        {
            dgv.RowCount = numVerts + 1;
            dgv.ColumnCount = numVerts + 1;
            for (int j = 0; j < numVerts; j++)
            {
                dgv.Rows[j + 1].Cells[0].Value = vertices[j].rotulo;
                dgv.Rows[0].Cells[j + 1].Value = vertices[j].rotulo;
                for (int k = 0; k < numVerts; k++)
                    dgv.Rows[j + 1].Cells[k + 1].Value = Convert.ToString(adjMatrix[j, k]);
            }
        }

        public String OrdenacaoTopologica()
        {
            Stack<Dado> gPilha = new Stack<Dado>(); //guarda a sequência de vértices
            int origVerts = numVerts;
            while (numVerts > 0)
            {
                int currVertex = SemSucessores();
                if (currVertex == -1)
                    return "Erro: grafo possui ciclos.";
                gPilha.Push(vertices[currVertex].rotulo); // empilha vértice
                RemoverVertice(currVertex);
            }
            String resultado = "Sequência da Ordenação Topológica: ";
            while (gPilha.Count > 0)
                resultado += gPilha.Pop() + " "; // desempilha para exibir
            return resultado;
        }

        public int Existe(Dado procurado)
        {
            for(int i = 0; i < numVerts; i++)
            {
                if (vertices[i].rotulo.CompareTo(procurado) == 0)
                    return i;
            }
            return -1;
        }

        public void ExibirDados(ListBox lista)  // lista os dados armazenados na lista no listbox passado como parâmetro
        {
            for(int i = 0; i < numVerts; i++)
            {
                if (vertices[i] == null)
                    break;

                lista.Items.Add(vertices[i].rotulo.ToString());
            }
        }
        public List<Dado> ObterListaDeCidades()
        {
            List<Dado> cidades = new List<Dado>();
            for(int i = 0; i < numVerts; i++)
            {
                cidades.Add(vertices[i].rotulo);
            }
            return cidades;
        }

        public Dado CidadeNaPosicao(int index)
        {
            if (index > numVerts)
                return new Dado();
            else if (index < 0)
                return new Dado();
            else
                return vertices[index].rotulo;
        }
    }
}

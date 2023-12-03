using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace apProjetoArvore
{
    public partial class Form1 : Form
    {
        Grafo<Cidade> cidades;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAlternar_Click(object sender, EventArgs e)
        {
            gbCidades.Visible = false;
            gbCaminhos.Visible = true;
        }

        private void btnCidades_Click(object sender, EventArgs e)
        {
            gbCaminhos.Visible = false;
            gbCidades.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cidades = new Grafo<Cidade>(dgvCaminhos);
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                cidades.LerArquivoDeRegistros(dlgAbrir.FileName);
                lsbCidades.Items.Clear();
                lsbCidades.Items.Add("Nome            X     Y");
                cidades.ExibirDados(lsbCidades);

                Cidade cid = cidades.CidadeNaPosicao(0);
                txtNome.Text = cid.Nome;
                txtCoordX.Text = cid.X.ToString();
                txtCoordY.Text = cid.Y.ToString();
                cidades.SituacaoAtual = Situacao.navegando;


                VerificarBotoes();
            }
            foreach (Cidade cidade in cidades.ObterListaDeCidades())
            {
                cbOrigem.Items.Add(cidade.Nome);
                cbDestino.Items.Add(cidade.Nome);

            }

            cbOrigem.SelectedItem = cidades.CidadeNaPosicao(0).Nome;
            cbDestino.SelectedItem = cidades.CidadeNaPosicao(cidades.NumVerts-1).Nome;

            if (dlgLigacao.ShowDialog() == DialogResult.OK)
            {
                dgvCaminhos.Columns.Clear();
                dgvCaminhos.Columns.Add("Origem", "Origem");
                dgvCaminhos.Columns.Add("Destino", "Destino");
                Ligacao dado = new Ligacao();
                var origem = new FileStream(dlgLigacao.FileName, FileMode.OpenOrCreate);
                var arquivo = new BinaryReader(origem);
                int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
                int inicio = 1;
                while (inicio <= posicaoFinal)
                {
                    dado = new Ligacao();
                    dado.LerRegistro(arquivo, inicio);
                    int cidOrig = cidades.Existe(new Cidade(dado.Origem, 0, 0));
                    int cidDest = cidades.Existe(new Cidade(dado.Destino, 0, 0));
                    if(cidOrig > -1 && cidDest > -1)
                        cidades.NovaAresta(cidOrig, cidDest);
                    inicio++;
                }
                origem.Close();
            }
            AtualizarDataGridViewCaminhos();
        }
        private void VerificarBotoes()
        {
            if(cidades.SituacaoAtual == Situacao.navegando)
            {
                btnProcurar.Enabled = true;
                btnNovo.Enabled = true;
                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = false;
            }
            else if(cidades.SituacaoAtual == Situacao.incluindo)
            {
                btnProcurar.Enabled = false;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else if(cidades.SituacaoAtual == Situacao.pesquisando)
            {

                btnProcurar.Enabled = true;
                btnNovo.Enabled = false;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                btnCancelar.Enabled = true;
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            cidades.SituacaoAtual = Situacao.pesquisando;
            try
            {
                MessageBox.Show("Clique em uma cidade no mapa", "Pesquisando");
                VerificarBotoes();
            }
            catch
            {
                MessageBox.Show("Não foi possível localizar cidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cidades.SituacaoAtual = Situacao.incluindo;
            VerificarBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cidades.SituacaoAtual = Situacao.navegando;
            VerificarBotoes();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cidades.SituacaoAtual = Situacao.editando;
            int pos = cidades.Existe(new Cidade(txtNome.Text, 0, 0));
            if (pos > -1)
            {
                try
                {
                    double X = double.Parse(txtCoordX.Text);
                    double Y = double.Parse(txtCoordY.Text);
                    cidades.CidadeNaPosicao(pos).X = X;
                    cidades.CidadeNaPosicao(pos).Y = Y;
                }catch(Exception ex) 
                {
                    MessageBox.Show("Digite valores válidos!", "Valores inválidos!");
                }
                pbMapa.Refresh();
                cidades.SituacaoAtual = Situacao.navegando;

                lsbCidades.Items.Clear();
                lsbCidades.Items.Add("Nome            X     Y");
                cidades.ExibirDados(lsbCidades);

                VerificarBotoes();
            }

        }

        private void pbMapa_Click(object sender, EventArgs e)
        {
            if (cidades.SituacaoAtual == Situacao.incluindo)
            {
                double largura = pbMapa.Bounds.Width;
                double altura = pbMapa.Bounds.Height;
                double xClicado = ((MouseEventArgs)e).X;
                double yClicado = ((MouseEventArgs)e).Y;

                double porcentagemX = Math.Round(xClicado / largura, 3);
                double porcentagemY = Math.Round(yClicado / altura, 3);

                try
                {
                    cidades.NovoVertice(new Cidade(txtNome.Text, porcentagemX, porcentagemY));
                    MessageBox.Show("Cidade incluida com exito", "Sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao incluir cidade: "+ex.Message, "Falha");
                }

                int pos = cidades.Existe(new Cidade(txtNome.Text, porcentagemX, porcentagemY));
                Cidade cid = cidades.CidadeNaPosicao(pos);
                txtNome.Text = cid.Nome;
                txtCoordX.Text = cid.X.ToString();
                txtCoordY.Text = cid.Y.ToString();

                lsbCidades.Items.Clear();
                lsbCidades.Items.Add("Nome            X     Y");
                cidades.ExibirDados(lsbCidades);

                pbMapa.Refresh();
            }
            if (cidades.SituacaoAtual == Situacao.pesquisando)
            {
                int esp = pbMapa.Bounds.Width / 150 / 2;
                double raio = double.Parse(esp.ToString()) / 100;

                double largura = pbMapa.Bounds.Width;
                double altura = pbMapa.Bounds.Height;
                double xClicado = ((MouseEventArgs)e).X;
                double yClicado = ((MouseEventArgs)e).Y;

                double porcentagemX = Math.Round(xClicado / largura, 3);
                double porcentagemY = Math.Round(yClicado / altura, 3);

                Cidade procurada = null;
                void ProcurarPorClick()
                {
                    for (int i = 0; i < cidades.NumVerts; i++)
                    {
                        double distX = Math.Abs(porcentagemX - cidades.CidadeNaPosicao(i).X);
                        double distY = Math.Abs(porcentagemY - cidades.CidadeNaPosicao(i).Y);
                        if (distX <= raio
                            && distY <= raio)
                        {
                            procurada = cidades.CidadeNaPosicao(i);
                        }
                    }
                }

                ProcurarPorClick();
                if (procurada == null)
                    MessageBox.Show("Não foi encontrado uma cidade nessa posição", "Falha ao encontrar cidade");
                else
                {
                    txtNome.Text = procurada.Nome;
                    txtCoordX.Text = procurada.X.ToString();
                    txtCoordY.Text = procurada.Y.ToString();
                    MessageBox.Show("Cidade encontrada", "Cidade encontrada");
                }
            }
            cidades.SituacaoAtual = Situacao.navegando;
            VerificarBotoes();
        }

        private void pbMapa_Paint(object sender, PaintEventArgs e)
        {
            int esp = pbMapa.Bounds.Width / 150;
            Graphics g = e.Graphics;
            Pen penCaminhos = new Pen(Color.Red, esp);
            Pen penCidade = new Pen(Color.Black, esp);
            int[,] caminhos = cidades.AdjMatrix;
            for (int i = 0; i < cidades.NumVerts; i++)
            {
                for(int j = i+1; j < cidades.NumVerts; j++)
                {
                    if (caminhos[i, j] == 1)
                    {
                        float x1 = (pbMapa.Bounds.Width * (float)cidades.CidadeNaPosicao(i).X) - esp / 2;
                        float y1 = (pbMapa.Bounds.Height * (float)cidades.CidadeNaPosicao(i).Y) - esp / 2;

                        float x2 = (pbMapa.Bounds.Width * (float)cidades.CidadeNaPosicao(j).X) - esp / 2;
                        float y2 = (pbMapa.Bounds.Height * (float)cidades.CidadeNaPosicao(j).Y) - esp / 2;

                        g.DrawLine(penCaminhos, x1, y1, x2, y2);
                    }
                }
            }
            for (int i = 0; i < cidades.NumVerts; i++)
            {
                float x = (pbMapa.Width * float.Parse(cidades.CidadeNaPosicao(i).X.ToString())) - esp / 2;
                float y = (pbMapa.Height * float.Parse(cidades.CidadeNaPosicao(i).Y.ToString())) - esp / 2;
                g.DrawEllipse(penCidade, x, y, esp, esp);
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = cidades.Existe(new Cidade(txtNome.Text, 0, 0));
                if(pos == -1)
                {
                    return;
                }
                cidades.RemoverVertice(pos);
                Cidade cid = cidades.CidadeNaPosicao(0);
                txtNome.Text = cid.Nome;
                txtCoordX.Text = cid.X.ToString();
                txtCoordY.Text = cid.Y.ToString();

                lsbCidades.Items.Clear();
                lsbCidades.Items.Add("Nome            X     Y");
                cidades.ExibirDados(lsbCidades);

                MessageBox.Show("Cidade excluida com exito", "Sucesso");

                pbMapa.Invalidate();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha ao excluir cidade: "+ex.Message, "Falha");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cidades.GravarArquivoDeRegistros(dlgAbrir.FileName);
        }   

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void lsbCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cidade = lsbCidades.SelectedItem.ToString();
            if(cidade.Substring(0, 15) != "Nome")
            {
                string nome = cidade.Substring(0, 15);
                string x = cidade.Substring(16, 6);
                string y = cidade.Substring(22, 5);
                txtNome.Text = nome;
                txtCoordX.Text = x;
                txtCoordY.Text = y;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            string origem = cbOrigem.SelectedItem.ToString();
            string destino = cbDestino.SelectedItem.ToString();
            //int distancia = (int)numDistancia.Value;
            //int tempo = (int)numTempo.Value;

            //Ligacao novoCaminho = new Ligacao(origem, destino, distancia, tempo);

            int posOrig = cidades.Existe(new Cidade(origem, 0, 0));
            int posDest = cidades.Existe(new Cidade(destino, 0, 0));
            if (posOrig > -1 && posDest > - 1)
            {
                cidades.NovaAresta(posOrig, posDest);

                AtualizarDataGridViewCaminhos();
            }
        }
        private void AtualizarDataGridViewCaminhos()
        {
            dgvCaminhos.Rows.Clear();

            int[,] caminhos = cidades.AdjMatrix;
            for (int i = 0; i < cidades.NumVerts; i++)
            {
                for (int j = i + 1; j < cidades.NumVerts; j++)
                {
                    if (caminhos[i, j] == 1)
                        dgvCaminhos.Rows.Add(cidades.CidadeNaPosicao(i).Nome, cidades.CidadeNaPosicao(j).Nome);
                }
            }
        }
    }



}

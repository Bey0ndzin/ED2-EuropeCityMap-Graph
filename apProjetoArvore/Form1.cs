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

namespace apProjetoArvore
{
    public partial class Form1 : Form
    {
        Arvore<Cidade> cidades;
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
            cidades = new Arvore<Cidade>();
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                cidades.LerArquivoDeRegistros(dlgAbrir.FileName);
                lsbCidades.Items.Clear();
                lsbCidades.Items.Add("Nome            X     Y");
                cidades.ExibirDados(lsbCidades, cidades.Raiz);

                cidades.PosicionarNaRaiz();
                Cidade cid = cidades.DadoAtual();
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

            if (dlgLigacao.ShowDialog() == DialogResult.OK)
            {
                
                dgvCaminhos.Columns.Add("Origem", "Origem");
                dgvCaminhos.Columns.Add("Destino", "Destino");
                dgvCaminhos.Columns.Add("Distancia", "Distancia");
                dgvCaminhos.Columns.Add("Tempo", "Tempo");
                Ligacao dado = new Ligacao();
                var origem = new FileStream(dlgLigacao.FileName, FileMode.OpenOrCreate);
                var arquivo = new BinaryReader(origem);
                int posicaoFinal = (int)origem.Length / dado.TamanhoRegistro - 1;
                int inicio = 1;
                while (inicio <= posicaoFinal)
                {
                    dado = new Ligacao();
                    dado.LerRegistro(arquivo, inicio);
                    cidades.Existe(new Cidade(dado.Origem, 0, 0));
                    if(cidades.Atual != null)
                    {
                        cidades.Atual.Caminhos.IncluirAposFim(dado);
                        foreach (var caminho in cidades.Atual.Caminhos)
                        {
                            dgvCaminhos.Rows.Add(caminho.Origem, caminho.Destino, caminho.Distancia, caminho.Tempo);
                        }
                    }
                    inicio++;
                }
                origem.Close();
                

            }
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
            if(cidades.Existe(new Cidade(txtNome.Text, 0, 0)))
            {
                try
                {
                    double X = double.Parse(txtCoordX.Text);
                    double Y = double.Parse(txtCoordY.Text);
                    cidades.DadoAtual().X = X;
                    cidades.DadoAtual().Y = Y;
                }catch(Exception ex) 
                {
                    MessageBox.Show("Digite valores válidos!", "Valores inválidos!");
                }
                pbMapa.Refresh();
                cidades.SituacaoAtual = Situacao.navegando;

                lsbCidades.Items.Clear();
                lsbCidades.Items.Add("Nome            X     Y");
                cidades.ExibirDados(lsbCidades, cidades.Raiz);

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
                    cidades.IncluirNovoRegistro(new Cidade(txtNome.Text, porcentagemX, porcentagemY));
                    MessageBox.Show("Cidade incluida com exito", "Sucesso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao incluir cidade: "+ex.Message, "Falha");
                }

                cidades.Existe(new Cidade(txtNome.Text, porcentagemX, porcentagemY));
                Cidade cid = cidades.DadoAtual();
                txtNome.Text = cid.Nome;
                txtCoordX.Text = cid.X.ToString();
                txtCoordY.Text = cid.Y.ToString();

                lsbCidades.Items.Clear();
                lsbCidades.Items.Add("Nome            X     Y");
                cidades.ExibirDados(lsbCidades, cidades.Raiz);

                pbMapa.Refresh();
            }
            if (cidades.SituacaoAtual == Situacao.pesquisando)
            {
                int esp = (pbMapa.Bounds.Width / 150)/2;
                double raio = double.Parse(esp.ToString()) / 100;

                double largura = pbMapa.Bounds.Width;
                double altura = pbMapa.Bounds.Height;
                double xClicado = ((MouseEventArgs)e).X;
                double yClicado = ((MouseEventArgs)e).Y;

                double porcentagemX = Math.Round(xClicado / largura, 3);
                double porcentagemY = Math.Round(yClicado / altura, 3);

                bool achou = cidades.Existe(cidades.Raiz, porcentagemX, porcentagemY, raio);
                if (!achou)
                    MessageBox.Show("Não foi encontrado uma cidade nessa posição", "Falha ao encontrar cidade");
                if (achou)
                {
                    Cidade cid = cidades.DadoAtual();
                    txtNome.Text = cid.Nome;
                    txtCoordX.Text = cid.X.ToString();
                    txtCoordY.Text = cid.Y.ToString();
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
            Pen pen = new Pen(Color.Red, esp);
            DesenharCaminhos(cidades.Raiz);
            void DesenharCaminhos(NoArvore<Cidade> raiz)
            {
                if (raiz != null)
                {
                    ListaDupla<Ligacao> caminhos = raiz.Caminhos;
                    caminhos.PosicionarNoPrimeiro();
                    while (caminhos.PodePercorrer())
                    {
                        cidades.Existe(new Cidade(caminhos.DadoAtual().Destino, 0, 0));
                        float x1 = (pbMapa.Bounds.Width * (float)raiz.Info.X) - esp/2;
                        float y1 = (pbMapa.Bounds.Height * (float)raiz.Info.Y) - esp / 2;
                        if(cidades.Atual != null)
                        {
                            float x2 = (pbMapa.Bounds.Width * (float)cidades.Atual.Info.X) - esp / 2;
                            float y2 = (pbMapa.Bounds.Height * (float)cidades.Atual.Info.Y) - esp / 2;
                            g.DrawLine(pen, x1, y1, x2, y2);
                        }
                        caminhos.AvancarPosicao();
                    }
                    DesenharCaminhos(raiz.Esq);
                    DesenharCaminhos(raiz.Dir);
                }
            }
            cidades.PosicionarNaRaiz();
            cidades.DesenharMapa(true, pbMapa.Bounds.Width, pbMapa.Bounds.Height, new Pen(Color.Black, esp), cidades.Raiz, esp, g);
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if(cidades.ApagarNo(new Cidade(txtNome.Text, 0, 0)))
                {
                    Cidade cid = cidades.DadoAtual();
                    txtNome.Text = cid.Nome;
                    txtCoordX.Text = cid.X.ToString();
                    txtCoordY.Text = cid.Y.ToString();

                    lsbCidades.Items.Clear();
                    lsbCidades.Items.Add("Nome            X     Y");
                    cidades.ExibirDados(lsbCidades, cidades.Raiz);

                    MessageBox.Show("Cidade excluida com exito", "Sucesso");

                    cidades.PosicionarNaRaiz();

                    pbMapa.Invalidate();
                }
                else
                {
                    MessageBox.Show("Falha ao excluir cidade", "Falha");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha ao excluir cidade: "+ex.Message, "Falha");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cidades.GravarArquivoDeRegistros(dlgAbrir.FileName);
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

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            pbArvore.CreateGraphics().Clear(Color.Black);
            pbArvore.Invalidate();
        }

        private void pbArvore_Paint(object sender, PaintEventArgs e)
        {
            cidades.DesenharArvore(pbArvore.Width / 2, 0, e.Graphics);
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
            int distancia = (int)numDistancia.Value;
            int tempo = (int)numTempo.Value;

            Ligacao novoCaminho = new Ligacao(origem, destino, distancia, tempo);

            if (cidades.Atual != null)
            {
                cidades.Atual.Caminhos.IncluirAposFim(novoCaminho);

                AtualizarDataGridViewCaminhos();
            }
        }
        private void AtualizarDataGridViewCaminhos()
        {
            dgvCaminhos.Rows.Clear();

            foreach (Ligacao caminho in cidades.Atual.Caminhos)
            {
                dgvCaminhos.Rows.Add(caminho.Origem, caminho.Destino, caminho.Distancia, caminho.Tempo);
            }
        }
    }



}

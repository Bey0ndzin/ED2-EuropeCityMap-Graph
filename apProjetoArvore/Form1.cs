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
                lsbCidades.Items.Add("Nome                X        Y");
                cidades.ExibirDados(lsbCidades, cidades.Raiz);

                cidades.PosicionarNaRaiz();
                Cidade cid = cidades.DadoAtual();
                txtNome.Text = cid.Nome;
                txtCoordX.Text = cid.X.ToString();
                txtCoordY.Text = cid.Y.ToString();
                cidades.SituacaoAtual = Situacao.navegando;

                VerificarBotoes();
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
                lsbCidades.Items.Add("Nome                X        Y");
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
                    cidades.Inserir(new Cidade(txtNome.Text, porcentagemX, porcentagemY));
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
                lsbCidades.Items.Add("Nome                X        Y");
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
            if(button1.Text == "Árvore")
            {
                Graphics g = e.Graphics;
                int esp = pbMapa.Bounds.Width / 150;
                Pen pen = new Pen(Color.Black, esp);
                cidades.PosicionarNaRaiz();
                cidades.DesenharMapa(true, pbMapa.Bounds.Width, pbMapa.Bounds.Height, pen, cidades.Raiz, esp, g);
            }
            else
            {
                cidades.DesenharArvore(pbMapa.Width/2, 0, e.Graphics);
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
                if(cidades.ApagarNo(new Cidade(txtNome.Text, 0, 0)))
                {
                    Cidade cid = cidades.DadoAtual();
                    txtNome.Text = cid.Nome;
                    txtCoordX.Text = cid.X.ToString();
                    txtCoordY.Text = cid.Y.ToString();

                    lsbCidades.Items.Clear();
                    lsbCidades.Items.Add("Nome                X        Y");
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
            using (var stream = File.Open(dlgAbrir.FileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    cidades.GravarDados(cidades.Raiz, writer);
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Árvore")
            {
                button1.Text = "Mapa";
                pbMapa.CreateGraphics().Clear(Color.Black);
                pbMapa.Image = null;
                pbMapa.Invalidate();
            }
            else
            {
                button1.Text = "Árvore";
                pbMapa.Image = Properties.Resources.mapaEspanhaPortugal;
            }
        }

        private void lsbCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cidade = lsbCidades.SelectedItem.ToString();
            string nome = cidade.Substring(0, 15);
            string x = cidade.Substring(16, 6);
            string y = cidade.Substring(22, 5);
            txtNome.Text = nome;
            txtCoordX.Text = x;
            txtCoordY.Text = y;
        }
    }
}

namespace apProjetoArvore
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnProcurar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.gbCaminhos = new System.Windows.Forms.GroupBox();
            this.btnCidades = new System.Windows.Forms.Button();
            this.btnHash = new System.Windows.Forms.Button();
            this.btnSubtrai = new System.Windows.Forms.Button();
            this.btnSoma = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numDistancia = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.cbOrigem = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbCidades = new System.Windows.Forms.GroupBox();
            this.btnCaminhos = new System.Windows.Forms.Button();
            this.lsbCidades = new System.Windows.Forms.ListBox();
            this.txtCoordY = new System.Windows.Forms.TextBox();
            this.txtCoordX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbCaminhos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).BeginInit();
            this.gbCidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProcurar,
            this.toolStripSeparator2,
            this.btnNovo,
            this.btnCancelar,
            this.btnSalvar,
            this.toolStripSeparator3,
            this.btnExcluir,
            this.btnSair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 43);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnProcurar
            // 
            this.btnProcurar.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcurar.Image = global::apProjetoArvore.Properties.Resources.procurar;
            this.btnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 40);
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::apProjetoArvore.Properties.Resources.novo1;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(53, 40);
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::apProjetoArvore.Properties.Resources.cancelar;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 40);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::apProjetoArvore.Properties.Resources.Salvar;
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(56, 40);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::apProjetoArvore.Properties.Resources.excluir;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(60, 40);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSair
            // 
            this.btnSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSair.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::apProjetoArvore.Properties.Resources.sair;
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(40, 40);
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "Cidades";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.gbCaminhos);
            this.panel1.Controls.Add(this.gbCidades);
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 456);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(88, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 28);
            this.button1.TabIndex = 26;
            this.button1.Text = "Árvore";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbCaminhos
            // 
            this.gbCaminhos.BackColor = System.Drawing.Color.Transparent;
            this.gbCaminhos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbCaminhos.Controls.Add(this.btnCidades);
            this.gbCaminhos.Controls.Add(this.btnHash);
            this.gbCaminhos.Controls.Add(this.btnSubtrai);
            this.gbCaminhos.Controls.Add(this.btnSoma);
            this.gbCaminhos.Controls.Add(this.numericUpDown2);
            this.gbCaminhos.Controls.Add(this.numericUpDown1);
            this.gbCaminhos.Controls.Add(this.label10);
            this.gbCaminhos.Controls.Add(this.label9);
            this.gbCaminhos.Controls.Add(this.numDistancia);
            this.gbCaminhos.Controls.Add(this.label8);
            this.gbCaminhos.Controls.Add(this.cbDestino);
            this.gbCaminhos.Controls.Add(this.cbOrigem);
            this.gbCaminhos.Controls.Add(this.label7);
            this.gbCaminhos.Controls.Add(this.label6);
            this.gbCaminhos.Controls.Add(this.label5);
            this.gbCaminhos.Location = new System.Drawing.Point(13, 7);
            this.gbCaminhos.Name = "gbCaminhos";
            this.gbCaminhos.Size = new System.Drawing.Size(279, 382);
            this.gbCaminhos.TabIndex = 3;
            this.gbCaminhos.TabStop = false;
            this.gbCaminhos.Text = "Caminhos";
            this.gbCaminhos.Visible = false;
            // 
            // btnCidades
            // 
            this.btnCidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCidades.Location = new System.Drawing.Point(76, 334);
            this.btnCidades.Name = "btnCidades";
            this.btnCidades.Size = new System.Drawing.Size(109, 28);
            this.btnCidades.TabIndex = 25;
            this.btnCidades.Text = "Cidades";
            this.btnCidades.UseVisualStyleBackColor = true;
            this.btnCidades.Click += new System.EventHandler(this.btnCidades_Click);
            // 
            // btnHash
            // 
            this.btnHash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHash.Location = new System.Drawing.Point(125, 232);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(47, 41);
            this.btnHash.TabIndex = 24;
            this.btnHash.Text = "#";
            this.btnHash.UseVisualStyleBackColor = true;
            // 
            // btnSubtrai
            // 
            this.btnSubtrai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubtrai.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubtrai.Location = new System.Drawing.Point(72, 232);
            this.btnSubtrai.Name = "btnSubtrai";
            this.btnSubtrai.Size = new System.Drawing.Size(47, 41);
            this.btnSubtrai.TabIndex = 23;
            this.btnSubtrai.Text = "-";
            this.btnSubtrai.UseVisualStyleBackColor = true;
            // 
            // btnSoma
            // 
            this.btnSoma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoma.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoma.Location = new System.Drawing.Point(19, 232);
            this.btnSoma.Name = "btnSoma";
            this.btnSoma.Size = new System.Drawing.Size(47, 41);
            this.btnSoma.TabIndex = 22;
            this.btnSoma.Text = "+";
            this.btnSoma.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(84, 198);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(85, 20);
            this.numericUpDown2.TabIndex = 21;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(84, 165);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(85, 20);
            this.numericUpDown1.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Custo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tempo:";
            // 
            // numDistancia
            // 
            this.numDistancia.Location = new System.Drawing.Point(84, 127);
            this.numDistancia.Name = "numDistancia";
            this.numDistancia.Size = new System.Drawing.Size(85, 20);
            this.numDistancia.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Distância:";
            // 
            // cbDestino
            // 
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(127, 86);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(84, 21);
            this.cbDestino.TabIndex = 15;
            // 
            // cbOrigem
            // 
            this.cbOrigem.FormattingEnabled = true;
            this.cbOrigem.Location = new System.Drawing.Point(20, 86);
            this.cbOrigem.Name = "cbOrigem";
            this.cbOrigem.Size = new System.Drawing.Size(84, 21);
            this.cbOrigem.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(124, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Destino:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Origem:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ligações";
            // 
            // gbCidades
            // 
            this.gbCidades.Controls.Add(this.btnCaminhos);
            this.gbCidades.Controls.Add(this.lsbCidades);
            this.gbCidades.Controls.Add(this.txtCoordY);
            this.gbCidades.Controls.Add(this.txtCoordX);
            this.gbCidades.Controls.Add(this.label4);
            this.gbCidades.Controls.Add(this.label3);
            this.gbCidades.Controls.Add(this.txtNome);
            this.gbCidades.Controls.Add(this.label2);
            this.gbCidades.Location = new System.Drawing.Point(13, 7);
            this.gbCidades.Name = "gbCidades";
            this.gbCidades.Size = new System.Drawing.Size(279, 382);
            this.gbCidades.TabIndex = 0;
            this.gbCidades.TabStop = false;
            this.gbCidades.Text = "Cidades";
            // 
            // btnCaminhos
            // 
            this.btnCaminhos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaminhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaminhos.Location = new System.Drawing.Point(75, 334);
            this.btnCaminhos.Name = "btnCaminhos";
            this.btnCaminhos.Size = new System.Drawing.Size(109, 28);
            this.btnCaminhos.TabIndex = 9;
            this.btnCaminhos.Text = "Caminhos";
            this.btnCaminhos.UseVisualStyleBackColor = true;
            this.btnCaminhos.Click += new System.EventHandler(this.btnAlternar_Click);
            // 
            // lsbCidades
            // 
            this.lsbCidades.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbCidades.FormattingEnabled = true;
            this.lsbCidades.ItemHeight = 16;
            this.lsbCidades.Location = new System.Drawing.Point(19, 123);
            this.lsbCidades.Name = "lsbCidades";
            this.lsbCidades.Size = new System.Drawing.Size(242, 180);
            this.lsbCidades.TabIndex = 8;
            this.lsbCidades.SelectedIndexChanged += new System.EventHandler(this.lsbCidades_SelectedIndexChanged);
            // 
            // txtCoordY
            // 
            this.txtCoordY.Location = new System.Drawing.Point(131, 81);
            this.txtCoordY.Name = "txtCoordY";
            this.txtCoordY.Size = new System.Drawing.Size(130, 20);
            this.txtCoordY.TabIndex = 7;
            // 
            // txtCoordX
            // 
            this.txtCoordX.Location = new System.Drawing.Point(131, 53);
            this.txtCoordX.Name = "txtCoordX";
            this.txtCoordX.Size = new System.Drawing.Size(130, 20);
            this.txtCoordX.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Coordenada Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Coordenada X:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(131, 25);
            this.txtNome.MaxLength = 15;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(130, 20);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome da Cidade:";
            // 
            // pbMapa
            // 
            this.pbMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMapa.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbMapa.Image = global::apProjetoArvore.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapa.Location = new System.Drawing.Point(315, 46);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(473, 437);
            this.pbMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMapa.TabIndex = 0;
            this.pbMapa.TabStop = false;
            this.pbMapa.Click += new System.EventHandler(this.pbMapa_Click);
            this.pbMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMapa_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.pbMapa);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(816, 476);
            this.Name = "Form1";
            this.Text = "Mapeamento de Cidades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gbCaminhos.ResumeLayout(false);
            this.gbCaminhos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).EndInit();
            this.gbCidades.ResumeLayout(false);
            this.gbCidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbCidades;
        private System.Windows.Forms.Button btnCaminhos;
        private System.Windows.Forms.ListBox lsbCidades;
        private System.Windows.Forms.TextBox txtCoordY;
        private System.Windows.Forms.TextBox txtCoordX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnProcurar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.GroupBox gbCaminhos;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Button btnSubtrai;
        private System.Windows.Forms.Button btnSoma;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numDistancia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.ComboBox cbOrigem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCidades;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbMapa;
    }
}


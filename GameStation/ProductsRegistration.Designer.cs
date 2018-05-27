namespace GameStation
{
    partial class ProductsRegistration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbBasic = new System.Windows.Forms.GroupBox();
            this.cmbDesenvolvedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDisponibilidade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mskEstoque = new System.Windows.Forms.MaskedTextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.checkListGeneros = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productImageBox = new System.Windows.Forms.PictureBox();
            this.loadImage = new System.Windows.Forms.Button();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gpbBasic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbBasic
            // 
            this.gpbBasic.Controls.Add(this.label8);
            this.gpbBasic.Controls.Add(this.checkListGeneros);
            this.gpbBasic.Controls.Add(this.txtDescricao);
            this.gpbBasic.Controls.Add(this.label7);
            this.gpbBasic.Controls.Add(this.txtPreco);
            this.gpbBasic.Controls.Add(this.label6);
            this.gpbBasic.Controls.Add(this.mskEstoque);
            this.gpbBasic.Controls.Add(this.label5);
            this.gpbBasic.Controls.Add(this.cmbDisponibilidade);
            this.gpbBasic.Controls.Add(this.label4);
            this.gpbBasic.Controls.Add(this.cmbDesenvolvedor);
            this.gpbBasic.Controls.Add(this.label3);
            this.gpbBasic.Controls.Add(this.txtNome);
            this.gpbBasic.Controls.Add(this.label1);
            this.gpbBasic.Location = new System.Drawing.Point(12, 78);
            this.gpbBasic.Name = "gpbBasic";
            this.gpbBasic.Size = new System.Drawing.Size(529, 416);
            this.gpbBasic.TabIndex = 0;
            this.gpbBasic.TabStop = false;
            this.gpbBasic.Text = "Informações básicas:";
            // 
            // cmbDesenvolvedor
            // 
            this.cmbDesenvolvedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesenvolvedor.FormattingEnabled = true;
            this.cmbDesenvolvedor.Location = new System.Drawing.Point(9, 95);
            this.cmbDesenvolvedor.Name = "cmbDesenvolvedor";
            this.cmbDesenvolvedor.Size = new System.Drawing.Size(216, 21);
            this.cmbDesenvolvedor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Desenvolvedor:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(9, 45);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(514, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(336, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cadastro de Produtos";
            // 
            // cmbDisponibilidade
            // 
            this.cmbDisponibilidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisponibilidade.FormattingEnabled = true;
            this.cmbDisponibilidade.Location = new System.Drawing.Point(279, 95);
            this.cmbDisponibilidade.Name = "cmbDisponibilidade";
            this.cmbDisponibilidade.Size = new System.Drawing.Size(244, 21);
            this.cmbDisponibilidade.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Disponibilidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Estoque:";
            // 
            // mskEstoque
            // 
            this.mskEstoque.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mskEstoque.HidePromptOnLeave = true;
            this.mskEstoque.Location = new System.Drawing.Point(6, 150);
            this.mskEstoque.Mask = "999999";
            this.mskEstoque.Name = "mskEstoque";
            this.mskEstoque.Size = new System.Drawing.Size(219, 20);
            this.mskEstoque.TabIndex = 7;
            this.mskEstoque.ValidatingType = typeof(int);
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(279, 150);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(244, 20);
            this.txtPreco.TabIndex = 9;
            this.txtPreco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPreco_KeyDown);
            this.txtPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Preço:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(9, 317);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(514, 83);
            this.txtDescricao.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Descrição:";
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Location = new System.Drawing.Point(863, 525);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(75, 23);
            this.btnNewProduct.TabIndex = 2;
            this.btnNewProduct.Text = "Cadastrar";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // checkListGeneros
            // 
            this.checkListGeneros.CheckOnClick = true;
            this.checkListGeneros.FormattingEnabled = true;
            this.checkListGeneros.Location = new System.Drawing.Point(6, 202);
            this.checkListGeneros.Name = "checkListGeneros";
            this.checkListGeneros.Size = new System.Drawing.Size(517, 79);
            this.checkListGeneros.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Gênero(s):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadImage);
            this.groupBox1.Controls.Add(this.productImageBox);
            this.groupBox1.Location = new System.Drawing.Point(547, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 416);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imagem:";
            // 
            // productImageBox
            // 
            this.productImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.productImageBox.Location = new System.Drawing.Point(32, 19);
            this.productImageBox.Name = "productImageBox";
            this.productImageBox.Size = new System.Drawing.Size(326, 352);
            this.productImageBox.TabIndex = 0;
            this.productImageBox.TabStop = false;
            // 
            // loadImage
            // 
            this.loadImage.Location = new System.Drawing.Point(276, 377);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(109, 23);
            this.loadImage.TabIndex = 1;
            this.loadImage.Text = "Carregar imagem";
            this.loadImage.UseVisualStyleBackColor = true;
            this.loadImage.Click += new System.EventHandler(this.loadImage_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileName = "openImageDialog";
            // 
            // ProductsRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 560);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gpbBasic);
            this.Name = "ProductsRegistration";
            this.Text = "Cadastro de Produto";
            this.Load += new System.EventHandler(this.ProductsRegistration_Load);
            this.gpbBasic.ResumeLayout(false);
            this.gpbBasic.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbBasic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cmbDesenvolvedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDisponibilidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mskEstoque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkListGeneros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.PictureBox productImageBox;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
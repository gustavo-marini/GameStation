namespace GameStation
{
    partial class ProductsReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkListGenFiltro = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecoFiltro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstoqueFiltro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDispFiltro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDevFiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listProdutos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkListGenFiltro);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPrecoFiltro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEstoqueFiltro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbDispFiltro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbDevFiltro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNomeFiltro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(579, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkListGenFiltro
            // 
            this.checkListGenFiltro.CheckOnClick = true;
            this.checkListGenFiltro.FormattingEnabled = true;
            this.checkListGenFiltro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkListGenFiltro.Location = new System.Drawing.Point(61, 146);
            this.checkListGenFiltro.MultiColumn = true;
            this.checkListGenFiltro.Name = "checkListGenFiltro";
            this.checkListGenFiltro.Size = new System.Drawing.Size(592, 49);
            this.checkListGenFiltro.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Gêneros:";
            // 
            // txtPrecoFiltro
            // 
            this.txtPrecoFiltro.Location = new System.Drawing.Point(410, 104);
            this.txtPrecoFiltro.Name = "txtPrecoFiltro";
            this.txtPrecoFiltro.Size = new System.Drawing.Size(243, 20);
            this.txtPrecoFiltro.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Preço:";
            // 
            // txtEstoqueFiltro
            // 
            this.txtEstoqueFiltro.Location = new System.Drawing.Point(61, 104);
            this.txtEstoqueFiltro.Name = "txtEstoqueFiltro";
            this.txtEstoqueFiltro.Size = new System.Drawing.Size(243, 20);
            this.txtEstoqueFiltro.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estoque:";
            // 
            // cmbDispFiltro
            // 
            this.cmbDispFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispFiltro.FormattingEnabled = true;
            this.cmbDispFiltro.Location = new System.Drawing.Point(443, 65);
            this.cmbDispFiltro.Name = "cmbDispFiltro";
            this.cmbDispFiltro.Size = new System.Drawing.Size(210, 21);
            this.cmbDispFiltro.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Disponibilidade:";
            // 
            // cmbDevFiltro
            // 
            this.cmbDevFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevFiltro.FormattingEnabled = true;
            this.cmbDevFiltro.Location = new System.Drawing.Point(94, 65);
            this.cmbDevFiltro.Name = "cmbDevFiltro";
            this.cmbDevFiltro.Size = new System.Drawing.Size(210, 21);
            this.cmbDevFiltro.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desenvolvedor:";
            // 
            // txtNomeFiltro
            // 
            this.txtNomeFiltro.Location = new System.Drawing.Point(50, 25);
            this.txtNomeFiltro.Name = "txtNomeFiltro";
            this.txtNomeFiltro.Size = new System.Drawing.Size(603, 20);
            this.txtNomeFiltro.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // listProdutos
            // 
            this.listProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listProdutos.FullRowSelect = true;
            this.listProdutos.Location = new System.Drawing.Point(12, 267);
            this.listProdutos.MultiSelect = false;
            this.listProdutos.Name = "listProdutos";
            this.listProdutos.Size = new System.Drawing.Size(660, 358);
            this.listProdutos.TabIndex = 3;
            this.listProdutos.UseCompatibleStateImageBehavior = false;
            this.listProdutos.View = System.Windows.Forms.View.Details;
            this.listProdutos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listProdutos_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 188;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Desenvolvedor";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Disponibilidade";
            this.columnHeader4.Width = 139;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Estoque";
            this.columnHeader5.Width = 68;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Preço";
            this.columnHeader6.Width = 79;
            // 
            // ProductsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 634);
            this.Controls.Add(this.listProdutos);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductsReport";
            this.Text = "ProductsReport";
            this.Load += new System.EventHandler(this.ProductsReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkListGenFiltro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecoFiltro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstoqueFiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDispFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDevFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listProdutos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
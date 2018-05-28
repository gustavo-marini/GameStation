namespace GameStation
{
    partial class Genders
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewGender = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.listGenders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.db_gamestationDataSet1 = new GameStation.db_gamestationDataSet1();
            this.tbprodutosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produtosTableAdapter = new GameStation.db_gamestationDataSet1TableAdapters.tb_produtosTableAdapter();
            this.tbgenerosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_generosTableAdapter = new GameStation.db_gamestationDataSet1TableAdapters.tb_generosTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.db_gamestationDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgenerosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewGender);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novo gênero:";
            // 
            // btnNewGender
            // 
            this.btnNewGender.Location = new System.Drawing.Point(485, 106);
            this.btnNewGender.Name = "btnNewGender";
            this.btnNewGender.Size = new System.Drawing.Size(75, 23);
            this.btnNewGender.TabIndex = 5;
            this.btnNewGender.Text = "Cadastrar";
            this.btnNewGender.UseVisualStyleBackColor = true;
            this.btnNewGender.Click += new System.EventHandler(this.btnNewGender_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(9, 51);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(551, 20);
            this.txtNome.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(235, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gêneros";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.listGenders);
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 204);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de gêneros:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(396, 71);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(164, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Deletar gênero selecionado";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(396, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(164, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Editar gênero selecionado";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.button1_Click);
            // 
            // listGenders
            // 
            this.listGenders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listGenders.FullRowSelect = true;
            this.listGenders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listGenders.Location = new System.Drawing.Point(9, 19);
            this.listGenders.MultiSelect = false;
            this.listGenders.Name = "listGenders";
            this.listGenders.Size = new System.Drawing.Size(315, 179);
            this.listGenders.TabIndex = 0;
            this.listGenders.UseCompatibleStateImageBehavior = false;
            this.listGenders.View = System.Windows.Forms.View.Details;
            this.listGenders.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstItems_ColumnWidthChanging);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 192;
            // 
            // db_gamestationDataSet1
            // 
            this.db_gamestationDataSet1.DataSetName = "db_gamestationDataSet1";
            this.db_gamestationDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbprodutosBindingSource
            // 
            this.tbprodutosBindingSource.DataMember = "tb_produtos";
            this.tbprodutosBindingSource.DataSource = this.db_gamestationDataSet1;
            // 
            // tb_produtosTableAdapter
            // 
            this.tb_produtosTableAdapter.ClearBeforeFill = true;
            // 
            // tbgenerosBindingSource
            // 
            this.tbgenerosBindingSource.DataMember = "tb_generos";
            this.tbgenerosBindingSource.DataSource = this.db_gamestationDataSet1;
            // 
            // tb_generosTableAdapter
            // 
            this.tb_generosTableAdapter.ClearBeforeFill = true;
            // 
            // Genders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Genders";
            this.Text = "Genders";
            this.Activated += new System.EventHandler(this.Genders_FocusEnter);
            this.Load += new System.EventHandler(this.Genders_Load);
            this.Enter += new System.EventHandler(this.Genders_FocusEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.db_gamestationDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbgenerosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNewGender;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private db_gamestationDataSet1 db_gamestationDataSet1;
        private System.Windows.Forms.BindingSource tbprodutosBindingSource;
        private db_gamestationDataSet1TableAdapters.tb_produtosTableAdapter tb_produtosTableAdapter;
        private System.Windows.Forms.BindingSource tbgenerosBindingSource;
        private db_gamestationDataSet1TableAdapters.tb_generosTableAdapter tb_generosTableAdapter;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listGenders;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}
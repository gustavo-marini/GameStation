namespace GameStation
{
    partial class CitiesRegistration
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
            this.cmbEstados = new System.Windows.Forms.ComboBox();
            this.db_gamestationDataSet = new GameStation.db_gamestationDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.btnNewCity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.db_gamestationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEstados
            // 
            this.cmbEstados.FormattingEnabled = true;
            this.cmbEstados.Location = new System.Drawing.Point(12, 114);
            this.cmbEstados.Name = "cmbEstados";
            this.cmbEstados.Size = new System.Drawing.Size(146, 21);
            this.cmbEstados.TabIndex = 0;
            this.cmbEstados.Text = "Selecione um estado...";
            this.cmbEstados.SelectedIndexChanged += new System.EventHandler(this.cmbEstados_SelectedIndexChanged);
            // 
            // db_gamestationDataSet
            // 
            this.db_gamestationDataSet.DataSetName = "db_gamestationDataSet";
            this.db_gamestationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadastro de Cidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(243, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cidade:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(246, 114);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(212, 20);
            this.txtCidade.TabIndex = 4;
            // 
            // btnNewCity
            // 
            this.btnNewCity.Location = new System.Drawing.Point(383, 202);
            this.btnNewCity.Name = "btnNewCity";
            this.btnNewCity.Size = new System.Drawing.Size(75, 23);
            this.btnNewCity.TabIndex = 5;
            this.btnNewCity.Text = "Cadastrar";
            this.btnNewCity.UseVisualStyleBackColor = true;
            this.btnNewCity.Click += new System.EventHandler(this.btnNewCity_Click);
            // 
            // CitiesRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 237);
            this.Controls.Add(this.btnNewCity);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstados);
            this.Name = "CitiesRegistration";
            this.Text = "CitiesRegistration";
            this.Load += new System.EventHandler(this.CitiesRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.db_gamestationDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEstados;
        private System.Windows.Forms.Label label1;
        private db_gamestationDataSet db_gamestationDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Button btnNewCity;
    }
}
namespace GameStation
{
    partial class AllCities
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
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.addNewCity = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.listCidades = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(435, 450);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(168, 23);
            this.btnRemoveProduct.TabIndex = 8;
            this.btnRemoveProduct.Text = "Remover cidade selecionada";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // addNewCity
            // 
            this.addNewCity.Location = new System.Drawing.Point(435, 392);
            this.addNewCity.Name = "addNewCity";
            this.addNewCity.Size = new System.Drawing.Size(168, 23);
            this.addNewCity.TabIndex = 9;
            this.addNewCity.Text = "Nova cidade";
            this.addNewCity.UseVisualStyleBackColor = true;
            this.addNewCity.Click += new System.EventHandler(this.addNewCity_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(435, 421);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(168, 23);
            this.btnEditProduct.TabIndex = 7;
            this.btnEditProduct.Text = "Editar cidade selecionada";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // listCidades
            // 
            this.listCidades.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7});
            this.listCidades.FullRowSelect = true;
            this.listCidades.Location = new System.Drawing.Point(12, 12);
            this.listCidades.MultiSelect = false;
            this.listCidades.Name = "listCidades";
            this.listCidades.Size = new System.Drawing.Size(591, 358);
            this.listCidades.TabIndex = 6;
            this.listCidades.UseCompatibleStateImageBehavior = false;
            this.listCidades.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 307;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Estado";
            this.columnHeader3.Width = 156;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "CEP";
            // 
            // AllCities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 486);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.addNewCity);
            this.Controls.Add(this.btnEditProduct);
            this.Controls.Add(this.listCidades);
            this.Name = "AllCities";
            this.Text = "AllCities";
            this.Load += new System.EventHandler(this.AllCities_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button addNewCity;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.ListView listCidades;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}
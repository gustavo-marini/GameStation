namespace GameStation
{
    partial class AllProducts
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
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.addNewProduct = new System.Windows.Forms.Button();
            this.listProdutos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(701, 445);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(168, 23);
            this.btnRemoveProduct.TabIndex = 4;
            this.btnRemoveProduct.Text = "Remover produto selecionado";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.Location = new System.Drawing.Point(701, 416);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(168, 23);
            this.btnEditProduct.TabIndex = 3;
            this.btnEditProduct.Text = "Editar produto selecionado";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // addNewProduct
            // 
            this.addNewProduct.Location = new System.Drawing.Point(701, 387);
            this.addNewProduct.Name = "addNewProduct";
            this.addNewProduct.Size = new System.Drawing.Size(168, 23);
            this.addNewProduct.TabIndex = 5;
            this.addNewProduct.Text = "Novo produto";
            this.addNewProduct.UseVisualStyleBackColor = true;
            this.addNewProduct.Click += new System.EventHandler(this.addNewProduct_Click);
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
            this.listProdutos.Location = new System.Drawing.Point(12, 12);
            this.listProdutos.MultiSelect = false;
            this.listProdutos.Name = "listProdutos";
            this.listProdutos.Size = new System.Drawing.Size(857, 358);
            this.listProdutos.TabIndex = 2;
            this.listProdutos.UseCompatibleStateImageBehavior = false;
            this.listProdutos.View = System.Windows.Forms.View.Details;
            this.listProdutos.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listProdutos_ColumnWidthChanging);
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
            this.columnHeader3.Text = "Desenvolvedor";
            this.columnHeader3.Width = 156;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Disponibilidade";
            this.columnHeader4.Width = 180;
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
            // AllProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 486);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.addNewProduct);
            this.Controls.Add(this.btnEditProduct);
            this.Controls.Add(this.listProdutos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllProducts";
            this.ShowIcon = false;
            this.Text = "Todos os produtos";
            this.Activated += new System.EventHandler(this.AllProducts_FocusEnter);
            this.Load += new System.EventHandler(this.AllProducts_Load);
            this.Enter += new System.EventHandler(this.AllProducts_FocusEnter);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button addNewProduct;
        private System.Windows.Forms.ListView listProdutos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
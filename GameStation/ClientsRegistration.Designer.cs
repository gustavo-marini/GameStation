namespace GameStation
{
    partial class ClientsRegistration
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
            if (disposing && (components != null))
            {
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
            this.label1 = new System.Windows.Forms.Label();
            this.grpBasicInformation = new System.Windows.Forms.GroupBox();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCellphone = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBirthday = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpLocationInformation = new System.Windows.Forms.GroupBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtNeighborhood = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpBasicInformation.SuspendLayout();
            this.grpLocationInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Clientes";
            // 
            // grpBasicInformation
            // 
            this.grpBasicInformation.Controls.Add(this.txtCpf);
            this.grpBasicInformation.Controls.Add(this.label9);
            this.grpBasicInformation.Controls.Add(this.txtCellphone);
            this.grpBasicInformation.Controls.Add(this.label8);
            this.grpBasicInformation.Controls.Add(this.txtPhone);
            this.grpBasicInformation.Controls.Add(this.label7);
            this.grpBasicInformation.Controls.Add(this.txtAge);
            this.grpBasicInformation.Controls.Add(this.label6);
            this.grpBasicInformation.Controls.Add(this.txtBirthday);
            this.grpBasicInformation.Controls.Add(this.label5);
            this.grpBasicInformation.Controls.Add(this.txtEmail);
            this.grpBasicInformation.Controls.Add(this.label4);
            this.grpBasicInformation.Controls.Add(this.txtSurname);
            this.grpBasicInformation.Controls.Add(this.label3);
            this.grpBasicInformation.Controls.Add(this.txtName);
            this.grpBasicInformation.Controls.Add(this.label2);
            this.grpBasicInformation.Location = new System.Drawing.Point(12, 93);
            this.grpBasicInformation.Name = "grpBasicInformation";
            this.grpBasicInformation.Size = new System.Drawing.Size(662, 148);
            this.grpBasicInformation.TabIndex = 1;
            this.grpBasicInformation.TabStop = false;
            this.grpBasicInformation.Text = "Informações básicas";
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(557, 107);
            this.txtCpf.Mask = "000,000,000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(99, 20);
            this.txtCpf.TabIndex = 16;
            this.txtCpf.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(521, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "CPF:";
            // 
            // txtCellphone
            // 
            this.txtCellphone.Location = new System.Drawing.Point(320, 107);
            this.txtCellphone.Mask = "(99) 00000-0000";
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(115, 20);
            this.txtCellphone.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Celular:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(68, 107);
            this.txtPhone.Mask = "(99) 0000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(115, 20);
            this.txtPhone.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Telefone:";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(615, 67);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(41, 20);
            this.txtAge.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(572, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Idade:";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Location = new System.Drawing.Point(423, 67);
            this.txtBirthday.Mask = "00/00/0000";
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(99, 20);
            this.txtBirthday.TabIndex = 8;
            this.txtBirthday.ValidatingType = typeof(System.DateTime);
            this.txtBirthday.TextChanged += new System.EventHandler(this.txtBirthday_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Data de nascimento:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(68, 67);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(233, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(423, 26);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(233, 20);
            this.txtSurname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sobrenome: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(68, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(233, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome:";
            // 
            // grpLocationInformation
            // 
            this.grpLocationInformation.Controls.Add(this.txtState);
            this.grpLocationInformation.Controls.Add(this.label15);
            this.grpLocationInformation.Controls.Add(this.txtCity);
            this.grpLocationInformation.Controls.Add(this.label14);
            this.grpLocationInformation.Controls.Add(this.label13);
            this.grpLocationInformation.Controls.Add(this.txtNumber);
            this.grpLocationInformation.Controls.Add(this.txtNeighborhood);
            this.grpLocationInformation.Controls.Add(this.label12);
            this.grpLocationInformation.Controls.Add(this.txtAddress);
            this.grpLocationInformation.Controls.Add(this.label11);
            this.grpLocationInformation.Controls.Add(this.txtCep);
            this.grpLocationInformation.Controls.Add(this.label10);
            this.grpLocationInformation.Location = new System.Drawing.Point(12, 262);
            this.grpLocationInformation.Name = "grpLocationInformation";
            this.grpLocationInformation.Size = new System.Drawing.Size(662, 176);
            this.grpLocationInformation.TabIndex = 2;
            this.grpLocationInformation.TabStop = false;
            this.grpLocationInformation.Text = "Informações de endereço";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(313, 141);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(152, 20);
            this.txtState.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(264, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Estado:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(68, 141);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(152, 20);
            this.txtCity.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Cidade:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(334, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Nº:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(362, 66);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(38, 20);
            this.txtNumber.TabIndex = 17;
            // 
            // txtNeighborhood
            // 
            this.txtNeighborhood.Location = new System.Drawing.Point(68, 103);
            this.txtNeighborhood.Name = "txtNeighborhood";
            this.txtNeighborhood.Size = new System.Drawing.Size(152, 20);
            this.txtNeighborhood.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Bairro:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(68, 66);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(233, 20);
            this.txtAddress.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Endereço:";
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(68, 30);
            this.txtCep.Mask = "00000-000";
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(87, 20);
            this.txtCep.TabIndex = 13;
            this.txtCep.TextChanged += new System.EventHandler(this.txtCep_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "CEP:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(599, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Cadastrar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ClientsRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 492);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpLocationInformation);
            this.Controls.Add(this.grpBasicInformation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ClientsRegistration";
            this.Text = "Cadastro de Clientes - GameStation";
            this.Load += new System.EventHandler(this.ClientsRegistration_Load);
            this.grpBasicInformation.ResumeLayout(false);
            this.grpBasicInformation.PerformLayout();
            this.grpLocationInformation.ResumeLayout(false);
            this.grpLocationInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBasicInformation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtBirthday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtCellphone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpLocationInformation;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtNeighborhood;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
    }
}
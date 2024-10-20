namespace CapaPresentacion
{
    partial class Orders
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxOrdersID = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtShipCountry = new System.Windows.Forms.TextBox();
            this.txtShipPostalCode = new System.Windows.Forms.TextBox();
            this.txtShipRegion = new System.Windows.Forms.TextBox();
            this.txtShipCity = new System.Windows.Forms.TextBox();
            this.txtShipAddress = new System.Windows.Forms.TextBox();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxshipvia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerShippedDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerordersdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxemployeeid = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomerid = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 426);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(777, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consultar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxOrdersID);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtShipCountry);
            this.tabPage2.Controls.Add(this.txtShipPostalCode);
            this.tabPage2.Controls.Add(this.txtShipRegion);
            this.tabPage2.Controls.Add(this.txtShipCity);
            this.tabPage2.Controls.Add(this.txtShipAddress);
            this.tabPage2.Controls.Add(this.txtShipName);
            this.tabPage2.Controls.Add(this.txtFreight);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.comboBoxshipvia);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dateTimePickerShippedDate);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dateTimePickerRequiredDate);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dateTimePickerordersdate);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboBoxemployeeid);
            this.tabPage2.Controls.Add(this.comboBoxCustomerid);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnModificar);
            this.tabPage2.Controls.Add(this.btnAgregar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(777, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Agregar";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // comboBoxOrdersID
            // 
            this.comboBoxOrdersID.FormattingEnabled = true;
            this.comboBoxOrdersID.Location = new System.Drawing.Point(20, 25);
            this.comboBoxOrdersID.Name = "comboBoxOrdersID";
            this.comboBoxOrdersID.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOrdersID.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "OrdersID";
            // 
            // txtShipCountry
            // 
            this.txtShipCountry.Location = new System.Drawing.Point(301, 294);
            this.txtShipCountry.Name = "txtShipCountry";
            this.txtShipCountry.Size = new System.Drawing.Size(100, 20);
            this.txtShipCountry.TabIndex = 47;
            // 
            // txtShipPostalCode
            // 
            this.txtShipPostalCode.Location = new System.Drawing.Point(301, 252);
            this.txtShipPostalCode.Name = "txtShipPostalCode";
            this.txtShipPostalCode.Size = new System.Drawing.Size(100, 20);
            this.txtShipPostalCode.TabIndex = 46;
            // 
            // txtShipRegion
            // 
            this.txtShipRegion.Location = new System.Drawing.Point(301, 204);
            this.txtShipRegion.Name = "txtShipRegion";
            this.txtShipRegion.Size = new System.Drawing.Size(100, 20);
            this.txtShipRegion.TabIndex = 45;
            // 
            // txtShipCity
            // 
            this.txtShipCity.Location = new System.Drawing.Point(301, 164);
            this.txtShipCity.Name = "txtShipCity";
            this.txtShipCity.Size = new System.Drawing.Size(100, 20);
            this.txtShipCity.TabIndex = 44;
            // 
            // txtShipAddress
            // 
            this.txtShipAddress.Location = new System.Drawing.Point(301, 115);
            this.txtShipAddress.Name = "txtShipAddress";
            this.txtShipAddress.Size = new System.Drawing.Size(100, 20);
            this.txtShipAddress.TabIndex = 43;
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(301, 77);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(100, 20);
            this.txtShipName.TabIndex = 42;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(301, 34);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(100, 20);
            this.txtFreight.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(296, 277);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "ShipCountry";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(294, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "ShipPostalCode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(298, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "ShipRegion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "ShipCity";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "ShipAddress";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(294, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "ShipName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Freight";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "ShipVia";
            // 
            // comboBoxshipvia
            // 
            this.comboBoxshipvia.FormattingEnabled = true;
            this.comboBoxshipvia.Location = new System.Drawing.Point(23, 265);
            this.comboBoxshipvia.Name = "comboBoxshipvia";
            this.comboBoxshipvia.Size = new System.Drawing.Size(121, 21);
            this.comboBoxshipvia.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "ShippedDate";
            // 
            // dateTimePickerShippedDate
            // 
            this.dateTimePickerShippedDate.Location = new System.Drawing.Point(23, 228);
            this.dateTimePickerShippedDate.Name = "dateTimePickerShippedDate";
            this.dateTimePickerShippedDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerShippedDate.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "RequiredDate";
            // 
            // dateTimePickerRequiredDate
            // 
            this.dateTimePickerRequiredDate.Location = new System.Drawing.Point(20, 185);
            this.dateTimePickerRequiredDate.Name = "dateTimePickerRequiredDate";
            this.dateTimePickerRequiredDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerRequiredDate.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "OrderDate";
            // 
            // dateTimePickerordersdate
            // 
            this.dateTimePickerordersdate.Location = new System.Drawing.Point(23, 148);
            this.dateTimePickerordersdate.Name = "dateTimePickerordersdate";
            this.dateTimePickerordersdate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerordersdate.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "EmployeeID";
            // 
            // comboBoxemployeeid
            // 
            this.comboBoxemployeeid.FormattingEnabled = true;
            this.comboBoxemployeeid.Location = new System.Drawing.Point(23, 106);
            this.comboBoxemployeeid.Name = "comboBoxemployeeid";
            this.comboBoxemployeeid.Size = new System.Drawing.Size(121, 21);
            this.comboBoxemployeeid.TabIndex = 24;
            // 
            // comboBoxCustomerid
            // 
            this.comboBoxCustomerid.FormattingEnabled = true;
            this.comboBoxCustomerid.Location = new System.Drawing.Point(23, 66);
            this.comboBoxCustomerid.Name = "comboBoxCustomerid";
            this.comboBoxCustomerid.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCustomerid.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "CustomerID";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(131, 339);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 21;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(23, 340);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 20;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(767, 387);
            this.dataGridView1.TabIndex = 0;
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Orders";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.Orders_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerordersdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxemployeeid;
        private System.Windows.Forms.ComboBox comboBoxCustomerid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxshipvia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerShippedDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequiredDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtShipCountry;
        private System.Windows.Forms.TextBox txtShipPostalCode;
        private System.Windows.Forms.TextBox txtShipRegion;
        private System.Windows.Forms.TextBox txtShipCity;
        private System.Windows.Forms.TextBox txtShipAddress;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.ComboBox comboBoxOrdersID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
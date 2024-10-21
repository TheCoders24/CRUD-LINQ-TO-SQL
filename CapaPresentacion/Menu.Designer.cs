namespace CapaPresentacion
{
    partial class Menu
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
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnOrdersDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(18, 82);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(148, 54);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Consultas";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(262, 82);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(148, 54);
            this.btnOrders.TabIndex = 1;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnOrdersDetails
            // 
            this.btnOrdersDetails.Location = new System.Drawing.Point(135, 201);
            this.btnOrdersDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOrdersDetails.Name = "btnOrdersDetails";
            this.btnOrdersDetails.Size = new System.Drawing.Size(148, 54);
            this.btnOrdersDetails.TabIndex = 2;
            this.btnOrdersDetails.Text = "OrdersDetails";
            this.btnOrdersDetails.UseVisualStyleBackColor = true;
            this.btnOrdersDetails.Click += new System.EventHandler(this.btnOrdersDetails_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(486, 314);
            this.Controls.Add(this.btnOrdersDetails);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnProductos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnOrdersDetails;
    }
}
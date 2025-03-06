namespace db {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.labelManageCustomers = new System.Windows.Forms.Label();
            this.labelSignIn = new System.Windows.Forms.Label();
            this.labelProducts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelManageCustomers
            // 
            this.labelManageCustomers.AutoSize = true;
            this.labelManageCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelManageCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManageCustomers.Location = new System.Drawing.Point(81, 69);
            this.labelManageCustomers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManageCustomers.Name = "labelManageCustomers";
            this.labelManageCustomers.Size = new System.Drawing.Size(186, 27);
            this.labelManageCustomers.TabIndex = 0;
            this.labelManageCustomers.Text = "Manage Customers";
            this.labelManageCustomers.Click += new System.EventHandler(this.labelManageCustomers_Click);
            // 
            // labelSignIn
            // 
            this.labelSignIn.AutoSize = true;
            this.labelSignIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignIn.Location = new System.Drawing.Point(81, 162);
            this.labelSignIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSignIn.Name = "labelSignIn";
            this.labelSignIn.Size = new System.Drawing.Size(195, 27);
            this.labelSignIn.TabIndex = 1;
            this.labelSignIn.Text = "Sign In to the system";
            this.labelSignIn.Click += new System.EventHandler(this.labelSignIn_Click);
            // 
            // labelProducts
            // 
            this.labelProducts.AutoSize = true;
            this.labelProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducts.Location = new System.Drawing.Point(81, 249);
            this.labelProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProducts.Name = "labelProducts";
            this.labelProducts.Size = new System.Drawing.Size(168, 27);
            this.labelProducts.TabIndex = 2;
            this.labelProducts.Text = "Manage Products";
            this.labelProducts.Click += new System.EventHandler(this.labelProducts_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.labelProducts);
            this.Controls.Add(this.labelSignIn);
            this.Controls.Add(this.labelManageCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Database Management Example";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelManageCustomers;
        private System.Windows.Forms.Label labelSignIn;
        private System.Windows.Forms.Label labelProducts;
    }
}


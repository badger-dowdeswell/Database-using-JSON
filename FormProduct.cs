using System;
//
// MAINTAIN PRODUCT INFORMATION
// =============================
// This form is used to manage the creation of new products in the Product database
// table. It also allows the information for each product to be changed and updated
// later.
//
// Revision History
// ================
// 04.13.2025 BRD Original version.// 
//
using System.Windows.Forms;

namespace db {
    public partial class FormProduct : Form {
        
        Form FormParent;

        // Trick to stop the dialogue boxes showing 
        // repeatedly when trying to create a new
        // customer. Look in the other functions to
        // see when and how it is used.
        Boolean creating = false;

        string productID = "";
        
        // Create the database object to handle the reading
        // and updating of product data.
        dbProduct product = new dbProduct();        

        //
        // Constructor
        // ===========
        public FormProduct(Form FormParent) {
            InitializeComponent();

            // The parent of this form is FormMain. A reference
            // to it was passed in via this Constructor. Save it
            // so we know where to go back to when we close
            // this form.
            this.FormParent = FormParent;
        }

         //
        // FormProduct_Load
        // ================
        private void FormProduct_Load(object sender, EventArgs e) {
            comboBoxProductID.Items.Clear();
            string[] fileList = product.Query();           
            comboBoxProductID.Items.AddRange(fileList);   
        }

        //
        // comboBoxProductID_TextChanged
        // =============================
        private void comboBoxProductID_TextChanged(object sender, EventArgs e) {
            productID = comboBoxProductID.Text.Trim();
            product.ProductID = productID; 
        }

        //
        // comboBoxProductID_SelectionChangeCommitted
        // ==========================================
        private void comboBoxProductID_SelectionChangeCommitted(object sender, EventArgs e) {
            DialogResult result;

            if (!creating) {
                try { 
                    productID = comboBoxProductID.SelectedItem.ToString();
                } catch {
                    productID = "";
                }

                if (productID != "") {
                    if (product.Read(productID)) {
                        textBoxProductDesc.Text = product.ProductDesc;                        
                        textBoxPrice.Text = product.Price.ToString();
                    } else {
                        result = MessageBox.Show("Click Yes to create a new product",                          
                                                 "Product does not exist",
                                                 MessageBoxButtons.YesNo, 
                                                 MessageBoxIcon.Question);
                        if (result == DialogResult.Yes) {
                            creating = true;
                            textBoxProductDesc.Focus();
                        } else {
                            comboBoxProductID.Text = "";
                            comboBoxProductID.Focus();
                        }
                    }
                } else {
                    comboBoxProductID.Focus();
                }
            }
        }

        //
        // comboBoxProductID_Leave
        // =======================
        private void comboBoxProductID_Leave(object sender, EventArgs e) {DialogResult result;
            if (!creating) {
                productID = comboBoxProductID.Text;
                if (productID != "") {
                    if (product.Read(productID)) {
                        textBoxProductDesc.Text = product.ProductDesc;
                        textBoxPrice.Text = product.Price.ToString("####.00");                         
                    } else {
                        result = MessageBox.Show("Click Yes to create a new product",                          
                                                 "Product does not exist",
                                                 MessageBoxButtons.YesNo, 
                                                 MessageBoxIcon.Question);
                        if (result == DialogResult.Yes) {
                            creating = true;
                            textBoxProductDesc.Focus();
                        } else {
                            comboBoxProductID.Text = "";
                            comboBoxProductID.Focus();
                        }
                    }
                }
            }
        }

        //
        // textBoxProductDesc_TextChanged
        // ==============================
        private void textBoxProductDesc_TextChanged(object sender, EventArgs e) {
            product.ProductDesc = textBoxProductDesc.Text.Trim();
        }

        //
        // textBoxPrice_TextChanged
        // ========================
        private void textBoxPrice_TextChanged(object sender, EventArgs e) {
            try { 
                product.Price = Convert.ToSingle(textBoxPrice.Text);
            } catch {
                product.Price = 0;
            }
        }

        // buttonClose_Click
        // =================
        // Return to FormMain. See the project Form Loading available on
        // GitHub for more information about managing multiple forms in
        // a Visual Studio C# project.
        //
        private void buttonClose_Click(object sender, EventArgs e) {
            // Hide this form now we have finished with it. Note that
            // this does not destroy FormOne or its lose its data. If
            // we come back, it will remember what we did last time.
            creating = false;
            this.Visible = false;

            // Go back to the parent of this form which is FormMain.
            FormParent.Show();
        }

        //
        // buttonUpdate_Click
        // ==================
        private void buttonUpdate_Click(object sender, EventArgs e) {
            product.Update(productID);  
            comboBoxProductID.Text = "";
            textBoxProductDesc.Text = "";
            textBoxPrice.Text = "";            
            creating = false;

            // Update the list in the combo box to add the
            // new product to the list.
            comboBoxProductID.Items.Clear();
            string[] fileList = product.Query();           
            comboBoxProductID.Items.AddRange(fileList);    
            comboBoxProductID.Focus();
        }

        
    }
}




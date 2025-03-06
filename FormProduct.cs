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
        // FormCustomer_Load
        // =================
        private void FormProduct_Load(object sender, EventArgs e) {

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
    }
}




//
// SIMPLE DATABASE MANAGEMENT EXAMPLE
// ==================================
// Studio 2 projects often need a simple database to persist
// data such as customer and product information.
//
// This project demonstrates how to build a custom class to
// manage each database table in a way similiar to how an
// SQL client might access a database. However, the tables are
// stored as separate Java Script Object Notation (JSON)
// format text files.  
//
// JSON is an open standard file format that uses human-readable
// text to store information as data objects consisting of
// attribute–value pairs and arrays. You can read more about
// the JSON standard on Wikipedia:
// https://en.wikipedia.org/wiki/JSON
//
// Revision History
// ================
// 02.11.2024 BRD Original version.
// 04.11.2024 BRD Fixed some small errors.
// 08.03.2025 BRD Revised documentation.
//
using System;
using System.Windows.Forms;

namespace db {
    public partial class FormMain : Form {

        // These references allow the forms to 
        // know their parent when navigating.
        Form formCustomer;
        Form formSignIn;
        Form formProduct;

        //
        // Constructor
        // ===========
        public FormMain() {
            InitializeComponent();

            // Create the Customer Maintenance form.
            formCustomer = new FormCustomer(this);  

            // Create the Product Maintenance form.
            formProduct = new FormProduct(this);

            // Create the Sign-In form.
            formSignIn = new FormSignIn(this);
        }

        //
        // FormMain_Load
        // =============
        // You can add extra actions and calls to functions here that
        // run before the main application displays and is ready to be
        // used by the client.
        //
        private void FormMain_Load(object sender, EventArgs e) {
            
        }

        //
        // labelManageCustomers_Click
        // ==========================
        private void labelManageCustomers_Click(object sender, EventArgs e) {
            // Use this command if you want the main form to be hidden when
            // the Customer form is shown. Don't forget to make it visible
            // again when you close the Customer Form and return to the
            // main page:
            // this.Visible = false;

            // Tell the FormCustomer to show itself as a modal dialog without
            // hiding this form (see the comment above).
            formCustomer.ShowDialog();
        }

        //
        // labelSignIn_Click
        // =================
        // Tell FormSignIn to show itself as a modal dialog without
        // hiding this form.
        //
        private void labelSignIn_Click(object sender, EventArgs e) {            
            formSignIn.ShowDialog();
        }

        //
        // labelProducts_Click
        // ===================
        private void labelProducts_Click(object sender, EventArgs e) {
            formProduct.ShowDialog();
        }
    }
}

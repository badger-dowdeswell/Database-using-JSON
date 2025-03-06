using System;
using System.Windows.Forms;

namespace db {
    public partial class FormSignIn : Form {

        Form FormParent;        
        
        // Create the database object to handle the reading
        // of the customer data needed to sign in.
        dbCustomer customer = new dbCustomer();

        //
        // Constructor
        // ===========
        public FormSignIn(Form FormParent) {
            InitializeComponent();

            // The parent of this form is FormMain. A reference
            // to it was passed in via this Constructor. Save it
            // so we know where to go back to when we close
            // this form.
            this.FormParent = FormParent;            
        }

        //
        // FormSignIn_Load
        // ===============
        private void FormSignIn_Load(object sender, EventArgs e) {                  
        }

        //
        // buttonSignIn_Click
        // ==================
        private void buttonSignIn_Click(object sender, EventArgs e) {
            string customerID = textBoxCustomerID.Text.Trim();
            Boolean signedIn = false;

            if (customerID != "") {
                if (customer.Read(customerID)) {
                    if (textBoxPassword.Text.Trim() == customer.Password) {
                        signedIn = true;
                    }
                }
            }

            if (signedIn) {
                MessageBox.Show("Signed in. Press Enter to continue.", "Sign In");
                this.Visible = false;

                // Go back to the parent of this form which is FormMain.
                FormParent.Show();                
            } else {
                MessageBox.Show("Not signed in. Please reenter your information correctly", "Sign In");
            }            
        }

        //
        // buttonExit_Click
        // ================
        private void buttonExit_Click(object sender, EventArgs e) {
            // Hide this form now we have finished with it. Note that
            // this does not destroy FormOne or its lose its data. If
            // we come back, it will remember what we did last time.            
            this.Visible = false;

            // Go back to the parent of this form which is FormMain.
            FormParent.Show();
        }                
    }
}

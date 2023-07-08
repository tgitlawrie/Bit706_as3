using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bit706_as2
{
    public partial class AddCustomerForm : ParentForm
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.StartPosition = FormStartPosition.Manual;
            manageCustomers.Location = this.Location;
            manageCustomers.ShowDialog();
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string firstName = txtFname.Text;
            string lastName = txtLname.Text;
            if(customerController.AddCustomer(firstName, lastName)){
                //do the things
                this.Hide();
                ManageCustomers manageCustomers = new ManageCustomers();
                manageCustomers.StartPosition = FormStartPosition.Manual;
                manageCustomers.Location = this.Location;
                manageCustomers.ShowDialog();
                this.Close();
            }
            else
            {
                //dont do the things
            }
            
        }
    }
}

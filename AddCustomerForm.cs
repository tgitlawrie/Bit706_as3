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
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string city = txtCity.Text;
            string address = txtAddress.Text;
            bool isStaff = chkStaff.Checked;
            if (!customerController.AddCustomer(firstName, lastName,address,city,phone,email, isStaff))
            {
                MessageBox.Show(customerController.ErrorMessage);
                return;
            }

            this.Hide();
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.StartPosition = FormStartPosition.Manual;
            manageCustomers.Location = this.Location;
            manageCustomers.ShowDialog();
            this.Close();

        }
    }
}

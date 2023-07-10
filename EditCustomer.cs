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
    public partial class EditCustomer : ParentForm
    {
        private Customer customer;
        private string oldFname;
        private string oldLname;
        private int ID;
        public EditCustomer(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            txtEditFname.Text = customer.FirstName;
            txtEditLname.Text = customer.LastName;

            this.oldFname = customer.FirstName;
            this.oldLname = customer.LastName;
            this.ID = customer.ID;
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.StartPosition = FormStartPosition.Manual;
            manageCustomers.Location = this.Location;
            manageCustomers.ShowDialog();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            customer.FirstName = txtEditFname.Text;
            customer.LastName = txtEditLname.Text;

            if (!customerController.EditCustomer(customer))
            {
                MessageBox.Show(customerController.ErrorMessage);
                return;
            }

            string message = $"Successfully updated {oldFname} {oldLname} to {customer.FirstName} {customer.LastName}";
            string title = "Update Success";
            MessageBox.Show(message, title);

            this.Hide();
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.StartPosition = FormStartPosition.Manual;
            manageCustomers.Location = this.Location;
            manageCustomers.ShowDialog();
            this.Close();
        }
    }
}

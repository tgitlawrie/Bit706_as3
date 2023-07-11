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
      
        public EditCustomer(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            txtEditFname.Text = customer.FirstName;
            txtEditLname.Text = customer.LastName;
            txtAddress.Text = customer.Address;
            txtCity.Text = customer.City;
            txtPhone.Text = customer.Phone;
            txtEmail.Text = customer.Email;
            chkStaff.Checked = customer.IsStaff;
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
            customer.Address = txtAddress.Text;
            customer.City = txtCity.Text;
            customer.Phone = txtPhone.Text;
            customer.Email = txtEmail.Text;
            customer.IsStaff = chkStaff.Checked;
            

            if (!customerController.EditCustomer(customer))
            {
                MessageBox.Show(customerController.ErrorMessage);
                return;
            }

            string message = $"Successfully updated {customer.FirstName} {customer.LastName}'s records";
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

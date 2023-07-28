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
    public partial class ManageCustomers : ParentForm
    {
        public ManageCustomers()
        {
            InitializeComponent();
            DisplayCustomers();
        }

        public void DisplayCustomers()
        {
            lstCustomers.Items.Clear();
            foreach (Customer c in customerController.customerList)
            {
                lstCustomers.Items.Add(c.CustomerInfo());
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.StartPosition = FormStartPosition.Manual;
            addCustomerForm.Location = this.Location;
            addCustomerForm.ShowDialog();
            this.Close();

        }

        private void bntDeleteCustomer_Click(object sender, EventArgs e)
        {
            //check a customer was selected
            if (!IsCustomerSelected()) return;

            //retrieve customer
            Customer customer = GetCustomer();
            
            if (customer == null)
            {
                MessageBox.Show("Error, Customer not found");
                return;
            }


            //confirmation dialog
            string message = $"Are you sure you want to delete {customer.FirstName} {customer.LastName}";
            string title = "Confirm Close?";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                customerController.DeleteCustomer(customer);
                DisplayCustomers(); //refresh the list
            }
            else
            {
                return;
            }
        }

        private void bntEditCustomer_Click(object sender, EventArgs e)
        {
            //check a customer was selected
            if (!IsCustomerSelected()) return;

            //retrieve customer
            Customer customer = GetCustomer();
            if (customer == null)
            {
                MessageBox.Show("Error, Customer not found");
                return;
            }

            //call edit customer form
            this.Hide();
            EditCustomer editCustomerForm = new EditCustomer(customer);
            editCustomerForm.StartPosition = FormStartPosition.Manual;
            editCustomerForm.Location = this.Location;
            editCustomerForm.ShowDialog();
            this.Close();
        }

        private bool IsCustomerSelected()
        {
            if (lstCustomers.SelectedItems.Count <= 0)
            {
                MessageBox.Show("please select a customer");
                return false;
            }
            return true;
        }
        private Customer GetCustomer()
        {
            Customer customer = customerController.FindCustomerByID(lstCustomers.SelectedItem.ToString());
            return customer;
        }

        private void bntAccounts_Click(object sender, EventArgs e)
        {
            // get customer send to accounts form
            Customer customer = GetCustomer();
            this.Hide();
            ManageAccount manageAccount = new ManageAccount(customer);
            manageAccount.StartPosition = FormStartPosition.Manual;
            manageAccount.Location = this.Location;
            manageAccount.ShowDialog();
            this.Close();
        }
    }
}

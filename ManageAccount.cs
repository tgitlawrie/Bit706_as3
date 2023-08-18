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
    public partial class ManageAccount : ParentForm, IObserver
    {
        Customer customer;
        private List<Account> accounts;

        public ManageAccount(Customer customer)
        {
            InitializeComponent();
            accountsController.AttachObserver(this);
            this.customer = customer;
            lblCustID.Text = customer.ID.ToString();
            lblCustName.Text = customer.FirstName + " " + customer.LastName;
            Update();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            //make deposit
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            //display id number
            if (lstAccounts.SelectedValue != null) // check if there is an item selected
            {
                int id = (int)lstAccounts.SelectedValue; // get the id of the selected account
                Console.WriteLine(id); // print the id
            }
            else
            {
                Console.WriteLine("No account selected"); // print a message if there is no item selected
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            //transfer funds
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AccountCreate accountCreate = new AccountCreate(customer);
            accountCreate.StartPosition = FormStartPosition.CenterParent;
            accountCreate.Location = this.Location;
            accountCreate.ShowDialog();
            
        }

        //default of null so we can update the list on load
        public void Update(Account a = null)
        {

            lstAccounts.DataSource = null; // clear the previous data source
            accounts = accountsController.FindAccountByCustomer(customer.ID); // get the accounts for the customer
            lstAccounts.ValueMember = "ID"; // set the ValueMember to ID
            lstAccounts.DisplayMember = "Summary"; // set the DisplayMember to Summary
            lstAccounts.DataSource = accounts; // set the DataSource to the accounts collection
        }
    }
}

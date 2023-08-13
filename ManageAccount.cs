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
            //make withdrawal
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
            lstAccounts.Items.Clear();
            accounts = accountsController.FindAccountByCustomer(customer.ID);
            foreach(Account accounts in accounts)
            {
                string details = $"{accounts.ID} {accounts} ${accounts.Balance}";
                lstAccounts.Items.Add(details);
            }
        }
    }
}

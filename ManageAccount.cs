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
    public partial class ManageAccount : ParentForm
    {
        Customer customer;

        public ManageAccount(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            lblCustID.Text = customer.ID.ToString();
            lblCustName.Text = customer.FirstName + " " + customer.LastName;
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
            //create account
            //accountsController.CreateAccount();
        }
    }
}

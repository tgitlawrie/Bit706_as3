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
    public partial class TransactionForm : ParentForm
    {
        private Account account1;
        private string action;
        private int customerID;

        private List<Account> accounts;
        public TransactionForm(Account account1, string action)
        {
            InitializeComponent();
            this.account1 = account1;
            this.action = action;

            btnConfirm.Text = action;
            lblAccount1.Text = account1.Summary;


        }

        public TransactionForm(Account account1, string action, int customerId) : this(account1, action)
        {
            this.customerID = customerId;

            if (action == "Transfer")
            {
                lblTransfer.Visible = true;
                CBToAccount.Visible = true;

                accounts = accountsController.FindAccountByCustomer(customerID);

                //populates the combo box with ID as Value
                CBToAccount.ValueMember = "ID";
                CBToAccount.DisplayMember = "Summary";
                CBToAccount.DataSource = accounts;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public decimal GetAmount() // a method to return the amount
        {
            bool valid = decimal.TryParse(txtAmount.Text, out decimal amount);
            if (valid)
            {
                return amount;
            }
            else
            {
                throw new FailedTransactionException("Please enter a valid amount");
            }
        }

        public int GetToAccount()
        {

            Object selected = CBToAccount.SelectedValue;
            int toAccount = (int)selected;
            Console.WriteLine(toAccount);
            return toAccount;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount");
            }
        }
    }
}

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

            lstAccounts.SelectedIndexChanged += lstAccounts_SelectedIndexChanged;
        }

        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstAccounts.SelectedValue != null)
            {
                lstHistory.Items.Clear();
                int id = (int)lstAccounts.SelectedValue;
                Account account = accountsController.FindAccountById(id);
                foreach (string p in account.history)
                {
                    lstHistory.Items.Add(p);
                }
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {

            string action = "Deposit";
            //display id number
            if (lstAccounts.SelectedValue != null)
            {
                int id = (int)lstAccounts.SelectedValue;
                Account account = accountsController.FindAccountById(id);

                TransactionForm transactionForm = new TransactionForm(account, action);

                if (transactionForm.ShowDialog() == DialogResult.OK)
                {
                    decimal amount = transactionForm.GetAmount();
                    try
                    {
                        accountsController.Deposit(id, amount);
                    }
                    catch (FailedTransactionException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    Update();
                    MessageBox.Show($"{amount} has been Deposited to {account.Summary}");
                }
            }
            else
            {
                MessageBox.Show("Please Select an account");
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            string action = "Withdraw";
            //display id number
            if (lstAccounts.SelectedValue != null)
            {
                int id = (int)lstAccounts.SelectedValue;
                Account account = accountsController.FindAccountById(id);

                TransactionForm transactionForm = new TransactionForm(account, action);

                if (transactionForm.ShowDialog() == DialogResult.OK)
                {
                    decimal amount = transactionForm.GetAmount();
                    if (amount <= 0)
                    {
                        MessageBox.Show("Amount must be greater than 0");
                        return;
                    }
                    try
                    {
                        accountsController.Withdraw(id, amount);
                    }
                    catch (FailedTransactionException ex)
                    {
                        MessageBox.Show(ex.Message);
                        accountsController.ApplyFee(id);
                        Update();
                        return;
                    }
                    Update();
                    MessageBox.Show($"{amount} has been withdrawn from {account.Summary}");
                }
            }
            else
            {
                MessageBox.Show("Please Select an account");
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string action = "Transfer";
            if (lstAccounts.SelectedValue != null)
            {
                int id = (int)lstAccounts.SelectedValue;
                Account account = accountsController.FindAccountById(id);

                TransactionForm transactionForm = new TransactionForm(account, action, customer.ID);

                if (transactionForm.ShowDialog() == DialogResult.OK)
                {
                    decimal amount = transactionForm.GetAmount();
                    int toAccountId = transactionForm.GetToAccount();
                    try
                    {
                        accountsController.Transfer(id, toAccountId, amount);

                    }
                    catch (FailedTransactionException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    Update();
                    MessageBox.Show($"{amount} has been Transfered from {account.Summary}");
                }
            }
            else
            {
                MessageBox.Show("Please Select an account");
            }
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

            lstAccounts.DataSource = null;
            accounts = accountsController.FindAccountByCustomer(customer.ID);
            lstAccounts.ValueMember = "ID"; // set the ValueMember to ID
            lstAccounts.DisplayMember = "Summary"; // set the DisplayMember to Summary
            lstAccounts.DataSource = accounts; // set the DataSource to the accounts collection
        }

        private void btnInterest_Click_1(object sender, EventArgs e)
        {
            // do the fees
            foreach (Account account in accounts)
            {
                accountsController.AddInterest(account.ID);
            }
            Update();
        }
    }
}

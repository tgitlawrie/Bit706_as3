using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bit706_as2
{
    public partial class AccountCreate : ParentForm
    {
        private string everyday = "Everyday Account\nNo Interest\nNo Overdraft\nNo Fees";
        private string investment = "Investment Account\nInterest of 4% paid on all funds\nNo Overdraft\nFailed transaction fee of $10.00";
        private string Omni = "Omni Account\nInterest of 4% paid on Balances over $1000\nOverdraft of $1000 Permitted\nFailed transaction fee of $10.00";

        Customer Customer;
        
        private string AccountType = "Everyday"; //everyday is selected on form load
        
        public AccountCreate(Customer customer)
        {
            InitializeComponent();
            this.Customer = customer;
            lblCustomer.Text = customer.CustomerInfo();
            lblAccount.Text = everyday;
            radEveryday.CheckedChanged += new EventHandler(RadioButtonChanged);
            radInvestment.CheckedChanged += new EventHandler(RadioButtonChanged);
            radOmni.CheckedChanged += new EventHandler(RadioButtonChanged);
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            switch (radioButton.Name)
            {
                case "radEveryday":
                    lblAccount.Text = everyday;
                    AccountType = "Everyday";
                    break;
                case "radInvestment":
                    lblAccount.Text = investment;
                    AccountType = "Investment";
                    break;
                case "radOmni":
                    lblAccount.Text = Omni;
                    AccountType = "Omni";
                    break;
                default:
                    throw new Exception("No account is selected");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (!decimal.TryParse(txtBalance.Text, out decimal amount))
            {
                txtBalance.Text = "0.00";
                MessageBox.Show("Invalid balance entered, Please enter a valid currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(!accountsController.CreateAccount(AccountType, Customer, amount))
            {
                MessageBox.Show(accountsController.ErrorMessage);
                return;
            }
            MessageBox.Show($"{AccountType} Account for {Customer.CustomerInfo()} Created Successfully");
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Bit706_as2
{
    public partial class ParentForm : Form
    {
        protected static AccountsController accountsController = new AccountsController();
        protected static CustomerController customerController = new CustomerController(accountsController); //passing accounts controller to customer Controller
        public ParentForm()
        {
            InitializeComponent();
            //check if current form is MainForm and hide main menu button
            if (this.GetType() == typeof(MainForm))
            {
                btnMain.Visible = false;
            }
            else
            {
                btnMain.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            string message = "Are you sure you want to exit?";
            string title = "Confirm Close?";

            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                return;
            }

        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.StartPosition = FormStartPosition.Manual;
            mainForm.Location = this.Location;
            mainForm.ShowDialog();
            this.Close();
        }
    }
}

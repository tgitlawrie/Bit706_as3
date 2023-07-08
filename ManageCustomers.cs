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
    }
}

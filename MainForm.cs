﻿using System;
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
    public partial class MainForm : ParentForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.StartPosition = FormStartPosition.Manual;
            manageCustomers.Location = this.Location;
            manageCustomers.ShowDialog();
            this.Close();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            //load form for accounts
        }
    }
}

﻿namespace Bit706_as2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnManage = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManage
            // 
            this.btnManage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnManage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnManage.FlatAppearance.BorderSize = 2;
            this.btnManage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.btnManage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.Location = new System.Drawing.Point(152, 134);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(187, 77);
            this.btnManage.TabIndex = 2;
            this.btnManage.Text = "Manage Customers";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccounts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnAccounts.FlatAppearance.BorderSize = 2;
            this.btnAccounts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.btnAccounts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Location = new System.Drawing.Point(152, 217);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(187, 77);
            this.btnAccounts.TabIndex = 3;
            this.btnAccounts.Text = "Manage Accounts";
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnManage);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Controls.SetChildIndex(this.btnManage, 0);
            this.Controls.SetChildIndex(this.btnAccounts, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Button btnAccounts;
    }
}
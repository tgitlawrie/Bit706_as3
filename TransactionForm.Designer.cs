namespace Bit706_as2
{
    partial class TransactionForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblAccount1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.CBToAccount = new System.Windows.Forms.ComboBox();
            this.lblTransfer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnConfirm.FlatAppearance.BorderSize = 2;
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Location = new System.Drawing.Point(186, 294);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(116, 56);
            this.btnConfirm.TabIndex = 21;
            this.btnConfirm.Text = "Action";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblAccount1
            // 
            this.lblAccount1.AutoSize = true;
            this.lblAccount1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.lblAccount1.Location = new System.Drawing.Point(12, 70);
            this.lblAccount1.Name = "lblAccount1";
            this.lblAccount1.Size = new System.Drawing.Size(243, 28);
            this.lblAccount1.TabIndex = 22;
            this.lblAccount1.Text = "Account 1 Summary";
            this.lblAccount1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(308, 196);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(116, 20);
            this.txtAmount.TabIndex = 23;
            this.txtAmount.Text = "0.00";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.label2.Location = new System.Drawing.Point(182, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "Amount $";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(308, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 56);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CBToAccount
            // 
            this.CBToAccount.FormattingEnabled = true;
            this.CBToAccount.Location = new System.Drawing.Point(251, 248);
            this.CBToAccount.Name = "CBToAccount";
            this.CBToAccount.Size = new System.Drawing.Size(251, 21);
            this.CBToAccount.TabIndex = 26;
            this.CBToAccount.Visible = false;
            // 
            // lblTransfer
            // 
            this.lblTransfer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTransfer.AutoSize = true;
            this.lblTransfer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.lblTransfer.Location = new System.Drawing.Point(90, 241);
            this.lblTransfer.Name = "lblTransfer";
            this.lblTransfer.Size = new System.Drawing.Size(155, 28);
            this.lblTransfer.TabIndex = 27;
            this.lblTransfer.Text = "Transfer To:";
            this.lblTransfer.Visible = false;
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 450);
            this.Controls.Add(this.lblTransfer);
            this.Controls.Add(this.CBToAccount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAccount1);
            this.Controls.Add(this.btnConfirm);
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TransactionForm";
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.lblAccount1, 0);
            this.Controls.SetChildIndex(this.txtAmount, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.CBToAccount, 0);
            this.Controls.SetChildIndex(this.lblTransfer, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblAccount1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox CBToAccount;
        private System.Windows.Forms.Label lblTransfer;
    }
}
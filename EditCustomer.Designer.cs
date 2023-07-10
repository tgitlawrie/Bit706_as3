namespace Bit706_as2
{
    partial class EditCustomer
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
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblfname = new System.Windows.Forms.Label();
            this.txtEditLname = new System.Windows.Forms.TextBox();
            this.txtEditFname = new System.Windows.Forms.TextBox();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.lblAddTitle.Location = new System.Drawing.Point(174, 70);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(177, 28);
            this.lblAddTitle.TabIndex = 17;
            this.lblAddTitle.Text = "Edit Customer";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(89, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Last Name";
            // 
            // lblfname
            // 
            this.lblfname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblfname.AutoSize = true;
            this.lblfname.Font = new System.Drawing.Font("Arial", 12F);
            this.lblfname.Location = new System.Drawing.Point(88, 175);
            this.lblfname.Name = "lblfname";
            this.lblfname.Size = new System.Drawing.Size(85, 18);
            this.lblfname.TabIndex = 15;
            this.lblfname.Text = "First Name";
            // 
            // txtEditLname
            // 
            this.txtEditLname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEditLname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditLname.Location = new System.Drawing.Point(179, 207);
            this.txtEditLname.Name = "txtEditLname";
            this.txtEditLname.Size = new System.Drawing.Size(193, 26);
            this.txtEditLname.TabIndex = 14;
            // 
            // txtEditFname
            // 
            this.txtEditFname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEditFname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditFname.Location = new System.Drawing.Point(179, 172);
            this.txtEditFname.Name = "txtEditFname";
            this.txtEditFname.Size = new System.Drawing.Size(193, 26);
            this.txtEditFname.TabIndex = 13;
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnEditCancel.FlatAppearance.BorderSize = 2;
            this.btnEditCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.btnEditCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnEditCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCancel.Location = new System.Drawing.Point(256, 307);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(116, 56);
            this.btnEditCancel.TabIndex = 12;
            this.btnEditCancel.Text = "Cancel";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Click += new System.EventHandler(this.btnEditCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(66)))), ((int)(((byte)(242)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(134, 307);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 56);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update Customer";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // EditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.lblAddTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblfname);
            this.Controls.Add(this.txtEditLname);
            this.Controls.Add(this.txtEditFname);
            this.Controls.Add(this.btnEditCancel);
            this.Controls.Add(this.btnUpdate);
            this.Name = "EditCustomer";
            this.Text = "EditCustomer";
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnEditCancel, 0);
            this.Controls.SetChildIndex(this.txtEditFname, 0);
            this.Controls.SetChildIndex(this.txtEditLname, 0);
            this.Controls.SetChildIndex(this.lblfname, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblAddTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblfname;
        private System.Windows.Forms.TextBox txtEditLname;
        private System.Windows.Forms.TextBox txtEditFname;
        private System.Windows.Forms.Button btnEditCancel;
        private System.Windows.Forms.Button btnUpdate;
    }
}
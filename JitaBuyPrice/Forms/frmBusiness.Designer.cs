namespace JitaBuyPrice.Forms
{
    partial class frmBusiness
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
            this.lvBase = new System.Windows.Forms.ListView();
            this.lvLower = new System.Windows.Forms.ListView();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lvResult = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvBase
            // 
            this.lvBase.AllowColumnReorder = true;
            this.lvBase.FullRowSelect = true;
            this.lvBase.Location = new System.Drawing.Point(12, 12);
            this.lvBase.Name = "lvBase";
            this.lvBase.Size = new System.Drawing.Size(210, 150);
            this.lvBase.TabIndex = 5;
            this.lvBase.UseCompatibleStateImageBehavior = false;
            this.lvBase.View = System.Windows.Forms.View.Details;
            // 
            // lvLower
            // 
            this.lvLower.AllowColumnReorder = true;
            this.lvLower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvLower.FullRowSelect = true;
            this.lvLower.Location = new System.Drawing.Point(12, 168);
            this.lvLower.Name = "lvLower";
            this.lvLower.Size = new System.Drawing.Size(470, 317);
            this.lvLower.TabIndex = 7;
            this.lvLower.UseCompatibleStateImageBehavior = false;
            this.lvLower.View = System.Windows.Forms.View.Details;
            this.lvLower.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvLower_ItemSelectionChanged);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(228, 16);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(41, 12);
            this.lblRate.TabIndex = 8;
            this.lblRate.Text = "化矿率";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(275, 13);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(36, 19);
            this.txtRate.TabIndex = 9;
            this.txtRate.Text = "78.2";
            // 
            // lvResult
            // 
            this.lvResult.AllowColumnReorder = true;
            this.lvResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvResult.FullRowSelect = true;
            this.lvResult.Location = new System.Drawing.Point(230, 38);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(161, 124);
            this.lvResult.TabIndex = 10;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            // 
            // frmBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 500);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lvLower);
            this.Controls.Add(this.lvBase);
            this.Name = "frmBusiness";
            this.Text = "frmBusiness";
            this.Load += new System.EventHandler(this.frmBusiness_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvBase;
        private System.Windows.Forms.ListView lvLower;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.ListView lvResult;
    }
}
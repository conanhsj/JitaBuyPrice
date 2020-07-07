namespace JitaBuyPrice.Forms
{
    partial class frmBrave
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
            this.lvResult = new System.Windows.Forms.ListView();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvResult
            // 
            this.lvResult.AllowColumnReorder = true;
            this.lvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResult.FullRowSelect = true;
            this.lvResult.Location = new System.Drawing.Point(12, 42);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(651, 380);
            this.lvResult.TabIndex = 1;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 12);
            this.lblResult.TabIndex = 2;
            // 
            // frmBrave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 434);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lvResult);
            this.Name = "frmBrave";
            this.Text = "frmBrave";
            this.Load += new System.EventHandler(this.frmBrave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.Label lblResult;
    }
}
namespace JitaBuyPrice.Forms
{
    partial class frmSalvage
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
            this.txtSalvage = new System.Windows.Forms.TextBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.lvBase = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtSalvage
            // 
            this.txtSalvage.Location = new System.Drawing.Point(12, 12);
            this.txtSalvage.Multiline = true;
            this.txtSalvage.Name = "txtSalvage";
            this.txtSalvage.Size = new System.Drawing.Size(139, 80);
            this.txtSalvage.TabIndex = 0;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(157, 12);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 1;
            this.btnBegin.Text = "分析";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // lvBase
            // 
            this.lvBase.AllowColumnReorder = true;
            this.lvBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvBase.FullRowSelect = true;
            this.lvBase.Location = new System.Drawing.Point(12, 98);
            this.lvBase.Name = "lvBase";
            this.lvBase.Size = new System.Drawing.Size(380, 439);
            this.lvBase.TabIndex = 5;
            this.lvBase.UseCompatibleStateImageBehavior = false;
            this.lvBase.View = System.Windows.Forms.View.Details;
            // 
            // frmSalvage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.lvBase);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.txtSalvage);
            this.Name = "frmSalvage";
            this.Text = "frmSalvage";
            this.Load += new System.EventHandler(this.frmSalvage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalvage;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.ListView lvBase;
    }
}
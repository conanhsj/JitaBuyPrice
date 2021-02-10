namespace JitaBuyPrice.Forms
{
    partial class frmT2Line
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblT2CopyRate = new System.Windows.Forms.Label();
            this.cmbT2Copy = new System.Windows.Forms.ComboBox();
            this.lvBase = new System.Windows.Forms.ListView();
            this.lvHigher = new System.Windows.Forms.ListView();
            this.lvLower = new System.Windows.Forms.ListView();
            this.lvMoon = new System.Windows.Forms.ListView();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtT2Rate = new System.Windows.Forms.TextBox();
            this.lblComRate = new System.Windows.Forms.Label();
            this.txtComRate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "读取";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblT2CopyRate
            // 
            this.lblT2CopyRate.AutoSize = true;
            this.lblT2CopyRate.Location = new System.Drawing.Point(232, 44);
            this.lblT2CopyRate.Name = "lblT2CopyRate";
            this.lblT2CopyRate.Size = new System.Drawing.Size(78, 12);
            this.lblT2CopyRate.TabIndex = 1;
            this.lblT2CopyRate.Text = "T2图材料效率";
            // 
            // cmbT2Copy
            // 
            this.cmbT2Copy.FormattingEnabled = true;
            this.cmbT2Copy.Location = new System.Drawing.Point(12, 41);
            this.cmbT2Copy.Name = "cmbT2Copy";
            this.cmbT2Copy.Size = new System.Drawing.Size(200, 20);
            this.cmbT2Copy.TabIndex = 3;
            this.cmbT2Copy.SelectedValueChanged += new System.EventHandler(this.cmbT2Copy_SelectedValueChanged);
            // 
            // lvBase
            // 
            this.lvBase.AllowColumnReorder = true;
            this.lvBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvBase.FullRowSelect = true;
            this.lvBase.Location = new System.Drawing.Point(12, 67);
            this.lvBase.Name = "lvBase";
            this.lvBase.Size = new System.Drawing.Size(200, 432);
            this.lvBase.TabIndex = 4;
            this.lvBase.UseCompatibleStateImageBehavior = false;
            this.lvBase.View = System.Windows.Forms.View.Details;
            // 
            // lvHigher
            // 
            this.lvHigher.AllowColumnReorder = true;
            this.lvHigher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvHigher.FullRowSelect = true;
            this.lvHigher.Location = new System.Drawing.Point(234, 67);
            this.lvHigher.Name = "lvHigher";
            this.lvHigher.Size = new System.Drawing.Size(230, 432);
            this.lvHigher.TabIndex = 5;
            this.lvHigher.UseCompatibleStateImageBehavior = false;
            this.lvHigher.View = System.Windows.Forms.View.Details;
            // 
            // lvLower
            // 
            this.lvLower.AllowColumnReorder = true;
            this.lvLower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvLower.FullRowSelect = true;
            this.lvLower.Location = new System.Drawing.Point(485, 67);
            this.lvLower.Name = "lvLower";
            this.lvLower.Size = new System.Drawing.Size(230, 432);
            this.lvLower.TabIndex = 6;
            this.lvLower.UseCompatibleStateImageBehavior = false;
            this.lvLower.View = System.Windows.Forms.View.Details;
            // 
            // lvMoon
            // 
            this.lvMoon.AllowColumnReorder = true;
            this.lvMoon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvMoon.FullRowSelect = true;
            this.lvMoon.Location = new System.Drawing.Point(738, 67);
            this.lvMoon.Name = "lvMoon";
            this.lvMoon.Size = new System.Drawing.Size(200, 432);
            this.lvMoon.TabIndex = 7;
            this.lvMoon.UseCompatibleStateImageBehavior = false;
            this.lvMoon.View = System.Windows.Forms.View.Details;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(863, 36);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 8;
            this.btnOutput.Text = "至剪贴板";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtT2Rate
            // 
            this.txtT2Rate.Location = new System.Drawing.Point(316, 41);
            this.txtT2Rate.Name = "txtT2Rate";
            this.txtT2Rate.Size = new System.Drawing.Size(29, 19);
            this.txtT2Rate.TabIndex = 9;
            this.txtT2Rate.Text = "2";
            // 
            // lblComRate
            // 
            this.lblComRate.AutoSize = true;
            this.lblComRate.Location = new System.Drawing.Point(389, 44);
            this.lblComRate.Name = "lblComRate";
            this.lblComRate.Size = new System.Drawing.Size(53, 12);
            this.lblComRate.TabIndex = 10;
            this.lblComRate.Text = "组件效率";
            // 
            // txtComRate
            // 
            this.txtComRate.Location = new System.Drawing.Point(460, 41);
            this.txtComRate.Name = "txtComRate";
            this.txtComRate.Size = new System.Drawing.Size(41, 19);
            this.txtComRate.TabIndex = 11;
            this.txtComRate.Text = "10";
            // 
            // frmT2Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 511);
            this.Controls.Add(this.txtComRate);
            this.Controls.Add(this.lblComRate);
            this.Controls.Add(this.txtT2Rate);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.lvMoon);
            this.Controls.Add(this.lvLower);
            this.Controls.Add(this.lvHigher);
            this.Controls.Add(this.lvBase);
            this.Controls.Add(this.cmbT2Copy);
            this.Controls.Add(this.lblT2CopyRate);
            this.Controls.Add(this.btnLoad);
            this.Name = "frmT2Line";
            this.Text = "frmT2Line";
            this.Load += new System.EventHandler(this.frmT2Line_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblT2CopyRate;
        private System.Windows.Forms.ComboBox cmbT2Copy;
        private System.Windows.Forms.ListView lvBase;
        private System.Windows.Forms.ListView lvHigher;
        private System.Windows.Forms.ListView lvLower;
        private System.Windows.Forms.ListView lvMoon;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox txtT2Rate;
        private System.Windows.Forms.Label lblComRate;
        private System.Windows.Forms.TextBox txtComRate;
    }
}
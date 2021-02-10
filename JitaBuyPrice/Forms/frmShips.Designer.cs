namespace JitaBuyPrice.Forms
{
    partial class frmShips
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
            this.btnGetID = new System.Windows.Forms.Button();
            this.btnGetBP = new System.Windows.Forms.Button();
            this.btnBPtoCode = new System.Windows.Forms.Button();
            this.btnRegionProduct = new System.Windows.Forms.Button();
            this.btnBuyBP = new System.Windows.Forms.Button();
            this.btnRecycle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetID
            // 
            this.btnGetID.Location = new System.Drawing.Point(12, 70);
            this.btnGetID.Name = "btnGetID";
            this.btnGetID.Size = new System.Drawing.Size(75, 23);
            this.btnGetID.TabIndex = 0;
            this.btnGetID.Text = "产物IDFix";
            this.btnGetID.UseVisualStyleBackColor = true;
            this.btnGetID.Click += new System.EventHandler(this.btnGetID_Click);
            // 
            // btnGetBP
            // 
            this.btnGetBP.Location = new System.Drawing.Point(12, 12);
            this.btnGetBP.Name = "btnGetBP";
            this.btnGetBP.Size = new System.Drawing.Size(75, 23);
            this.btnGetBP.TabIndex = 1;
            this.btnGetBP.Text = "BluePrint";
            this.btnGetBP.UseVisualStyleBackColor = true;
            this.btnGetBP.Click += new System.EventHandler(this.btnGetBP_Click);
            // 
            // btnBPtoCode
            // 
            this.btnBPtoCode.Location = new System.Drawing.Point(12, 41);
            this.btnBPtoCode.Name = "btnBPtoCode";
            this.btnBPtoCode.Size = new System.Drawing.Size(75, 23);
            this.btnBPtoCode.TabIndex = 2;
            this.btnBPtoCode.Text = "蓝图到产物";
            this.btnBPtoCode.UseVisualStyleBackColor = true;
            this.btnBPtoCode.Click += new System.EventHandler(this.btnBPtoCode_Click);
            // 
            // btnRegionProduct
            // 
            this.btnRegionProduct.Location = new System.Drawing.Point(12, 99);
            this.btnRegionProduct.Name = "btnRegionProduct";
            this.btnRegionProduct.Size = new System.Drawing.Size(75, 23);
            this.btnRegionProduct.TabIndex = 3;
            this.btnRegionProduct.Text = "星域补货";
            this.btnRegionProduct.UseVisualStyleBackColor = true;
            this.btnRegionProduct.Click += new System.EventHandler(this.btnRegionProduct_Click);
            // 
            // btnBuyBP
            // 
            this.btnBuyBP.Location = new System.Drawing.Point(12, 129);
            this.btnBuyBP.Name = "btnBuyBP";
            this.btnBuyBP.Size = new System.Drawing.Size(75, 23);
            this.btnBuyBP.TabIndex = 4;
            this.btnBuyBP.Text = "蓝图补缺";
            this.btnBuyBP.UseVisualStyleBackColor = true;
            this.btnBuyBP.Click += new System.EventHandler(this.btnBuyBP_Click);
            // 
            // btnRecycle
            // 
            this.btnRecycle.Location = new System.Drawing.Point(13, 159);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(75, 23);
            this.btnRecycle.TabIndex = 5;
            this.btnRecycle.Text = "采购回收";
            this.btnRecycle.UseVisualStyleBackColor = true;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // frmShips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 283);
            this.Controls.Add(this.btnRecycle);
            this.Controls.Add(this.btnBuyBP);
            this.Controls.Add(this.btnRegionProduct);
            this.Controls.Add(this.btnBPtoCode);
            this.Controls.Add(this.btnGetBP);
            this.Controls.Add(this.btnGetID);
            this.Name = "frmShips";
            this.Text = "frmShips";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetID;
        private System.Windows.Forms.Button btnGetBP;
        private System.Windows.Forms.Button btnBPtoCode;
        private System.Windows.Forms.Button btnRegionProduct;
        private System.Windows.Forms.Button btnBuyBP;
        private System.Windows.Forms.Button btnRecycle;
    }
}
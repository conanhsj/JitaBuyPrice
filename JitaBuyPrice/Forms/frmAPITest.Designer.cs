namespace JitaBuyPrice.Forms
{
    partial class frmAPITest
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
            this.btnZGJM = new System.Windows.Forms.Button();
            this.btnSetu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZGJM
            // 
            this.btnZGJM.Location = new System.Drawing.Point(13, 13);
            this.btnZGJM.Name = "btnZGJM";
            this.btnZGJM.Size = new System.Drawing.Size(75, 23);
            this.btnZGJM.TabIndex = 0;
            this.btnZGJM.Text = "抽签";
            this.btnZGJM.UseVisualStyleBackColor = true;
            this.btnZGJM.Click += new System.EventHandler(this.btnZGJM_Click);
            // 
            // btnSetu
            // 
            this.btnSetu.Location = new System.Drawing.Point(13, 42);
            this.btnSetu.Name = "btnSetu";
            this.btnSetu.Size = new System.Drawing.Size(75, 23);
            this.btnSetu.TabIndex = 1;
            this.btnSetu.Text = "色图";
            this.btnSetu.UseVisualStyleBackColor = true;
            this.btnSetu.Click += new System.EventHandler(this.btnSetu_Click);
            // 
            // frmAPITest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 215);
            this.Controls.Add(this.btnSetu);
            this.Controls.Add(this.btnZGJM);
            this.Name = "frmAPITest";
            this.Text = "frmAPITest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnZGJM;
        private System.Windows.Forms.Button btnSetu;
    }
}
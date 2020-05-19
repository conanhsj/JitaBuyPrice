namespace JitaBuyPrice
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnMyRoom = new System.Windows.Forms.Button();
            this.btnBrain = new System.Windows.Forms.Button();
            this.btnRecycle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(491, 356);
            this.txtInfo.TabIndex = 0;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(519, 345);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "计算";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(519, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(517, 53);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(53, 12);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "导入结果";
            // 
            // btnMyRoom
            // 
            this.btnMyRoom.Location = new System.Drawing.Point(519, 306);
            this.btnMyRoom.Name = "btnMyRoom";
            this.btnMyRoom.Size = new System.Drawing.Size(75, 23);
            this.btnMyRoom.TabIndex = 4;
            this.btnMyRoom.Text = "手工作坊";
            this.btnMyRoom.UseVisualStyleBackColor = true;
            this.btnMyRoom.Click += new System.EventHandler(this.btnMyRoom_Click);
            // 
            // btnBrain
            // 
            this.btnBrain.Location = new System.Drawing.Point(519, 78);
            this.btnBrain.Name = "btnBrain";
            this.btnBrain.Size = new System.Drawing.Size(75, 23);
            this.btnBrain.TabIndex = 5;
            this.btnBrain.Text = "脑浆价格";
            this.btnBrain.UseVisualStyleBackColor = true;
            this.btnBrain.Click += new System.EventHandler(this.btnBrain_Click);
            // 
            // btnRecycle
            // 
            this.btnRecycle.Location = new System.Drawing.Point(519, 108);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(75, 23);
            this.btnRecycle.TabIndex = 6;
            this.btnRecycle.Text = "化矿";
            this.btnRecycle.UseVisualStyleBackColor = true;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 393);
            this.Controls.Add(this.btnRecycle);
            this.Controls.Add(this.btnBrain);
            this.Controls.Add(this.btnMyRoom);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtInfo);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnMyRoom;
        private System.Windows.Forms.Button btnBrain;
        private System.Windows.Forms.Button btnRecycle;
    }
}


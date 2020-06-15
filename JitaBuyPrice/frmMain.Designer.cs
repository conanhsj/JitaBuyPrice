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
            this.btnDrone = new System.Windows.Forms.Button();
            this.btnT2High = new System.Windows.Forms.Button();
            this.btnT2Work = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(452, 148);
            this.txtInfo.TabIndex = 0;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(470, 12);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "计算";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 166);
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
            this.lblResult.Location = new System.Drawing.Point(12, 204);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(53, 12);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "导入结果";
            // 
            // btnMyRoom
            // 
            this.btnMyRoom.Location = new System.Drawing.Point(470, 70);
            this.btnMyRoom.Name = "btnMyRoom";
            this.btnMyRoom.Size = new System.Drawing.Size(75, 23);
            this.btnMyRoom.TabIndex = 4;
            this.btnMyRoom.Text = "手工作坊";
            this.btnMyRoom.UseVisualStyleBackColor = true;
            this.btnMyRoom.Click += new System.EventHandler(this.btnMyRoom_Click);
            // 
            // btnBrain
            // 
            this.btnBrain.Location = new System.Drawing.Point(174, 166);
            this.btnBrain.Name = "btnBrain";
            this.btnBrain.Size = new System.Drawing.Size(75, 23);
            this.btnBrain.TabIndex = 5;
            this.btnBrain.Text = "脑浆价格";
            this.btnBrain.UseVisualStyleBackColor = true;
            this.btnBrain.Click += new System.EventHandler(this.btnBrain_Click);
            // 
            // btnRecycle
            // 
            this.btnRecycle.Location = new System.Drawing.Point(470, 41);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(75, 23);
            this.btnRecycle.TabIndex = 6;
            this.btnRecycle.Text = "化矿";
            this.btnRecycle.UseVisualStyleBackColor = true;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // btnDrone
            // 
            this.btnDrone.Location = new System.Drawing.Point(93, 166);
            this.btnDrone.Name = "btnDrone";
            this.btnDrone.Size = new System.Drawing.Size(75, 23);
            this.btnDrone.TabIndex = 7;
            this.btnDrone.Text = "无人机语";
            this.btnDrone.UseVisualStyleBackColor = true;
            this.btnDrone.Click += new System.EventHandler(this.btnDrone_Click);
            // 
            // btnT2High
            // 
            this.btnT2High.Location = new System.Drawing.Point(470, 137);
            this.btnT2High.Name = "btnT2High";
            this.btnT2High.Size = new System.Drawing.Size(75, 23);
            this.btnT2High.TabIndex = 9;
            this.btnT2High.Text = "T2材料";
            this.btnT2High.UseVisualStyleBackColor = true;
            this.btnT2High.Click += new System.EventHandler(this.btnT2High_Click);
            // 
            // btnT2Work
            // 
            this.btnT2Work.Location = new System.Drawing.Point(470, 108);
            this.btnT2Work.Name = "btnT2Work";
            this.btnT2Work.Size = new System.Drawing.Size(75, 23);
            this.btnT2Work.TabIndex = 10;
            this.btnT2Work.Text = "T2制造";
            this.btnT2Work.UseVisualStyleBackColor = true;
            this.btnT2Work.Click += new System.EventHandler(this.btnT2Work_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 231);
            this.Controls.Add(this.btnT2Work);
            this.Controls.Add(this.btnT2High);
            this.Controls.Add(this.btnDrone);
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
        private System.Windows.Forms.Button btnDrone;
        private System.Windows.Forms.Button btnT2High;
        private System.Windows.Forms.Button btnT2Work;
    }
}


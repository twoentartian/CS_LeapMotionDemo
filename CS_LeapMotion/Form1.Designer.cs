namespace CS_LeapMotion
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.buttonCatch = new System.Windows.Forms.Button();
			this.textBoxConsole = new System.Windows.Forms.TextBox();
			this.timerCatch = new System.Windows.Forms.Timer(this.components);
			this.buttonAutoCatch = new System.Windows.Forms.Button();
			this.serialPort = new System.IO.Ports.SerialPort(this.components);
			this.buttonOpenClose = new System.Windows.Forms.Button();
			this.buttonFlash = new System.Windows.Forms.Button();
			this.comboBoxPortSelect = new System.Windows.Forms.ComboBox();
			this.textBoxSerial = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonCatch
			// 
			this.buttonCatch.Location = new System.Drawing.Point(12, 12);
			this.buttonCatch.Name = "buttonCatch";
			this.buttonCatch.Size = new System.Drawing.Size(75, 23);
			this.buttonCatch.TabIndex = 0;
			this.buttonCatch.Text = "Catch";
			this.buttonCatch.UseVisualStyleBackColor = true;
			this.buttonCatch.Click += new System.EventHandler(this.buttonCatch_Click);
			// 
			// textBoxConsole
			// 
			this.textBoxConsole.Location = new System.Drawing.Point(93, 12);
			this.textBoxConsole.Multiline = true;
			this.textBoxConsole.Name = "textBoxConsole";
			this.textBoxConsole.Size = new System.Drawing.Size(219, 282);
			this.textBoxConsole.TabIndex = 1;
			// 
			// timerCatch
			// 
			this.timerCatch.Interval = 500;
			this.timerCatch.Tick += new System.EventHandler(this.timerCatch_Tick);
			// 
			// buttonAutoCatch
			// 
			this.buttonAutoCatch.Location = new System.Drawing.Point(12, 41);
			this.buttonAutoCatch.Name = "buttonAutoCatch";
			this.buttonAutoCatch.Size = new System.Drawing.Size(75, 23);
			this.buttonAutoCatch.TabIndex = 2;
			this.buttonAutoCatch.Text = "Auto";
			this.buttonAutoCatch.UseVisualStyleBackColor = true;
			this.buttonAutoCatch.Click += new System.EventHandler(this.buttonAutoCatch_Click);
			// 
			// serialPort
			// 
			this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
			// 
			// buttonOpenClose
			// 
			this.buttonOpenClose.Location = new System.Drawing.Point(12, 242);
			this.buttonOpenClose.Name = "buttonOpenClose";
			this.buttonOpenClose.Size = new System.Drawing.Size(75, 23);
			this.buttonOpenClose.TabIndex = 3;
			this.buttonOpenClose.Text = "Open";
			this.buttonOpenClose.UseVisualStyleBackColor = true;
			this.buttonOpenClose.Click += new System.EventHandler(this.buttonOpenClose_Click);
			// 
			// buttonFlash
			// 
			this.buttonFlash.Location = new System.Drawing.Point(12, 271);
			this.buttonFlash.Name = "buttonFlash";
			this.buttonFlash.Size = new System.Drawing.Size(75, 23);
			this.buttonFlash.TabIndex = 4;
			this.buttonFlash.Text = "Flash";
			this.buttonFlash.UseVisualStyleBackColor = true;
			this.buttonFlash.Click += new System.EventHandler(this.buttonFlash_Click);
			// 
			// comboBoxPortSelect
			// 
			this.comboBoxPortSelect.FormattingEnabled = true;
			this.comboBoxPortSelect.Location = new System.Drawing.Point(12, 216);
			this.comboBoxPortSelect.Name = "comboBoxPortSelect";
			this.comboBoxPortSelect.Size = new System.Drawing.Size(75, 20);
			this.comboBoxPortSelect.TabIndex = 5;
			// 
			// textBoxSerial
			// 
			this.textBoxSerial.Location = new System.Drawing.Point(318, 14);
			this.textBoxSerial.Multiline = true;
			this.textBoxSerial.Name = "textBoxSerial";
			this.textBoxSerial.Size = new System.Drawing.Size(204, 280);
			this.textBoxSerial.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 306);
			this.Controls.Add(this.textBoxSerial);
			this.Controls.Add(this.comboBoxPortSelect);
			this.Controls.Add(this.buttonFlash);
			this.Controls.Add(this.buttonOpenClose);
			this.Controls.Add(this.buttonAutoCatch);
			this.Controls.Add(this.textBoxConsole);
			this.Controls.Add(this.buttonCatch);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCatch;
		private System.Windows.Forms.TextBox textBoxConsole;
		private System.Windows.Forms.Timer timerCatch;
		private System.Windows.Forms.Button buttonAutoCatch;
		private System.IO.Ports.SerialPort serialPort;
		private System.Windows.Forms.Button buttonOpenClose;
		private System.Windows.Forms.Button buttonFlash;
		private System.Windows.Forms.ComboBox comboBoxPortSelect;
		private System.Windows.Forms.TextBox textBoxSerial;
	}
}


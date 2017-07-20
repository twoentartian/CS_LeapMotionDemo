using System;
using System.IO.Ports;
using System.Windows.Forms;
using Leap;

namespace CS_LeapMotion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Controller targetController;

		#region Ports

		private void OpenClosePort()
		{
			if (State.Connection == false)
			{
				if (comboBoxPortSelect.SelectedIndex == -1)
				{
					MessageBox.Show("Please select the port", "Error");
					return;
				}
				try
				{
					Env.NowPort = comboBoxPortSelect.SelectedIndex;
					serialPort.PortName = Env.Ports[Env.NowPort];
					serialPort.Open();
				}
				catch (Exception argException)
				{
					MessageBox.Show(argException.Message, "Error");
					return;
				}
				State.Connection = true;
				this.Invoke((EventHandler)(delegate
				{
					buttonOpenClose.Text = "Close";
				}));

				char[] buffer = new char[3];
				buffer[0] = (char)50;
				buffer[1] = (char)50;
				buffer[2] = (char)0;
				if (serialPort.IsOpen)
				{
					serialPort.Write(buffer, 0, 3);
					textBoxConsole.AppendText("X" + 50.ToString() + Environment.NewLine);
					textBoxConsole.AppendText("Z" + 50.ToString() + Environment.NewLine);
				}
			}
			else
			{
				try
				{
					serialPort.Close();
				}
				catch (Exception argException)
				{
					MessageBox.Show(argException.Message, "Error");
					return;
				}
				State.Connection = false;
				this.Invoke((EventHandler)(delegate
				{
					buttonOpenClose.Text = "Open";
				}));
			}
		}

		private void FlashPorts()
		{
			Env.Ports = SerialPort.GetPortNames();
			Array.Sort(Env.Ports);
			comboBoxPortSelect.Items.Clear();
			comboBoxPortSelect.Items.AddRange(Env.Ports);
			if (Env.Ports.Length == 1)
			{
				comboBoxPortSelect.SelectedIndex = 0;
			}
		}
		#endregion

		private void Form1_Load(object sender, EventArgs e)
        {
			FlashPorts();
            try
            {
                targetController = new Controller();
            }
            catch (Exception argException)
            {
                MessageBox.Show(argException.Message);
            }
        }

        private void buttonCatch_Click(object sender, EventArgs e)
        {
			textBoxConsole.Clear();
            if (targetController == null)
            {
	            try
	            {
		            targetController = new Controller();
	            }
	            catch (Exception argException)
	            {
					MessageBox.Show(argException.Message);
					return;
				}
            }
	        if (targetController.IsConnected == false)
	        {
		        if (!Env.NoConnectionWarnSign)
		        {
					Env.NoConnectionWarnSign = true;
					DialogResult tempDialogResult = MessageBox.Show("No connection", "Error",MessageBoxButtons.RetryCancel);
					if (tempDialogResult == DialogResult.Retry)
					{
						Env.NoConnectionWarnSign = false;
					}
			        if (tempDialogResult == DialogResult.Cancel)
			        {
						Env.NoConnectionWarnSign = false;
						this.Invoke((EventHandler)(delegate
						{
							timerCatch.Enabled = !timerCatch.Enabled;
						}));
					}
				}
				return;
			}

            Frame tempFrame = targetController.Frame();
	        if (tempFrame.Hands.Count == 0)
	        {
				textBoxConsole.AppendText("No hands" + Environment.NewLine);
			}
	        else
	        {
				textBoxConsole.AppendText("Hands: " + tempFrame.Hands.Count.ToString() + Environment.NewLine);
			}
			float aveX = 0;
			float aveY = 0;
			float aveZ = 0;
	        for (int i = 0; i < tempFrame.Fingers.Count; i++)
	        {
				textBoxConsole.AppendText("Fingures " + i.ToString() + " x = " + tempFrame.Fingers[i].JointPosition(Finger.FingerJoint.JOINT_DIP).x.ToString() + Environment.NewLine);
				textBoxConsole.AppendText("Fingures " + i.ToString() + " y = " + tempFrame.Fingers[i].JointPosition(Finger.FingerJoint.JOINT_DIP).y.ToString() + Environment.NewLine);
				textBoxConsole.AppendText("Fingures " + i.ToString() + " z = " + tempFrame.Fingers[i].JointPosition(Finger.FingerJoint.JOINT_DIP).z.ToString() + Environment.NewLine);
				aveX += tempFrame.Fingers[i].JointPosition(Finger.FingerJoint.JOINT_DIP).x;
				aveY += tempFrame.Fingers[i].JointPosition(Finger.FingerJoint.JOINT_DIP).y;
				aveZ += tempFrame.Fingers[i].JointPosition(Finger.FingerJoint.JOINT_DIP).z;
			}

			int X = (int)((float)(aveX - Env.MinLoc) / (Env.MaxLoc - Env.MinLoc) * 100);
			if (X > 100) X = 99;
			if (X < 0) X = 1;
			int Y = (int)((float)(aveY - Env.MinLoc) / (Env.MaxLoc - Env.MinLoc) * 100);
			if (Y > 100) Y = 99;
			if (Y < 0) Y = 1;
			int Z = (int)((float)(aveZ - Env.MinLoc) / (Env.MaxLoc - Env.MinLoc) * 100);
			if (Z > 100) Z = 99;
			if (Z < 0) Z = 1;
			char[] buffer = new char[Env.SerialBufferLength];
			buffer[0] = (char)X;
	        buffer[1] = (char)Y;
			buffer[2] = (char)Z;
			buffer[3] = Env.EndSign;
			if (serialPort.IsOpen)
			{
				serialPort.Write(buffer,0,Env.SerialBufferLength);
				textBoxConsole.AppendText("X" + X + Environment.NewLine);
				textBoxConsole.AppendText("Y" + Y + Environment.NewLine);
				textBoxConsole.AppendText("Z" + Z + Environment.NewLine);
			}
		}

		private void timerCatch_Tick(object sender, EventArgs e)
		{
			buttonCatch_Click(sender, e);
		}

		private void buttonAutoCatch_Click(object sender, EventArgs e)
		{
			this.Invoke((EventHandler)(delegate
			{
				timerCatch.Enabled = !timerCatch.Enabled;
			}));
		}

		private void buttonOpenClose_Click(object sender, EventArgs e)
		{
			OpenClosePort();
		}

		private void buttonFlash_Click(object sender, EventArgs e)
		{
			FlashPorts();
		}

		private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			this.Invoke((EventHandler)(delegate
			{
				textBoxSerial.AppendText(serialPort.ReadLine() + Environment.NewLine);
			}));
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(serialPort.IsOpen)
			{
				MessageBox.Show("Please close serial port first !");
				e.Cancel = true;
			}
		}
	}
}

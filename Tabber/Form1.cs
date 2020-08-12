using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;


namespace Tabber
{

	public partial class Form1 : Form
	{
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		// Get a handle to an application window.
		[DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Activate an application window.
		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		bool running;
		DateTime startTime;
		DateTime LapTime;
		int counter = -1;


		Hotkey hotkeyConfig;

		public Form1()
		{
			hotkeyConfig = new Hotkey();
			hotkeyConfig.RegisterEscape(this.Handle);

			Application.ApplicationExit += HandleApplicationExit;

			InitializeComponent();

			intervalField.Value = Properties.Settings.Default.Interval;
			countdownField.Value = Properties.Settings.Default.ExecutionCount;
			startDelayField.Value = Properties.Settings.Default.StartDelay;
			hotkeyConfig.keycode = (Keys)Properties.Settings.Default.Hotkey;

			if (hotkeyConfig.keycode != 0)
			{
				RegisterHotkey();
			}
		}

		private void HandleApplicationExit(object sender, EventArgs e)
		{
			Properties.Settings.Default.Interval = intervalField.Value;
			Properties.Settings.Default.ExecutionCount = countdownField.Value;
			Properties.Settings.Default.StartDelay = startDelayField.Value;
			Properties.Settings.Default.Hotkey = (int)hotkeyConfig.keycode;
			Properties.Settings.Default.Save();
		}

		private void uiTimer_Tick(object sender, EventArgs e)
		{
			if (running)
			{
				var now = DateTime.Now;
				var lapInterval = now - LapTime;
				var totalTime = now - startTime;


				if (totalTime.TotalSeconds < 0)
				{
					toolStripStatusLabel1.Text = Math.Floor((totalTime.TotalMilliseconds / 1000)).ToString();
				}
				else
				{
					toolStripStatusLabel1.Text = lapInterval.TotalMilliseconds.ToString("000.0000");
					if ((decimal)lapInterval.TotalMilliseconds > intervalField.Value)
					{
						if (counter > 0)
						{
							counter--;
						}

						if (counter == 0)
						{
							Stop();
						}

						SendKeys.Send("%{TAB}");
						LapTime = now;
					}
				}
			}
		}

		private void action_Click(object sender, EventArgs e)
		{
			ToggleAction();
		}

		void ToggleAction()
		{

			if (!running)
			{
				// Enable!

				if (running)
					Stop();

				Start();
			}
			else
			{
				// Disable!

				Stop();
			}
		}

		void Start()
		{
#if DEBUG
			Console.WriteLine("Start");
#endif
			running = true;
			int seconds = (int)Math.Floor(startDelayField.Value);
			counter = (int)countdownField.Value;
			if (counter == 0)
				counter = -1;

			startTime = DateTime.Now.AddSeconds(seconds);
			LapTime = DateTime.Now;
			actionButton.Text = "Disable";
		}

		void Stop()
		{
#if DEBUG
			Console.WriteLine("Stop");
#endif
			running = false;
			actionButton.Text = "Enable";
			toolStripStatusLabel1.Text = "Ready";
		}



		bool readHotkey;

		private void handleKeyUp(object sender, KeyEventArgs e)
		{
			if (readHotkey)
			{
				readHotkey = false;
				RegisterHotkey();
			}
		}

		void RegisterHotkey()
		{
			if (hotkeyConfig.RegisterHotkey(this.Handle))
			{
				hotkeyLabel.Text = string.Format("Current Hotkey: {0}{1}{2}{3}",
					hotkeyConfig.alt ? "[Alt] " : string.Empty,
					hotkeyConfig.control ? "[Ctrl] " : string.Empty,
					hotkeyConfig.shift ? "[Shift] " : string.Empty,
					hotkeyConfig.keycode
					);
			}
		}

		private void handleKeyDown(object sender, KeyEventArgs e)
		{
			if (readHotkey)
			{
				uint code = (uint)e.KeyCode;

				hotkeyConfig.control = e.Control;
				hotkeyConfig.alt = e.Alt;
				hotkeyConfig.shift = e.Shift;
				hotkeyConfig.keycode = e.KeyCode;
			}

		}

		private void hotkeyButton_Click(object sender, EventArgs e)
		{
			readHotkey = true;
			hotkeyLabel.Text = "Press any key to register";
		}

		private void clearHotkeyButton_Click(object sender, EventArgs e)
		{
			UnregisterHotkey();
		}

		bool UnregisterHotkey()
		{
			var b = hotkeyConfig.UnregisterHotkey(this.Handle);
			if (b)
			{
				hotkeyLabel.Text = "Current Hotkey: None";
			}
			return b;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case (int)Hotkey.WM_HOTKEY:
					switch (m.WParam.ToInt32())
					{
						case 010844:
							ToggleAction();
							break;
						case 428465:
							Stop();
							break;
						default:
							break;
					}

					break;
			}
			base.WndProc(ref m);
		}
	}
}

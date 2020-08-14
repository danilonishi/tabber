using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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
		Screenshot screenshot;
		Rectangle screenshotRect;
		int screenshotBlinkSpeed;
		int screenshotBlinkCount;

		public Form1()
		{
			InitializeComponent();
			Application.ApplicationExit += HandleApplicationExit;

			var screens = Screen.AllScreens;
			screenSelector.Items.AddRange(screens.Select(_ => _.DeviceName.Substring(4)).ToArray());

			screenshot = new Screenshot();

			screenSelector.SelectedIndex = Math.Min(Properties.Settings.Default.SelectedScreen, screens.Length - 1);
			screenshotBlinkSpeed = Properties.Settings.Default.BlinkingSpeed;
			screenshotBlinkCount = Properties.Settings.Default.BlinkCount;
			intervalField.Value = Properties.Settings.Default.Interval;
			countdownField.Value = Properties.Settings.Default.ExecutionCount;
			startDelayField.Value = Properties.Settings.Default.StartDelay;

			hotkeyConfig = new Hotkey();

			KeyInformation tabberKey = new KeyInformation() { type = HotkeyType.Tabber };
			tabberKey.FromInt(Properties.Settings.Default.TabberKey, Keys.None);
			hotkeyConfig.RegisterHotkey(this.Handle, tabberKey);
			WriteHotkeyInfo(tabberHotkeyLabel, "Tabber", tabberKey);

			KeyInformation stopKey = new KeyInformation() { type = HotkeyType.Stop };
			stopKey.FromInt(Properties.Settings.Default.StopKey, Keys.Escape);
			hotkeyConfig.RegisterHotkey(this.Handle, stopKey);

			KeyInformation screenKeyInfo = new KeyInformation() { type = HotkeyType.Screenshot };
			screenKeyInfo.FromInt(Properties.Settings.Default.ScreenKey, Keys.None);
			hotkeyConfig.RegisterHotkey(this.Handle, screenKeyInfo);
			WriteHotkeyInfo(screenshotLabel, "Screen", screenKeyInfo);

		}

		private void HandleApplicationExit(object sender, EventArgs e)
		{
			Properties.Settings.Default.Interval = intervalField.Value;
			Properties.Settings.Default.ExecutionCount = countdownField.Value;
			Properties.Settings.Default.StartDelay = startDelayField.Value;
			Properties.Settings.Default.SelectedScreen = screenSelector.SelectedIndex;
			Properties.Settings.Default.BlinkingSpeed = screenshotBlinkSpeed;
			Properties.Settings.Default.BlinkCount = screenshotBlinkCount;

			if (hotkeyConfig.keyRegistration.ContainsKey(HotkeyType.Tabber))
				Properties.Settings.Default.TabberKey = hotkeyConfig.keyRegistration[HotkeyType.Tabber].ToInt();
			if (hotkeyConfig.keyRegistration.ContainsKey(HotkeyType.Stop))
				Properties.Settings.Default.StopKey = hotkeyConfig.keyRegistration[HotkeyType.Stop].ToInt();
			if (hotkeyConfig.keyRegistration.ContainsKey(HotkeyType.Screenshot))
				Properties.Settings.Default.ScreenKey = hotkeyConfig.keyRegistration[HotkeyType.Screenshot].ToInt();

			Properties.Settings.Default.Save();
		}

		//
		//
		// Tabber

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
				if (running)
					Stop();
				Start();
			}
			else
			{
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

		//
		//
		// Hotkey Handling

		bool readHotkey;

		KeyInformation currentKeyInfo;

		bool RegisterHotkey()
		{
			if (currentKeyInfo == null)
				throw new Exception("currentKeyInfo not initialized");

			return hotkeyConfig.RegisterHotkey(this.Handle, currentKeyInfo);
		}

		public void WriteHotkeyInfo(Label label, string target, KeyInformation info)
		{
			label.Text = string.Format("{4} Hotkey: {0}{1}{2}{3}",
								info.alt ? "[Alt] " : string.Empty,
								info.control ? "[Ctrl] " : string.Empty,
								info.shift ? "[Shift] " : string.Empty,
								info.keycode,
								target
								);
		}

		private void handleKeyDown(object sender, KeyEventArgs e)
		{
			if (readHotkey)
			{
				if (currentKeyInfo == null)
					throw new Exception("currentKeyInfo not initialized");

				currentKeyInfo.control = e.Control;
				currentKeyInfo.alt = e.Alt;
				currentKeyInfo.shift = e.Shift;
				currentKeyInfo.keycode = e.KeyCode;
			}
		}

		private void handleKeyUp(object sender, KeyEventArgs e)
		{
			if (readHotkey)
			{
				readHotkey = false;
				if (RegisterHotkey())
				{
					switch (currentKeyInfo.type)
					{
						case HotkeyType.Tabber:
							WriteHotkeyInfo(tabberHotkeyLabel, "Tabber", currentKeyInfo);
							break;
						case HotkeyType.Screenshot:
							WriteHotkeyInfo(screenshotLabel, "Screen", currentKeyInfo);
							break;
						case HotkeyType.Stop:
						default:
							break;
					}
				}
			}
		}

		bool UnregisterHotkey(HotkeyType type)
		{
			return hotkeyConfig.UnregisterHotkey(this.Handle, type);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case (int)KeyInformation.WM_HOTKEY:
					switch (m.WParam.ToInt32())
					{
						case (int)HotkeyType.Tabber:
							ToggleAction();
							break;
						case (int)HotkeyType.Stop:
							Stop();
							break;
						case (int)HotkeyType.Screenshot:
							TakeScreenshot();
							break;
						default:
							break;
					}

					break;
			}
			base.WndProc(ref m);
		}

		//
		//
		// Screen Capture

		private void TakeScreenshot()
		{
			if (readHotkey)
				return;

			DirectBitmap dbmp1 = new DirectBitmap(screenshotRect.Width, screenshotRect.Height);
			DirectBitmap dbmp2 = new DirectBitmap(screenshotRect.Width, screenshotRect.Height);
			DirectBitmap dresult1 = new DirectBitmap(screenshotRect.Width, screenshotRect.Height);
			DirectBitmap dresult2 = new DirectBitmap(screenshotRect.Width, screenshotRect.Height);

			screenshot.GrabScreenPortion(screenshotRect, ref dbmp1.Bitmap);
			//Thread.Sleep(60);
			SendKeys.Send("%{TAB}");
			Thread.Sleep(100);
			screenshot.GrabScreenPortion(screenshotRect, ref dbmp2.Bitmap);
			SendKeys.Send("%{TAB}");

			BitmapComparer comp = new BitmapComparer();

			if (!comp.GetDifferenceBitmapPair(dbmp1, dbmp2, Color.Red, ref dresult1, ref dresult2))
				return;

			PerPixelAlphaForm compareForm = new PerPixelAlphaForm();
			compareForm.StartPosition = FormStartPosition.Manual;
			compareForm.DesktopLocation = new Point(screenshotRect.X, screenshotRect.Y);
			compareForm.SetDesktopLocation(screenshotRect.X, screenshotRect.Y);
			compareForm.Size = new Size(screenshotRect.Width, screenshotRect.Height);
			compareForm.Show();

			for (int i = 0; i < screenshotBlinkCount; i++)
			{
				compareForm.SelectBitmap(dresult2.Bitmap);
				Thread.Sleep(screenshotBlinkSpeed);
				compareForm.SelectBitmap(dresult1.Bitmap);
				Thread.Sleep(screenshotBlinkSpeed);
			}
			compareForm.Hide();
			compareForm.Dispose();

			//Thread.Sleep(100);
			//this.BringToFront();
			//this.Activate();

			dbmp1.Dispose();
			dbmp2.Dispose();
			dresult1.Dispose();
			dresult2.Dispose();

		}

		private void handleDisplayChange(object sender, EventArgs e)
		{
			SetCaptureBounds((sender as ComboBox).SelectedIndex);
		}

		private void SetCaptureBounds(int screenIndex)
		{
			screenshotRect = Screen.AllScreens[screenIndex].Bounds;
		}

		//
		//
		// UI Callback

		private void blinkCount_ValueChanged(object sender, EventArgs e)
		{
			this.screenshotBlinkCount = (int)(sender as NumericUpDown).Value;
		}

		private void blinkingNumber_ValueChanged(object sender, EventArgs e)
		{
			this.screenshotBlinkSpeed = (int)(sender as NumericUpDown).Value;
		}

		private void setTabberHotkeyBtn_Click(object sender, EventArgs e)
		{
			currentKeyInfo = new KeyInformation();
			currentKeyInfo.type = HotkeyType.Tabber;
			tabberHotkeyLabel.Text = "Press any key to register";
			readHotkey = true;
		}

		private void clearTabberHotkeyBtn_Click(object sender, EventArgs e)
		{
			if (UnregisterHotkey(HotkeyType.Tabber))
			{
				tabberHotkeyLabel.Text = "Tabber Hotkey: None";
			}
		}

		private void setScreenshotHotkeyBtn_Click(object sender, EventArgs e)
		{
			currentKeyInfo = new KeyInformation();
			currentKeyInfo.type = HotkeyType.Screenshot;
			screenshotLabel.Text = "Press any key to register";
			readHotkey = true;
		}

		private void clearScreenshotHotkeyBtn_Click(object sender, EventArgs e)
		{
			if (UnregisterHotkey(HotkeyType.Screenshot))
			{
				screenshotLabel.Text = "Current Hotkey: None";
			}
		}
	}
}

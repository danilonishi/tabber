using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tabber
{
	public struct Hotkey
	{
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("user32")]
		public static extern bool GetMessage(ref Message lpMsg, IntPtr handle, uint mMsgFilterInMain, uint mMsgFilterMax);

		[DllImport("user32.dll")]
		public static extern bool RegisterHotKey(IntPtr windowHandle, int hotkeyId, uint modifierKeys, uint virtualKey);

		[DllImport("user32.dll")]
		public static extern bool UnregisterHotKey(IntPtr windowHandle, int hotkeyId);

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


		// Modifiers
		public const uint MOD_ALT = 0x0001;
		public const uint MOD_CONTROL = 0x0002;
		public const uint MOD_SHIFT = 0x004;
		public const uint MOD_WIN = 0x0008;
		// Options
		public const uint MOD_NOREPEAT = 0x4000;
		// Callback
		public const uint WM_HOTKEY = 0x312;

		private bool isRegistered;
		public bool alt, shift, control, win;
		public Keys keycode;
		Message keypressMessage;

		public uint ToInt()
		{
			uint value = (uint)keycode | GetModifiers();
			return value;
		}

		public uint GetModifiers()
		{
			uint value = 0;
			value |= alt ? MOD_ALT : 0;
			value |= shift ? MOD_SHIFT : 0;
			value |= control ? MOD_CONTROL : 0;
			value |= win ? MOD_WIN : 0;
			return value;
		}

		public void RegisterEscape(IntPtr hWnd)
		{
			RegisterHotKey(hWnd, 428465, 0, 27); // Register "Escape" as stop key
			Console.WriteLine("\"Escape\" Registration: " + (isRegistered ? "Success" : "Failed"));
		}

		public bool RegisterHotkey(IntPtr hWnd)
		{
			if (isRegistered)
			{
				if (!this.UnregisterHotkey(hWnd))
				{
					Console.WriteLine("Halt");
					return false;
				}
			}

			isRegistered = RegisterHotKey(hWnd, 010844, GetModifiers(), (uint)keycode); // Register user hotkey
			Console.WriteLine("Hotkey Registration: " + (isRegistered ? "Success" : "Failed"));

			if (!isRegistered)
				return false;

			if (keypressMessage == null)
				keypressMessage = new Message();

			return true;
		}

		public bool UnregisterHotkey(IntPtr hWnd)
		{
			bool successufllyUnregistered = UnregisterHotKey(hWnd, 010844);

			if (successufllyUnregistered)
			{
				isRegistered = false;
				//alt = shift = control = false;
				//keycode = Keys.None;
				Console.WriteLine("Hotkey successfully unregistered.");
				return true;
			}
			else
			{
				Console.WriteLine("Failed to unregister Hotkey");
				return false;
			}
		}
	}
}

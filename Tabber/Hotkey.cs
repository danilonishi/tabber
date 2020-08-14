using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tabber
{

	public partial struct Hotkey
	{
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[DllImport("user32")]
		public static extern bool GetMessage(ref Message lpMsg, IntPtr handle, uint mMsgFilterInMain, uint mMsgFilterMax);

		[DllImport("user32.dll")]
		public static extern bool RegisterHotKey(IntPtr windowHandle, int hotkeyId, uint modifierKeys, uint virtualKey);

		[DllImport("user32.dll")]
		public static extern bool UnregisterHotKey(IntPtr windowHandle, int hotkeyId);

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		Message keypressMessage;

		Dictionary<HotkeyType, KeyInformation> _keyRegistration;
		Dictionary<HotkeyType, bool> _statusRegistration;

		public Dictionary<HotkeyType, KeyInformation> keyRegistration
		{
			get
			{
				if (_keyRegistration == null)
				{
					_keyRegistration = new Dictionary<HotkeyType, KeyInformation>();
				}
				return _keyRegistration;
			}
		}

		public Dictionary<HotkeyType, bool> statusRegistration
		{
			get
			{
				if (_statusRegistration == null)
				{
					_statusRegistration = new Dictionary<HotkeyType, bool>();
				}
				return _statusRegistration;
			}
		}

		public bool RegisterHotkey(IntPtr hWnd, KeyInformation keyInfo)
		{
			
			if (statusRegistration.ContainsKey(keyInfo.type) && statusRegistration[keyInfo.type])
			{
				if (!this.UnregisterHotkey(hWnd, keyInfo.type))
				{
					Console.WriteLine("Halt");
					return false;
				}
			}

			// Register user hotkey
			statusRegistration[keyInfo.type] = RegisterHotKey(hWnd, (int)keyInfo.type, keyInfo.GetModifiers(), (uint)keyInfo.keycode);
			keyRegistration[keyInfo.type] = keyInfo;
			Console.WriteLine("Hotkey Registration: " + (statusRegistration.ContainsKey(keyInfo.type) ? "Success" : "Failed"));

			if (!statusRegistration.ContainsKey(keyInfo.type))
				return false;

			if (keypressMessage == null)
				keypressMessage = new Message();

			return true;
		}

		public bool UnregisterHotkey(IntPtr hWnd, HotkeyType type)
		{
			if (UnregisterHotKey(hWnd, (int)type))
			{
				keyRegistration[type].Clear();
				statusRegistration[type] = false;
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

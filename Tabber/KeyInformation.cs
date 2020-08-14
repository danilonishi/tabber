using System.Windows.Forms;

namespace Tabber
{
	public class KeyInformation
	{
		// Modifiers
		public const uint MOD_ALT = 0x0001;
		public const uint MOD_CONTROL = 0x0002;
		public const uint MOD_SHIFT = 0x004;
		// Options
		public const uint MOD_NOREPEAT = 0x4000;
		// Callback
		public const uint WM_HOTKEY = 0x312;

		// Variables
		public bool control;
		public bool alt;
		public bool shift;
		public Keys keycode;
		public HotkeyType type;

		/// <summary>
		/// Fill control, shift, alt and keycode from packed <see cref="System.Int32"/>.
		/// </summary>
		/// <param name="value">The packed <see cref="System.Int32"/> to be unpacked into this object.</param>
		/// <param name="defaultValue">Value to be assigned to the <see cref="keycode"/> in case value is zero</param>
		public void FromInt(int value, Keys defaultValue = Keys.None)
		{
			if (value == 0)
			{
				keycode = defaultValue;
			}
			else
			{
				if ((value & (int)Keys.Control) != 0)
					control = true;
				if ((value & (int)Keys.Shift) != 0)
					shift = true;
				if ((value & (int)Keys.Alt) != 0)
					alt = true;
				keycode = (Keys)(value & ~(int)Keys.Control & ~(int)Keys.Alt & ~(int)Keys.Shift);
			}
		}

		/// <summary>
		/// Packs the <see cref="keycode"/>, <see cref="alt"/>, <see cref="control"/> and <see cref="shift"/> information into an <see cref="System.Int32"/>.
		/// </summary>
		/// <returns>A packed <see cref="System.Int32"/></returns>
		public int ToInt()
		{
			int key = (int)keycode;
			if (alt)
				key |= (int)Keys.Alt;
			if (control)
				key |= (int)Keys.Control;
			if (shift)
				key |= (int)Keys.Shift;
			return key;
		}

		/// <summary>
		/// Packs the modifiers into an <see cref="System.Int32"/>
		/// </summary>
		/// <returns>The packed <see cref="System.Int32"/> containing the <see cref="alt"/>, <see cref="control"/> and <see cref="shift"/> modifiers.</returns>
		public uint GetModifiers()
		{
			uint value = 0;
			value |= alt ? MOD_ALT : 0;
			value |= shift ? MOD_SHIFT : 0;
			value |= control ? MOD_CONTROL : 0;
			return value;
		}

		/// <summary>
		/// Clears the keycode and modifiers
		/// </summary>
		internal void Clear()
		{
			keycode = Keys.None;
			alt = shift = control = false;
		}
	}
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Tabber
{

	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;        // x position of upper-left corner
		public int Top;         // y position of upper-left corner
		public int Right;       // x position of lower-right corner
		public int Bottom;      // y position of lower-right corner
	}


	/// <summary>
	/// Handles Screenshots
	/// Adapted from https://stackoverflow.com/questions/891345/get-a-screenshot-of-a-specific-application
	/// Apparently not compatible with Windows Vista.
	/// </summary>
	public class Screenshot
	{
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

		public Bitmap GrabApplication(string process)
		{
			var proc = Process.GetProcessesByName(process)[0];
			GetWindowRect(proc.MainWindowHandle, out RECT rect);

			int width = rect.Right - rect.Left;
			int height = rect.Bottom - rect.Top;

			var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			using (Graphics graphics = Graphics.FromImage(bmp))
			{
				graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
			}

			return bmp;

			/*
			// DEBUG
			string path = "C:/temp";
			string fullpath = $"{path}/file.png";

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			if (File.Exists(fullpath))
			{
				File.Delete(fullpath);
			}

			bmp.Save(fullpath, ImageFormat.Png);
			*/
		}

		/*
		public Bitmap GrabScreenPortion(Rectangle rect)
		{
			Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(bmp);
			g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
			return bmp;
		}
		/**/

		public void GrabScreenPortion(Rectangle rect, ref Bitmap screenGrab)
		{
			Graphics g = Graphics.FromImage(screenGrab);
			g.CopyFromScreen(rect.Left, rect.Top, 0, 0, screenGrab.Size, CopyPixelOperation.SourceCopy);
		}

	}
}

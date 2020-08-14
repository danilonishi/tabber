using System.Runtime.InteropServices;
using System.Drawing;
using System;
using System.Threading;

namespace Tabber
{
	public class ScreenDrawing
	{
		[DllImport("User32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
		[DllImport("User32.dll")]
		public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

		public void Reduce(ref Rectangle r, int p = 1)
		{
			r.X += p;
			r.Y += p;
			r.Width -= 2 * p;
			r.Height -= 2 * p;
		}

		public void PlotRect(int x, int y, int width, int height, SolidBrush brush, int thickness = 1)
		{
			IntPtr desktopPtr = GetDC(IntPtr.Zero);
			Graphics g = Graphics.FromHdc(desktopPtr);

			Rectangle top = new Rectangle(x, y, width, thickness);
			Rectangle bottom = new Rectangle(x, y + height, width, thickness);
			Rectangle left = new Rectangle(x, y, thickness, height);
			Rectangle right = new Rectangle(x + width, y, thickness, height);

			g.FillRectangle(brush, top);
			g.FillRectangle(brush, bottom);
			g.FillRectangle(brush, left);
			g.FillRectangle(brush, right);

			g.Dispose();
			ReleaseDC(IntPtr.Zero, desktopPtr);
		}

		public void TestPlot(Rectangle rect, int thickness = 1)
		{
			SolidBrush white = new SolidBrush(Color.White);
			SolidBrush red = new SolidBrush(Color.Red);

			Rectangle baseRectangle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
			PlotRect(baseRectangle.X, baseRectangle.Y, baseRectangle.Width, baseRectangle.Height, red, thickness);
			Reduce(ref baseRectangle, thickness);
			PlotRect(baseRectangle.X, baseRectangle.Y, baseRectangle.Width, baseRectangle.Height, white, thickness);
			Reduce(ref baseRectangle, thickness);
			PlotRect(baseRectangle.X, baseRectangle.Y, baseRectangle.Width, baseRectangle.Height, red, thickness);
			Reduce(ref baseRectangle, thickness);
			PlotRect(baseRectangle.X, baseRectangle.Y, baseRectangle.Width, baseRectangle.Height, white, thickness);
		}




	}
}

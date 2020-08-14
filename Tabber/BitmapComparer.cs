using System.Drawing;

namespace Tabber
{
	public class BitmapComparer
	{
		// From https://stackoverflow.com/questions/24407410/how-to-get-difference-between-2-images-and-save-it-to-an-image
		public Bitmap GetDifferencBitmap(Bitmap bmp1, Bitmap bmp2, Color diffColor)
		{
			Size s1 = bmp1.Size;
			Size s2 = bmp2.Size;
			if (s1 != s2) return null;

			Bitmap bmp3 = new Bitmap(s1.Width, s1.Height);
			Color black = Color.Black;

			for (int y = 0; y < s1.Height; y++)
				for (int x = 0; x < s1.Width; x++)
				{
					Color c1 = bmp1.GetPixel(x, y);
					Color c2 = bmp2.GetPixel(x, y);
					if (c1 == c2) bmp3.SetPixel(x, y, black); //bmp3.SetPixel(x, y, c1);
					else bmp3.SetPixel(x, y, diffColor);
				}

			bmp3.MakeTransparent(black);

			return bmp3;
		}

		Color black = Color.Black;

		public bool GetDifferenceBitmapPair(DirectBitmap bmp1, DirectBitmap bmp2, Color diffColor, ref DirectBitmap out1, ref DirectBitmap out2)
		{
			Size s1 = bmp1.Bitmap.Size;
			Size s2 = bmp2.Bitmap.Size;
			if (s1 != s2)
			{
				out1 = out2 = null;
				return false;
			}

			Color blinkColor = Color.FromArgb(255 - diffColor.R, 255 - diffColor.G, 255 - diffColor.B);

			for (int y = 0; y < s1.Height; y++)
				for (int x = 0; x < s1.Width; x++)
				{
					Color c1 = bmp1.GetPixel(x, y);
					Color c2 = bmp2.GetPixel(x, y);
					if (c1 == c2)
					{
						out1.SetPixel(x, y, black);
						out2.SetPixel(x, y, black);
					}
					else
					{
						if (c1.R >= c2.R)
						{
							out1.SetPixel(x, y, diffColor);
							out2.SetPixel(x, y, blinkColor);
						}
						else
						{
							out1.SetPixel(x, y, blinkColor);
							out2.SetPixel(x, y, diffColor);
						}
						
					}
				}

			out1.Bitmap.MakeTransparent(black);
			out2.Bitmap.MakeTransparent(black);

			return true;
		}

	}
}

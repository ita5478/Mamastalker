using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mamastalker.Server.BL.ScreenShotTaking;

namespace Mamastalker.Server.BL.ScreenShotTaking
{
    public class ScreenshotCapture : IScreenshotCapturer
    {
        private ImageConverter _imageConverter;

        public ScreenshotCapture()
        {
            _imageConverter = new ImageConverter();

        }

        public byte[] Capture()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                return (byte[]) _imageConverter.ConvertTo(bitmap, typeof(byte[]));
            }
        }
    }
}

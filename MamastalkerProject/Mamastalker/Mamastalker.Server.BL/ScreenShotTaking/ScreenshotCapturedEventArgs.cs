using System;
using System.Collections.Generic;
using System.Text;

namespace Mamastalker.Server.BL.ScreenShotTaking
{
    public class ScreenshotCapturedEventArgs : EventArgs
    {
        public readonly DateTime CaptureTime;

        public readonly byte[] ImageBytes;

        public ScreenshotCapturedEventArgs(DateTime captureTime, byte[] imageBytes)
        {
            ImageBytes = imageBytes;
            CaptureTime = captureTime;
        }
    }
}

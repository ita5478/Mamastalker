using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mamastalker.Server.BL.ScreenShotTaking
{
    public interface IScreenshotCapturer
    {
        byte[] Capture();
    }
}

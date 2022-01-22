using System;
using System.Collections.Generic;
using System.Text;

namespace Mamastalker.Server.BL.DTOs
{
    [Serializable]
    public class ScreenshotInfo
    {
        public byte[] ImageBytes { get; set; }

        public DateTime CaptureTime { get; set; }
    }
}

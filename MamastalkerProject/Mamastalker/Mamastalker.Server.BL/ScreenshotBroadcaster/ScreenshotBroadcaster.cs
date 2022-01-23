using Mamastalker.Server.BL.Broadcasting;
using Mamastalker.Server.BL.ScreenShotTaking;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace Mamastalker.Server.BL.ScreenshotBroadcaster
{
    public class ScreenshotBroadcaster : IBroadcaster
    {
        private delegate void NotifySubscribersCallback(ScreenshotCapturedEventArgs eventArgs);
        private event NotifySubscribersCallback _notifySubscribersEvent;

        private CancellationToken _broadcastCancellationToken;
        private IScreenshotCapturer _screenshotCapturer;
        private int _broadcastIntervals;

        public ScreenshotBroadcaster(CancellationToken broadcastCancellationToken, IScreenshotCapturer screenshotCapturer, int broadcastIntervals)
        {
            _broadcastCancellationToken = broadcastCancellationToken;
            _screenshotCapturer = screenshotCapturer;
            _broadcastIntervals = broadcastIntervals;
        }

        public async Task Broadcast()
        {
            while (!_broadcastCancellationToken.IsCancellationRequested)
            {
                await Task.Delay(_broadcastIntervals);

                if((_notifySubscribersEvent?.GetInvocationList().Length ?? 0) > 1)
                {
                    var imageBytes = _screenshotCapturer.Capture();

                    _notifySubscribersEvent.Invoke(new ScreenshotCapturedEventArgs(DateTime.Now, imageBytes));
                }
            }
        }

        public void Subscribe(IBroadcastSubscriber subscriber)
        {
            _notifySubscribersEvent += subscriber.Notify;
        }
    }
}

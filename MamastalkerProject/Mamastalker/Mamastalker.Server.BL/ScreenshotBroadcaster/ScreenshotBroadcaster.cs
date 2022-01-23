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

        private IScreenshotCapturer _screenshotCapturer;
        private int _broadcastIntervals;

        public ScreenshotBroadcaster(IScreenshotCapturer screenshotCapturer, int broadcastIntervals)
        {
            _screenshotCapturer = screenshotCapturer;
            _broadcastIntervals = broadcastIntervals;
        }

        public async Task Broadcast(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
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

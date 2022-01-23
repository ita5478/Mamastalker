using System;
using System.Collections.Generic;
using System.Text;

namespace Mamastalker.Server.BL.Broadcasting
{
    public interface IBroadcastSubscriber
    {
        void Notify(EventArgs eventArgs);
    }
}

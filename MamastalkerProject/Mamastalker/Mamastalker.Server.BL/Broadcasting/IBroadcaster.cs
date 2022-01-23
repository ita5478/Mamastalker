using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mamastalker.Server.BL.Broadcasting
{
    public interface IBroadcaster
    {
        void Subscribe(IBroadcastSubscriber subscriber);

        Task Broadcast();
    }
}

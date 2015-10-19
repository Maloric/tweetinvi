using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Examplinvi.Web.Hubs;
using Microsoft.AspNet.SignalR;
using Tweetinvi;

namespace Examplinvi.Web.StreamManagers
{
    public class StreamManagerBase
    {
        protected Thread _backgroundThread;
        protected IHubContext _hubContext;

        protected StreamManagerBase()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<TweetHub>();
        }
    }
}
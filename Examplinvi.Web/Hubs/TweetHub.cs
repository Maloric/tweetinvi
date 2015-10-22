using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Examplinvi.Web.StreamManagers;
using Microsoft.AspNet.SignalR;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Streaminvi;

namespace Examplinvi.Web.Hubs
{
   
    public class TweetHub : Hub
    {
        
        private static IStreamManager _streamManager;

        public void StartStream(string streamType)
        {
            Clients.All.log("Server says stream type is: " + streamType + " stream");

            switch (streamType)
            {
                case "filtered":
                    _streamManager = new FilteredStreamManager();
                    break;
                case "user":
                    _streamManager = new UserStreamManager();
                    break;
                case "sample":
                    _streamManager = new SampleStreamManager();
                    break;
            }

            _streamManager.Start();
            
            Clients.All.log("Message from Server: Stream started");
        }

        public void StopStream(string streamType)
        {
            _streamManager.Stop();

            Clients.All.log("Message from Server: Stream stopped");
            
        }
    }
}
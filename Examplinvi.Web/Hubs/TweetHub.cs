﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Examplinvi.Web.StreamManagers;
using Microsoft.AspNet.SignalR;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Streaminvi;

namespace Examplinvi.Web.Hubs
{
   
    public class TweetHub : Hub
    {

        private IStreamManager _streamManager;

        public void StartStream(string streamType)
        {
            switch (streamType)
            {
                case "Filtered":
                    _streamManager = new FilteredStreamManager();
                    break;
                case "User":
                    _streamManager = new UserStreamManager();
                    break;
                case "Sample":
                    _streamManager = new SampleStreamManager();
                    break;
            }

            _streamManager.Start();
            Clients.All.log("Message from Server: Stream started");
        }

        public void StopStream()
        {
            _streamManager.Stop();

            Clients.All.log("Message from Server: Stream stopped");
        }
    }
}
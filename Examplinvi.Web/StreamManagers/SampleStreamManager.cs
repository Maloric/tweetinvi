﻿using Examplinvi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Streaminvi;

namespace Examplinvi.Web.StreamManagers
{
    public class SampleStreamManager : StreamManagerBase, IStreamManager
    {
        private ISampleStream _stream;

        public void Start()
        {            
            _stream = Stream.CreateSampleStream();

            _stream.Credentials = _credentials;

            _hubContext.Clients.All.log("Message from Server: Sample stream created");

            _stream.TweetReceived += (sender, args) =>
            {
                var tweet = new TweetViewModel(args.Tweet);
                _hubContext.Clients.All.broadcastTweet(tweet);
            };

            _stream.StartStreamAsync();
        }

        public void Stop()
        {
            _stream.StreamStopped += (sender, args) => _hubContext.Clients.All.log("Server says: stream successfully stopped");
            _stream.StopStream();            
        }   
    }
}
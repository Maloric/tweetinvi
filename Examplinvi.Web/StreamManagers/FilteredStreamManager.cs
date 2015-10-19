using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Streaminvi;

namespace Examplinvi.Web.StreamManagers
{
    public class FilteredStreamManager : StreamManagerBase, IStreamManager
    {
        private IFilteredStream _stream;

        public void Start()
        {
            _stream = Stream.CreateFilteredStream();

            _stream.MatchingTweetReceived += (sender, args) =>
            {
                ITweet tweet = args.Tweet;

                _hubContext.Clients.All.broadcastTweet(tweet);
            };

            _backgroundThread = new Thread(_stream.StartStreamMatchingAllConditions);
        }

        public void Stop()
        {
            if (_stream.StreamState == StreamState.Stop)
            {
                return;
            }

            _stream.StopStream();
        }
    }
}
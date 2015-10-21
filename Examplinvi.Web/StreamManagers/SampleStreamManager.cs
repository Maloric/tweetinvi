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

            ExceptionHandler.SwallowWebExceptions = false;

            _stream.StreamStopped += (sender, args) =>
            {
                var exceptionThatCausedTheStreamToStop = args.Exception;

                _hubContext.Clients.All.log(exceptionThatCausedTheStreamToStop.Message);
                //var twitterDisconnectMessage = args.DisconnectMessage;
                //_hubContext.Clients.All.log(twitterDisconnectMessage.Reason);
            };

            _stream.TweetReceived += (sender, args) =>
            {
                _hubContext.Clients.All.broadcastTweet(args.Tweet);
            };



            _stream.StartStream();
           // _backgroundThread = new Thread(_stream.StartStream);
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }   
    }
}
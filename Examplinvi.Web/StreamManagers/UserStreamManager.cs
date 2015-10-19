using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Streaminvi;

namespace Examplinvi.Web.StreamManagers
{
    public class UserStreamManager : StreamManagerBase, IStreamManager
    {
        private IUserStream _stream;

        public void Start()
        {
            _stream = Stream.CreateUserStream();

            _stream.TweetCreatedByMe += (sender, args) =>
            {

            };

            _backgroundThread = new Thread(_stream.StartStream);
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }    
    }
}
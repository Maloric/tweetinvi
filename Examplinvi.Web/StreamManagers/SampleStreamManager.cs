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

            _backgroundThread = new Thread(_stream.StartStream);
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }   
    }
}
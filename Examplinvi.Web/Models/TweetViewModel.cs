using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi.Core.Interfaces;

namespace Examplinvi.Web.Models
{
    public class TweetViewModel
    {
        private readonly ITweet _tweet;

        public TweetViewModel(ITweet tweet)
        {
            _tweet = tweet;
        }

        public string Text
        {
            get { return _tweet.Text; }
        }

        public string UserHandle
        {
            get { return string.Format("@{0}", _tweet.CreatedBy.Name); }
        }

        public string Url
        {
            get { return string.Format("https://twitter.com/{0}/status/{1}", _tweet.CreatedBy.ScreenName, _tweet.IdStr); }
        }

        public DateTime CreatedAt
        {
            get { return _tweet.CreatedAt; }
        }
    }
}
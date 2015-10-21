using Tweetinvi.Core.Credentials;

namespace Examplinvi.Web.Controllers
{
    public static class MyCredentials
    {
        //public static string CONSUMER_KEY = "MY_CONSUMER_KEY";
        //public static string CONSUMER_SECRET = "MY_CONSUMER_SECRET";
        //public static string ACCESS_TOKEN = "MY_ACCESS_TOKEN";
        //public static string ACCESS_TOKEN_SECRET = "MY_ACCESS_TOKEN_SECRET";

        public static string CONSUMER_KEY = "kO6JlIwLa4czaQSqvHXLFfOhb";
        public static string CONSUMER_SECRET = "rSbhwvMR0vq1UCpkztfl3PvazveNHCKg6879J8yd0kLu7Q0xSF";
        public static string ACCESS_TOKEN = "874229294-vTpHJDcl8K0I7Ae6H29Ezvpw5ZVsX3uT2wbtDNkD";
        public static string ACCESS_TOKEN_SECRET = "3XNHrHBanj3x2fOTCm53t7L6hd7NSDlLqWIgc24um3x83";

        public static ITwitterCredentials GenerateCredentials()
        {
            return new TwitterCredentials(CONSUMER_KEY, CONSUMER_SECRET, ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
        }
    }
}

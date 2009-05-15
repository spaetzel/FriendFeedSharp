using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FriendFeedSharp;

namespace FriendFeedTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an authenticated client
            FriendFeedClient client = new FriendFeedClient("ffsharp", "sacs857cut");

            // Get my profile

            Profile profile = client.FetchUserProfile("ffsharp");

            Console.WriteLine(profile.Lists.Count());


        }
    }
}

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

            UserProfile profile = client.FetchUserProfile("ffsharp");

            Console.WriteLine(profile.Lists.Count());


            ListProfile listProfile = client.FetchListProfile(profile.Lists.First().Nickname);

            Console.WriteLine(listProfile.Users.Count());
        }
    }
}

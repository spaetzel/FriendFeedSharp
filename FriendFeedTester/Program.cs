using System;
using System.Linq;
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

            UserProfile profile = client.FetchUserProfile(client.Nickname);

            Console.WriteLine(String.Format("This user's id is {0}, they have created {1} user lists", profile.Id, profile.Lists.Count() ));

            // Get the profile for a list
            ListProfile listProfile = client.FetchListProfile(profile.Lists.First().Nickname);

            Console.WriteLine(String.Format("The list, {0} has {1} users", listProfile.Name, listProfile.Users.Count()));

            User firstUser = listProfile.Users.First();

            // Get the recent posts from a list member

            Feed feed = client.FetchUserFeed( firstUser.Nickname );

            Entry firstEntry = feed.First();

            Console.WriteLine(String.Format("The most recent post from {0} has a ttile of \"{1}\" and an id of {2}", firstUser.Nickname, firstEntry.Title, firstEntry.Id ) );

            Console.ReadLine();
        }
    }
}

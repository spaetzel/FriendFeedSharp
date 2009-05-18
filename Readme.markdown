This is a C# Library for interacting with the [FriendFeed Api](http://friendfeed.com/api/)

It is based on the C# code provided by FriendFeed [here](http://code.google.com/p/friendfeed-api/)
but extented to support more/all of the methods available through the API.

The library is currently incomplete. Notably, it lacks support for Rooms or publishing Comments and Likes.

Please fork this project and submit pull requests to get your updates to the project.

Notable Changes From friendfeed-api-0.9
========================================
- Support for reading User Lists
- Support for fetching User list feeds
- Works in .net 3.5 (Had XML parsing issues)
- All classes in seperate files
- All return lists have their own type to support returning them from WCF services
- All return classes have a default constructor to support returning them from WCF services



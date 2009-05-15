using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class User
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string ProfileUrl { get; set; }

        public User()
        {
        }

        public User(XmlElement element)
        {
            Id = Util.ChildValue(element, "id");
            Nickname = Util.ChildValue(element, "nickname");
            ProfileUrl = Util.ChildValue(element, "profileUrl");
        }
    }
}

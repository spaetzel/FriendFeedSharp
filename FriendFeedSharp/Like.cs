using System;
using System.Xml;

namespace FriendFeedSharp
{
    public class Like
    {
        public DateTime Date;
        public User User;

        public Like()
        {
        }

        public Like(XmlElement element)
        {
            Date = DateTime.Parse(Util.ChildValue(element, "date"));
            User = new User(Util.ChildElement(element, "user"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class Comment
    {
        public DateTime Date { get; set; }
        public User User { get; set; }
        public string Body { get; set; }

        public Comment()
        {
        }

        public Comment(XmlElement element)
        {
            Date = DateTime.Parse(Util.ChildValue(element, "date"));
            User = new User(Util.ChildElement(element, "user"));
            Body = Util.ChildValue(element, "body");
        }
    }
}

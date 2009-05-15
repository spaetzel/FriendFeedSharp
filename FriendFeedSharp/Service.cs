using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class Service
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string ProfileUrl { get; set; }

        public Service()
        {
        }

        public Service(XmlElement element)
        {
            Id = Util.ChildValue(element, "id");
            Name = Util.ChildValue(element, "name");
            IconUrl = Util.ChildValue(element, "iconUrl");
            ProfileUrl = Util.ChildValue(element, "profileUrl");
        }
    }
}

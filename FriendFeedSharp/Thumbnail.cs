using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class Thumbnail
    {
        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

        public Thumbnail()
        {
        }

        public Thumbnail(XmlElement element)
        {
            Url = Util.ChildValue(element, "url");
            Width = Util.ChildValue(element, "width");
            Height = Util.ChildValue(element, "height");
        }
    }
}

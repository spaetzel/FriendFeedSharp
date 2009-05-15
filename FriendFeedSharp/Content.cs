using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class Content
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

        public Content()
        {
        }
        public Content(XmlElement element)
        {
            Url = Util.ChildValue(element, "url");
            Type = Util.ChildValue(element, "type");
            Width = Util.ChildValue(element, "width");
            Height = Util.ChildValue(element, "height");
        }
    }
}

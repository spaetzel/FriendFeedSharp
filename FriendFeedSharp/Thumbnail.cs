using System.Xml;

namespace FriendFeedSharp
{
    public class Thumbnail
    {
        public Thumbnail()
        {
        }

        public Thumbnail(XmlElement element)
        {
            Url = Util.ChildValue(element, "url");
            Width = Util.ChildValue(element, "width");
            Height = Util.ChildValue(element, "height");
        }

        public string Url { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }
}
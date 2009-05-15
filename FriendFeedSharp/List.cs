using System.Xml;

namespace FriendFeedSharp
{
    public class List
    {
        public List()
        {
        }

        public List(XmlElement element)
        {
            Id = Util.ChildValue(element, "id");
            Nickname = Util.ChildValue(element, "nickname");
            Url = Util.ChildValue(element, "url");
            Name = Util.ChildValue(element, "name");
        }

        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
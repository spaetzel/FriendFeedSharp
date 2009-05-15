using System.Xml;

namespace FriendFeedSharp
{
    public class Media
    {
        public Media()
        {
        }

        public Media(XmlElement element)
        {
            Title = Util.ChildValue(element, "title");
            Player = Util.ChildValue(element, "player");
            Link = Util.ChildValue(element, "link");
            Thumbnails = new ThumbnailList();
            foreach (XmlElement child in element.GetElementsByTagName("thumbnail"))
            {
                Thumbnails.Add(new Thumbnail(child));
            }
            Content = new ContentList();
            foreach (XmlElement child in element.GetElementsByTagName("content"))
            {
                Content.Add(new Content(child));
            }
        }

        public string Title { get; set; }
        public string Player { get; set; }
        public ThumbnailList Thumbnails { get; set; }
        public ContentList Content { get; set; }
        public string Link { get; set; }
    }
}
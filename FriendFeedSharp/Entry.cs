using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class Entry
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
        public CommentList Comments { get; set; }
        public LikeList Likes { get; set; }
        public MediaList Media { get; set; }

        public Entry()
        {
        }

        public Entry(XmlElement element)
        {
            Id = Util.ChildValue(element, "id");
            Title = Util.ChildValue(element, "title");
            Link = Util.ChildValue(element, "link");
            Published = DateTime.Parse(Util.ChildValue(element, "published"));
            Updated = DateTime.Parse(Util.ChildValue(element, "updated"));
            User = new User(Util.ChildElement(element, "user"));
            Service = new Service(Util.ChildElement(element, "service"));
            Comments = new CommentList();

            foreach (XmlElement child in element.GetElementsByTagName("comment"))
            {
                Comments.Add(new Comment(child));
            }
            Likes = new LikeList();
            foreach (XmlElement child in element.GetElementsByTagName("like"))
            {
                Likes.Add(new Like(child));
            }
            Media = new MediaList();
            foreach (XmlElement child in element.GetElementsByTagName("media"))
            {
                Media.Add(new Media(child));
            }
        }
    }
}

using System.Xml;

namespace FriendFeedSharp
{
    public class ListProfile : List
    {
        public ListProfile()
        {
        }

        public ListProfile(XmlElement element)
            : base(element)
        {
            Users = new UserList();
            foreach (XmlElement child in element.GetElementsByTagName("user"))
            {
                Users.Add(new User(child));
            }
        }

        public UserList Users { get; set; }
    }
}
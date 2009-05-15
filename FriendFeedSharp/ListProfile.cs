using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace FriendFeedSharp
{
    public class ListProfile : List
    {
        public UserList Users { get; set; }


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
    }
}

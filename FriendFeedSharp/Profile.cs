using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class Profile
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ServiceList Services { get; set; }
        public UserList Subscriptions { get; set; }

        public Profile()
        {
        }

          public Profile(XmlElement element)
        {
            User = new User(element);

            Name = Util.ChildValue(element, "name");
            Status = Util.ChildValue(element, "status");

            Services = new ServiceList();
            foreach (XmlElement child in element.GetElementsByTagName("service"))
            {
                Services.Add(new Service(child));
            }

            Subscriptions = new UserList();
            foreach (XmlElement child in element.GetElementsByTagName("subscription"))
            {
                Subscriptions.Add(new User(child));
            }

        }
    }
}

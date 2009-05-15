﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class UserProfile : User
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ServiceList Services { get; set; }
        public UserList Subscriptions { get; set; }
        public ListList Lists { get; set; }

        public UserProfile()
        {
        }

          public UserProfile(XmlElement element) : base( element )
        {
            User = new User(element);


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

            Lists = new ListList();
                  foreach( XmlElement child in element.GetElementsByTagName("list"))
                  {
                      Lists.Add( new List(child));
                  }
          

        }
    }
}
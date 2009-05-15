using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    internal static class Util
    {
        public static XmlElement ChildElement(XmlElement element, string name)
        {
            XmlNodeList list = element.GetElementsByTagName(name);
            foreach (XmlElement child in list)
            {
                if (child.ParentNode == element)
                {
                    return child;
                }
            }
            return null;
        }

        public static string ChildValue(XmlElement element, string name)
        {
            XmlElement child = ChildElement(element, name);
            return (child == null) ? null : child.InnerText;
        }
    }
}

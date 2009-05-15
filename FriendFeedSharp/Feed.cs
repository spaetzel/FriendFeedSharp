using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FriendFeedSharp
{
    public class Feed : List<Entry>
    {

        public Feed()
        {
        }

        public Feed(XmlElement element)
        {
           
            var entryChildren = from XmlElement c in element.ChildNodes
                                where c.Name == "entry"
                                select c;

            foreach (XmlElement child in entryChildren)
            {
                this.Add(new Entry(child));
            }
        }
    }
}

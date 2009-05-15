using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<XmlElement> entryChildren = from XmlElement c in element.ChildNodes
                                                    where c.Name == "entry"
                                                    select c;

            foreach (XmlElement child in entryChildren)
            {
                Add(new Entry(child));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendFeedSharp
{
    public class ThumbnailUrl
    {
        public string Link;
        public string Url;

        public ThumbnailUrl()
        {
            
        }
        /// <summary>
        /// Creates an entry thumbnail from the image at the given URL.
        /// 
        /// The thumbnail will link to the main entry link. If you want the
        /// thumbnail to link to a different URL, you can specify a link in
        /// the other constructor.
        /// </summary>
        public ThumbnailUrl(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Creates an entry thumbnail from the image at the given URL.
        /// 
        /// The thumbnail image will link to the given link URL.
        /// </summary>
        public ThumbnailUrl(string url, string link)
        {
            Url = url;
            Link = link;
        }
    }
}

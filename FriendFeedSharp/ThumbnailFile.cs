using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendFeedSharp
{
    public class ThumbnailFile
    {
        public string Link;
        public string Path;

        public ThumbnailFile(){}

        /// <summary>
        /// Creates an entry thumbnail from the file at the given path.
        /// 
        /// The thumbnail will link to the main entry link. If you want the
        /// thumbnail to link to a different URL, you can specify a link in
        /// the other constructor.
        /// </summary>
        public ThumbnailFile(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Creates an entry thumbnail from the file at the given path.
        /// 
        /// The thumbnail image will link to the given link URL.
        /// </summary>
        public ThumbnailFile(string path, string link)
        {
            Path = path;
            Link = link;
        }
    }
}

namespace FriendFeedSharp
{
    public class AudioUrl
    {
        public string Title;
        public string Url;

        public AudioUrl()
        {}

        /// <summary>
        /// Links an audio file at the given URL to an entry.
        /// 
        /// If no title is set, the entry title will be shown while playing.
        /// </summary>
        public AudioUrl(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Links an audio file at the given URL to an entry.
        /// 
        /// The given title will be shown while the file is playing.
        /// </summary>
        public AudioUrl(string url, string title)
        {
            Url = url;
            Title = title;
        }
    }
}
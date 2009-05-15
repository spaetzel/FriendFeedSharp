// Copyright 2008 FriendFeed
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License. You may obtain
// a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace FriendFeedSharp {
  /// <summary>
  /// A client to interact with the FriendFeed API.
  /// 
  /// More information about the API is available at http://friendfeed.com/api/.
  /// </summary>
  public class FriendFeedClient {
    private string nickname_;
    private string remoteKey_;

    public string Nickname
    {
        get
        {
            return nickname_;
        }
    }

    /// <summary>
    /// Creates an un-authenticated FriendFeed API client.
    /// 
    /// An un-authenticated client can only perform read operations on public
    /// feeds.
    /// </summary>
    public FriendFeedClient() {
    }

    /// <summary>
    /// Creates a FriendFeed API client authenticated with the given credentials.
    /// </summary>
    public FriendFeedClient(string nickname, string remoteKey) {
      nickname_ = nickname;
      remoteKey_ = remoteKey;
    }

    /// <summary>
    /// Publishes the given message to the authenticated user's feed.
    /// </summary>
    /// <param name="message">The text of the message</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishMessage(string message) {
      return PublishLink(message, null);
    }

    /// <summary>
    /// Publishes the given link to the authenticated user's feed.
    /// </summary>
    /// <param name="title">The title of the link</param>
    /// <param name="link">The link URL</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishLink(string title, string link) {
      return PublishLink(title, link, null);
    }

    /// <summary>
    /// Publishes the given link to the authenticated user's feed.
    /// </summary>
    /// <param name="title">The title of the link</param>
    /// <param name="link">The link URL</param>
    /// <param name="comment">The initial comment for this entry</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishLink(string title, string link, string comment) {
      return PublishLink(title, link, comment, null);
    }

    /// <summary>
    /// Publishes the given link to the authenticated user's feed.
    /// </summary>
    /// <param name="title">The title of the link</param>
    /// <param name="link">The link URL</param>
    /// <param name="comment">The initial comment for this entry</param>
    /// <param name="imageUrls">URLs of the thumbnails to be included with this entry</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishLink(string title, string link, string comment, ThumbnailUrl[] imageUrls) {
      return PublishLink(title, link, comment, imageUrls, null);
    }

    /// <summary>
    /// Publishes the given link to the authenticated user's feed.
    /// </summary>
    /// <param name="title">The title of the link</param>
    /// <param name="link">The link URL</param>
    /// <param name="comment">The initial comment for this entry</param>
    /// <param name="imageUrls">URLs of the thumbnails to be included with this entry</param>
    /// <param name="imagePaths">Paths to local image files to be included as thumbnails with this entry</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishLink(string title, string link, string comment, ThumbnailUrl[] imageUrls, ThumbnailFile[] imageFiles) {
      return PublishLink(title, link, comment, imageUrls, imageFiles, null);
    }

    /// <summary>
    /// Publishes the given link to the authenticated user's feed.
    /// </summary>
    /// <param name="title">The title of the link</param>
    /// <param name="link">The link URL</param>
    /// <param name="comment">The initial comment for this entry</param>
    /// <param name="imageUrls">URLs of the thumbnails to be included with this entry</param>
    /// <param name="imagePaths">Paths to local image files to be included as thumbnails with this entry</param>
    /// <param name="via">The ID of the API client sending this request</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishLink(string title, string link, string comment, ThumbnailUrl[] imageUrls, ThumbnailFile[] imageFiles, string via) {
      return PublishLink(title, link, comment, imageUrls, imageFiles, via, null);
    }

    /// <summary>
    /// Publishes the given link to the authenticated user's feed.
    /// </summary>
    /// <param name="title">The title of the link</param>
    /// <param name="link">The link URL</param>
    /// <param name="comment">The initial comment for this entry</param>
    /// <param name="imageUrls">URLs of the thumbnails to be included with this entry</param>
    /// <param name="imagePaths">Paths to local image files to be included as thumbnails with this entry</param>
    /// <param name="via">The ID of the API client sending this request</param>
    /// <param name="audioUrls">URLs of the mp3 files to be included with this entry</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishLink(string title, string link, string comment, ThumbnailUrl[] imageUrls, ThumbnailFile[] imageFiles, string via, AudioUrl[] audioUrls) {
      return PublishLink(title, link, comment, imageUrls, imageFiles, via, audioUrls, null);
    }

    /// <summary>
    /// Publishes the given link to the authenticated user's feed.
    /// </summary>
    /// <param name="title">The title of the link</param>
    /// <param name="link">The link URL</param>
    /// <param name="comment">The initial comment for this entry</param>
    /// <param name="imageUrls">URLs of the thumbnails to be included with this entry</param>
    /// <param name="imagePaths">Paths to local image files to be included as thumbnails with this entry</param>
    /// <param name="via">The ID of the API client sending this request</param>
    /// <param name="audioUrls">URLs of the mp3 files to be included with this entry</param>
    /// <param name="room">The room to post this entry to</param>
    /// <returns>The new entry as returned by the server</returns>
    public Entry PublishLink(string title, string link, string comment, ThumbnailUrl[] imageUrls, ThumbnailFile[] imageFiles, string via, AudioUrl[] audioUrls, string room) {
      SortedDictionary<string, string> postArguments = new SortedDictionary<string, string>();
      postArguments["title"] = title;
      if (link != null) {
        postArguments["link"] = link;
      }
      if (comment != null) {
        postArguments["comment"] = comment;
      }
      if (via != null) {
	postArguments["via"] = via;
      }
      if (room != null) {
	postArguments["room"] = room;
      }
      if (imageUrls != null) {
        for (int i = 0; i < imageUrls.Length; i++) {
          postArguments["image" + i + "_url"] = imageUrls[i].Url;
          if (imageUrls[i].Link != null) {
            postArguments["image" + i + "_link"] = imageUrls[i].Url;
          }
        }
      }
      if (audioUrls != null) {
        for (int i = 0; i < audioUrls.Length; i++) {
          postArguments["audio" + i + "_url"] = audioUrls[i].Url;
          if (audioUrls[i].Title != null) {
            postArguments["audio" + i + "_title"] = audioUrls[i].Title;
          }
        }
      }
      SortedDictionary<string, string> fileAttachments = new SortedDictionary<string, string>();
      if (imageFiles != null) {
        for (int i = 0; i < imageFiles.Length; i++) {
          fileAttachments["file" + i] = imageFiles[i].Path;
          if (imageFiles[i].Link != null) {
            postArguments["file" + i + "_link"] = imageUrls[i].Url;
          }
        }
      }
      HttpWebResponse response = MakeRequest("/api/share", null, postArguments, fileAttachments);
      XmlDocument document = new XmlDocument();
      document.Load(response.GetResponseStream());
      return (new Feed(document.DocumentElement))[0];
    }

    /// <summary>
    /// Returns the most recent entries from all publicly visible users.
    /// </summary>
    public Feed FetchPublicFeed() {
      return FetchPublicFeed(null);
    }
    public Feed FetchPublicFeed(string service) {
      return FetchPublicFeed(null, 0);
    }
    public Feed FetchPublicFeed(string service, int start) {
      return FetchPublicFeed(null, 0, 30);
    }
    public Feed FetchPublicFeed(string service, int start, int num) {
      return FetchFeed("/api/feed/public", service, start, num);
    }

    /// <summary>
    /// Returns the most recent entries from the authenticated user's
    /// subscriptions, as they would see on their FriendFeed home page.
    /// </summary>
    public Feed FetchHomeFeed() {
      return FetchHomeFeed(null);
    }
    public Feed FetchHomeFeed(string service) {
      return FetchHomeFeed(service, 0);
    }
    public Feed FetchHomeFeed(string service, int start) {
      return FetchHomeFeed(service, start, 30);
    }
    public Feed FetchHomeFeed(string service, int start, int num) {
      return FetchFeed("/api/feed/home", service, start, num);
    }

    public Feed FetchHomeFeed(int start, int num)
    {
        return FetchFeed("/api/feed/home", start, num);
    }

    public UserProfile FetchUserProfile(string nickname)
    {
     

        HttpWebResponse response = MakeRequest(string.Format("/api/user/{0}/profile", nickname), null, null, null);
        XmlDocument document = new XmlDocument();
        document.Load(response.GetResponseStream());
        return new UserProfile(document.DocumentElement);
    }

    public ListProfile FetchListProfile(string nickname)
    {
        if (String.IsNullOrEmpty(this.Nickname))
        {
            throw new ArgumentException("Must have an authenticated client to retrieve list profile information");
        }


        HttpWebResponse response = MakeRequest(string.Format("/api/list/{0}/profile", nickname), null, null, null);
        XmlDocument document = new XmlDocument();
        document.Load(response.GetResponseStream());
        return new ListProfile(document.DocumentElement);

    }

    /// <summary>
    /// Fetches the most recent entries for the user with the given nickname.
    /// 
    /// If the user has a private feed, authentication is required.
    /// </summary>
    public Feed FetchUserFeed(string nickname) {
      return FetchUserFeed(nickname, null);
    }
    public Feed FetchUserFeed(string nickname, string service) {
      return FetchUserFeed(nickname, null, 0);
    }
    public Feed FetchUserFeed(string nickname, string service, int start) {
      return FetchUserFeed(nickname, null, 0, 30);
    }
    public Feed FetchUserFeed(string nickname, string service, int start, int num) {
      return FetchFeed("/api/feed/user/" + HttpUtility.UrlEncode(nickname), service, start, num);
    }

    public Feed FetchUserFeed(string nickname, int start, int num)
    {
        return FetchFeed("/api/feed/user/" + HttpUtility.UrlEncode(nickname), start, num);
    }

    /// <summary>
    /// Fetches the most recent entries for the given list of users.
    /// 
    /// If any of the users has a private feed, authentication is required.
    /// </summary>
    public Feed FetchMultiUserFeed(string[] nicknames) {
      return FetchMultiUserFeed(nicknames, null);
    }
    public Feed FetchMultiUserFeed(string[] nicknames, string service) {
      return FetchMultiUserFeed(nicknames, null, 0);
    }
    public Feed FetchMultiUserFeed(string[] nicknames, string service, int start) {
      return FetchMultiUserFeed(nicknames, null, 0, 30);
    }
    public Feed FetchMultiUserFeed(string[] nicknames, string service, int start, int num) {
      SortedDictionary<string, string> urlArguments = new SortedDictionary<string, string>();
      urlArguments["nickname"] = string.Join(",", nicknames);
      return FetchFeed("/api/feed/user", service, start, num, urlArguments);
    }

    /// <summary>
    /// Fetches the feed at the given path, parsing and returning the result.
    /// </summary>
    public Feed FetchFeed(string path, string service, int start, int num) {
      return FetchFeed(path, service, start, num, null);
    }


    /// <summary>
    /// Fetches the feed at the given path, parsing and returning the result.
    /// </summary>
    public Feed FetchFeed(string path, int start, int num)
    {
        return FetchFeed(path, null, start, num, null);
    }

    /// <summary>
    /// Fetches the feed at the given path with the given URL arguments.
    /// </summary>
    public Feed FetchFeed(string path, string service, int start, int num, SortedDictionary<string, string> urlArguments) {
      if (urlArguments == null) urlArguments = new SortedDictionary<string, string>();
      if (service != null) urlArguments["service"] = service;
      urlArguments["start"] = start.ToString();
      urlArguments["num"] = num.ToString();
      HttpWebResponse response = MakeRequest(path, urlArguments, null, null);
      XmlDocument document = new XmlDocument();
      document.Load(response.GetResponseStream());
      return new Feed(document.DocumentElement);
    }

      /// <summary>
    /// Validates the user's remote key. If the HTTP Basic Authentication nickname and remote key are valid, we return true. Otherwise, we return false.
      /// </summary>
      /// <returns></returns>
    public bool Validate()
    {
        try
        {
            var response = MakeRequest("/api/validate", null, null, null);


            return response.StatusCode == HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Makes an HTTP request to the FriendFeed servers.
    /// 
    /// If this client was created with a nickname and remote key, the request
    /// is automatically authenticated. If postArguments is given, the request
    /// will be a POST request. We send a GET otherwise.
    /// </summary>
    /// <param name="path">The path for the request, e.g., /api/feed/home</param>
    /// <param name="urlArguments">The arguments to be included in the URL, e.g., {"start": "0"}</param>
    /// <param name="postArguments">The arguments to be included in the POST body of the request</param>
    /// <param name="fileAttachments">Files to be uploaded with this request</param>
    public HttpWebResponse MakeRequest(string path, SortedDictionary<string, string> urlArguments, SortedDictionary<string, string> postArguments, SortedDictionary<string, string> fileAttachments) {
      if (urlArguments == null) urlArguments = new SortedDictionary<string, string>();
      urlArguments["format"] = "xml";
      string url = "http://friendfeed.com" + path + "?" + UrlEncode(urlArguments);
      HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

      // Encode the POST body if POST args are given
      if (postArguments != null) {
        request.Method = "POST";
        string boundary = Guid.NewGuid().ToString().Replace("-", "");
        request.ContentType = "multipart/form-data; boundary=" + boundary;
        Stream stream = request.GetRequestStream();
        foreach (KeyValuePair<string, string> pair in postArguments) {
          byte[] value = Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n", boundary, pair.Key, pair.Value));
          stream.Write(value, 0, value.Length);
        }
        foreach (KeyValuePair<string, string> pair in fileAttachments) {
          FileInfo info = new FileInfo(pair.Value);
          byte[] contents = new byte[info.Length];
          using (FileStream file = File.OpenRead(pair.Value)) {
            file.Read(contents, 0, contents.Length);
          }
          byte[] value = Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: file; name=\"{1}\"; filename=\"{2}\"\r\n\r\n", boundary, pair.Key, Path.GetFileName(pair.Value)));
          stream.Write(value, 0, value.Length);
          stream.Write(contents, 0, contents.Length);
          stream.Write(Encoding.UTF8.GetBytes("\r\n"), 0, 2);
        }
        byte[] end = Encoding.UTF8.GetBytes(string.Format("--{0}--\r\n", boundary));
        stream.Write(end, 0, end.Length);
        stream.Close();
      } else {
        request.Method = "GET";
      }

      // Add the HTTP Basic auth header if we have credentials
      if (nickname_ != null && remoteKey_ != null) {
        CredentialCache cache = new CredentialCache();
        cache.Add(new Uri("http://friendfeed.com/api/"), "Basic", new NetworkCredential(nickname_, remoteKey_));
        request.Credentials = cache;
      }

      System.Diagnostics.Debug.WriteLine("Downloading " + url);
      request.UserAgent = "FriendFeedCSharpApi/0.4";
      return (HttpWebResponse) request.GetResponse();
    }

    private string UrlEncode(SortedDictionary<string, string> arguments) {
      string[] parts = new string[arguments.Count];
      int i = 0;
      foreach (KeyValuePair<string, string> pair in arguments) {
        parts[i++] = HttpUtility.UrlEncode(pair.Key) + "=" + HttpUtility.UrlEncode(pair.Value);
      }
      return string.Join("&", parts);
    }
  }

  public class AudioUrl {
    public string Url;
    public string Title;

    /// <summary>
    /// Links an audio file at the given URL to an entry.
    /// 
    /// If no title is set, the entry title will be shown while playing.
    /// </summary>
    public AudioUrl(string url) {
      this.Url = url;
    }

    /// <summary>
    /// Links an audio file at the given URL to an entry.
    /// 
    /// The given title will be shown while the file is playing.
    /// </summary>
    public AudioUrl(string url, string title) {
      this.Url = url;
      this.Title = title;
    }
  }

  public class ThumbnailUrl {
    public string Url;
    public string Link;

    /// <summary>
    /// Creates an entry thumbnail from the image at the given URL.
    /// 
    /// The thumbnail will link to the main entry link. If you want the
    /// thumbnail to link to a different URL, you can specify a link in
    /// the other constructor.
    /// </summary>
    public ThumbnailUrl(string url) {
      this.Url = url;
    }

    /// <summary>
    /// Creates an entry thumbnail from the image at the given URL.
    /// 
    /// The thumbnail image will link to the given link URL.
    /// </summary>
    public ThumbnailUrl(string url, string link) {
      this.Url = url;
      this.Link = link;
    }
  }

  public class ThumbnailFile {
    public string Path;
    public string Link;

    /// <summary>
    /// Creates an entry thumbnail from the file at the given path.
    /// 
    /// The thumbnail will link to the main entry link. If you want the
    /// thumbnail to link to a different URL, you can specify a link in
    /// the other constructor.
    /// </summary>
    public ThumbnailFile(string path) {
      this.Path = path;
    }

    /// <summary>
    /// Creates an entry thumbnail from the file at the given path.
    /// 
    /// The thumbnail image will link to the given link URL.
    /// </summary>
    public ThumbnailFile(string path, string link) {
      this.Path = path;
      this.Link = link;
    }
  }



  

 









 

  static internal class Util {
    public static XmlElement ChildElement(XmlElement element, string name) {
      XmlNodeList list = element.GetElementsByTagName(name);
      foreach (XmlElement child in list) {
        if (child.ParentNode == element) {
          return child;
        }
      }
      return null;
    }

    public static string ChildValue(XmlElement element, string name) {
      XmlElement child = ChildElement(element, name);
      return (child == null) ? null : child.InnerText;
    }
  }
}

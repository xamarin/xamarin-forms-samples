using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Xamarin.Forms;

namespace RssFeedWithImages
{
    public class RssFeed : INotifyPropertyChanged
    {
        string url, title;
        IList<RssItem> items;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Url
        {
            set
            {
                if (url != value)
                {
                    url = value;
                    OnPropertyChanged("Url");
                    LoadRssFeed(url);
                }
            }
            get
            {
                return url;
            }
        }

        public void LoadRssFeed(string url)
        {
            // WebClient might be somewhat easer here, but it's not
            //  supported for PCLs.
            HttpWebRequest request = WebRequest.CreateHttp(url);
            IAsyncResult asyncRequest = null;

            asyncRequest = request.BeginGetResponse(async (args) =>
            {
                // Download XML.
                WebResponse response = request.EndGetResponse(asyncRequest);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string xml = await reader.ReadToEndAsync();

                // Parse XML to extract data from RSS feed.
                XDocument doc = XDocument.Parse(xml);
                var channel = doc.Element(XName.Get("rss"))
                                     .Element(XName.Get("channel"));

                // Get title.
                string title = channel.Element(XName.Get("title")).Value;

                // Get items.
                var list = channel.Elements(XName.Get("item"))
                                  .Select((XElement element) =>
                                  {
                                      // Instantiate RssItem for each item.
                                      return new RssItem(element);
                                  })
                                  .ToList();

                // Although Title and Items are probably bound to UI items,
                //  and UI items can only be accessd from the UI thread, 
                //  it's OK to set data bound properties on a secondary thread.
                this.Title = title;
                this.Items = new ObservableCollection<RssItem>(list);
            }, null);
        }

        public string Title 
        { 
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
            get
            {
                return title;
            }
        }

        public IList<RssItem> Items 
        { 
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged("Items");
                }
            }
            get
            {
                return items;
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
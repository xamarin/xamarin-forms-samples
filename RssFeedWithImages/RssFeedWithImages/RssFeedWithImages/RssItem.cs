using System;
using System.Xml.Linq;

namespace RssFeedWithImages
{
    // This class does not need to implement INotifyPropertyChanged
    //  because instances are immutable: All properties are set
    //  during the constructor and cannot be changed later.
    public class RssItem
    {
        public RssItem(XElement element)
        {
            // Although this code might appear to be generalized, it is
            //  actually based on desired elements from the particular 
            //  RSS feed set in the RssFeedPage.xaml file.
            this.Title = element.Element(XName.Get("title")).Value;
            this.Description = element.Element(XName.Get("description")).Value;
            this.Link = element.Element(XName.Get("link")).Value;
            this.PubDate = element.Element(XName.Get("pubDate")).Value;
            this.Thumbnail = element.Element(
                XName.Get("thumbnail", "http://search.yahoo.com/mrss/"))
                    .Attribute(XName.Get("url")).Value;
        }

        public string Title { protected set; get; }

        public string Description { protected set; get; }

        public string Link { protected set; get; }

        public string PubDate { protected set; get; }

        public string Thumbnail { protected set; get; }
    }
}

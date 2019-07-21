using System;

namespace ChatClient.Model
{
    public class NegotiateInfo
    {
        public Uri Url
        {
            get;
            set;
        }

        public string UrlWithoutQuery
        {
            get
            {
                if (Url == null)
                {
                    return string.Empty;
                }

                string pathWithoutQuery = Url.PathAndQuery.Substring(
                    0,
                    Url.PathAndQuery.IndexOf("?"));

                return $"{Url.Scheme}://{Url.Host}{pathWithoutQuery}";
            }
        }

        public string Query
        {
            get
            {
                if (Url == null)
                {
                    return string.Empty;
                }

                return Url.Query.Substring(1);
            }
        }

        public string HubName
        {
            get
            {
                if (Url == null)
                {
                    return string.Empty;
                }

                var parts = Url.Query.Split(new[]
                {
                    '='
                });

                return parts[1];
            }
        }

        public string AccessToken
        {
            get;
            set;
        }
    }
}
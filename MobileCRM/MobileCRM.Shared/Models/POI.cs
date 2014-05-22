using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MobileCRM.Shared.Models
{

    public class POI
    {
        public List<Label> Labels { get; set; }
        public List<object> Descriptions { get; set; }
        public List<Category> Categories { get; set; }
        public List<object> Times { get; set; }
        public List<Link> Links { get; set; }
        public object Metadata { get; set; }
        public Location Location { get; set; }
        public string Typename { get; set; }
        public string Id { get; set; }
        public object Value { get; set; }
        public string Href { get; set; }
        public object Type { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Deleted { get; set; }
        public object Author { get; set; }
        public object License { get; set; }
        public object Lang { get; set; }
        public string Base { get; set; }
        public string Myid { get; set; }
        public object Parentid { get; set; }
        public bool Changed { get; set; }

        public string DisplayLabel 
        {
          get 
          {
            if (Labels == null || Labels.Count == 0)
              return string.Empty;

            return Labels[0].Value;
          } 
        }

        public string DisplayCategory
        {
          get
          {
            if (Categories == null || Categories.Count == 0)
              return string.Empty;

            return Categories[0].Value;
          }
        }

        public override string ToString ()
        {
            return string.Format ("[POI: Labels={0}, Descriptions={1}, Categories={2}, Times={3}, Links={4}, Metadata={5}, Location={6}, Typename={7}, Id={8}, Value={9}, Href={10}, Type={11}, Created={12}, Updated={13}, Deleted={14}, Author={15}, License={16}, Lang={17}, Base={18}, Myid={19}, Parentid={20}, Changed={21}]", Labels, Descriptions, Categories, Times, Links, Metadata, Location, Typename, Id, Value, Href, Type, Created, Updated, Deleted, Author, License, Lang, Base, Myid, Parentid, Changed);
        }
    }
    
}

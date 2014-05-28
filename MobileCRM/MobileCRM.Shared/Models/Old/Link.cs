using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MobileCRM.Shared.Models
{

    public class Link
    {
        public string Term { get; set; }
        public string Scheme { get; set; }
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
        public string Parentid { get; set; }
        public bool Changed { get; set; }
    }
    
}

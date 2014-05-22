using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MobileCRM.Shared.Models
{

    public class Category
    {
        public string Term { get; set; }
        public string Scheme { get; set; }
        public string Typename { get; set; }
        public object Id { get; set; }
        public string Value { get; set; }
        public object Href { get; set; }
        public object Type { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Deleted { get; set; }
        public Author2 Author { get; set; }
        public object License { get; set; }
        public object Lang { get; set; }
        public object Base { get; set; }
        public string Myid { get; set; }
        public string Parentid { get; set; }
        public bool Changed { get; set; }
    }
    
}

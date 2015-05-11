﻿using System.Net;
using Newtonsoft.Json;

namespace Eka.Web.Vine
{
    public class Vine
    {
        public Vine(string id)
        {
            RequestUri = "https://vine.co/oembed.json?url=https%3A%2F%2Fvine.co%2Fv%2F" + id;

            var jsonresponse = JsonConvert.DeserializeObject<VineContents>(new WebClient().DownloadString(RequestUri));

            Author = jsonresponse.author_name;
            Title = jsonresponse.title;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string RequestUri { get; set; }

        public class VineContents
        {
            public double version { get; protected set; }
            public string type { get; set; }
            public long cache_age { get; set; }
            public string provider_name { get; set; }
            public string provider_url { get; set; }
            public string author_name { get; set; }
            public string author_url { get; set; }
            public string title { get; set; }
            public string thumbnail_url { get; set; }
            public int thumbnail_width { get; set; }
            public int thumbnail_height { get; set; }
            public string html { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }
    }
}
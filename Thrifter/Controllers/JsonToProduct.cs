using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thrifter.DAL;

namespace Thrifter.Controllers
{
    public class JsonToProduct
    {
        [JsonProperty]
        public string Email { get; set; }

        [JsonProperty]
        public List<Product> Products { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicDomainEbooks.Model
{
    class User
    {
        [JsonProperty]
        public String UserId { get; set; }
    }
}

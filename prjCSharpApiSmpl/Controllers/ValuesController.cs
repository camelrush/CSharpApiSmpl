using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using static System.Console;

namespace prjCSharpApiSmpl.Controllers
{

    [DataContract]
    public class PChild
    {
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class P
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string birthday { get; set; }
        [DataMember]
        public PChild pc { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            String input = "{\"name\":\"abc\",\"birthday\":\"2020/06/20\",\"pc\":{\"name\":\"test\"}";

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(input), false))
            {
                var serializer = new DataContractJsonSerializer(typeof(P));
                P p = serializer.ReadObject(ms) as P;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesSimulator
{
    public class JsonContent : StringContent
    {
        public JsonContent(object model)
            : base(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace ProjetRestSharp
{
    public class CabinetData
    {
        [DeserializeAs(Name = "data")]
        public Cabinet Cabinet { get; set; }
    }

    public class Cabinet
    {
        [DeserializeAs(Name = "id")]
        public int id { get; set; }

        [DeserializeAs(Name = "adresse")]
        public string adresse { get; set; }

        public Cabinet()
        {

        }
        //[DeserializeAs(Name = "commune")]

        

    }

    public class Cabinets
    {
        [DeserializeAs(Name = "data")]
        public List<Cabinet> ListeCabinet { get; set; }
    }
}

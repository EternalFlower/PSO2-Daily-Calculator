using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSO2_DailyOrderCalculator
{
    public class ClientOrder
    {
        [JsonProperty("jp_name(jp)")]
        public string JpNameJp { get; set; }
        [JsonProperty("jp_name(en)")]
        public string JpNameEn { get; set; }
        [JsonProperty("global_name(en)")]
        public string GlobalNameEn { get; set; }
        public int meseta { get; set; }
        public int exp { get; set; }
    }

    public class DailyOrder : ClientOrder
    {
        public List<int> Schedule { get; set; }
        public int cycle { get; set; }
    }
}

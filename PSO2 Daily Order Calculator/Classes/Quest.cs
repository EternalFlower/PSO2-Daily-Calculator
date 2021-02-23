using Newtonsoft.Json;

namespace PSO2_DO_Bot
{
    public class Quest
    {
        [JsonProperty("jp_name(jp)")]
        public string JpNameJp { get; set; }
        [JsonProperty("jp_name(en)")]
        public string JpNameEn { get; set; }
        [JsonProperty("global_name(en)")]
        public string GlobalNameEn { get; set; }
    }
}

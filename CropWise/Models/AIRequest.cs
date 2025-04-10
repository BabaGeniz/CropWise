using Newtonsoft.Json;

namespace CropWise.Models
{
    public class AIRequest
    {
        [JsonProperty("contents")]
        public List<Content> Contents { get; set; }
    }

    public class Content
    {
        [JsonProperty("parts")]
        public List<Part> Parts { get; set; }
    }

    public class Part
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("inlineData")]
        public InLineData InLineData { get;set; }
    }

    public class InLineData
    {

        [JsonProperty("mimeType")]
        public string mimeType { get; set; }
        [JsonProperty("data")]
        public string data { get; set; }


    }
}

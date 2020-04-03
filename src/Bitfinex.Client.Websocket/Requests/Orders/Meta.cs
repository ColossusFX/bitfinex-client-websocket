using Newtonsoft.Json;

namespace Bitfinex.Client.Websocket.Requests.Orders
{
    public class Meta
    {
        [JsonProperty("aff_code")]
        public string AffCode { get; set; }
    }
}
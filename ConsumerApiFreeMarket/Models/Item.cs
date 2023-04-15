using Newtonsoft.Json;
using System.Text.Json;

namespace ConsumerApiFreeMarket.Models {
    public class Item {
        public string id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Thumbnail { get; set; }
        [JsonProperty("available_quantity")]
        public int AvailableQuantity { get; set; }
        [JsonProperty("sold_quantity")]
        public int SoldQuantity { get; set; }
        [JsonProperty("sale_terms")]
        public List<object> SaleTerms { get; set; }


    }
}

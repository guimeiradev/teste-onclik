using ConsumerApiFreeMarket.Models;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace ConsumerApiFreeMarket.Service {
    public class ItemService {
        private readonly IConfiguration _configuration;
        public ItemService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<Item> GetItem(int statusCode) {

            HttpClient client = new HttpClient();

            var response = await client.GetAsync(_configuration.GetSection("MySettings").GetSection("UrlApi").Value);

            statusCode = (int)response.StatusCode;

            var jsonString = await response.Content.ReadAsStringAsync();

            Item item = JsonConvert.DeserializeObject<Item>(jsonString);

            SaveTextFile(statusCode);
            return item;
        }

        public void SaveTextFile(int statusCode) {

            StreamWriter arq;

            string pathName = _configuration.GetSection("MySettings").GetSection("PathName").Value;

            arq =  File.CreateText(pathName);

            arq.WriteLine($"Status = {statusCode}");
            arq.WriteLine();
            arq.WriteLine($"Data = {DateTime.Now}");
            arq.Close();
        }
    }
}

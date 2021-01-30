using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LaSpruca.KNIDotNet.Response;

namespace LaSpruca.KNIDotNet {
    public class Portal {
        private readonly string _key;
        private readonly HttpClient _httpClient = new HttpClient();

        public Portal(string address) {
            _httpClient.BaseAddress = new Uri(address);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "KAMAR/ CFNetwork/ Darwin/");

            _key = "vtku";
        }
        
        public Portal(string address, string key) {
            _httpClient.BaseAddress = new Uri(address);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "KAMAR/ CFNetwork/ Darwin/");

            _key = key;
        }

        public async Task<NoticesResponse> GetNotices(DateTime date) {
            var response = await _httpClient.
                PostAsync("/api/api.php", 
                    new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("Key", _key),
                        new KeyValuePair<string, string>("Command", "GetNotices"),
                        new KeyValuePair<string, string>("Date", $"{date.Day}/{date.Month}/{date.Year}")
                    }));
            
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return (NoticesResponse) new XmlSerializer(typeof(NoticesResponse)).Deserialize(await response.Content.ReadAsStreamAsync());
        }
    }
}
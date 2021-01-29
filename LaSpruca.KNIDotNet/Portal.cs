using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LaSpruca.KNIDotNet {
    public class Portal {
        private readonly string _key;
        private readonly string _address;
        private HttpClient httpClient = new HttpClient();

        public Portal(string address) {
            httpClient.BaseAddress = new Uri(address);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "KAMAR/ CFNetwork/ Darwin/");

            _key = "vtku";
        }

        public async Task<string> GetNotices(DateTime date) {
            
            var content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("Key", _key));
            content.Add(new KeyValuePair<string, string>("Command", "GetNotices"));
            content.Add(new KeyValuePair<string, string>("Date", $"{date.Day}/{date.Month}/{date.Year}"));


            var response = await httpClient.PostAsync("/api/api.php", new FormUrlEncodedContent(content));

            return await response.Content.ReadAsStringAsync();
        }
    }
}
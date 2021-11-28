using ClientConsoleApp.Helper;
using ClientConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp.Services.Client
{
    public class ClientService: IClientService
    {
        private HttpClient _httpClient;

        public ClientService()
        {
            var baseAddress = "https://localhost:5001/api/v1/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
            
        }

        public bool Login(LoginModel user)
        {
            var result = false;
            try
            {
                var uri = $"{_httpClient.BaseAddress}Auth/Login";
                var post = _httpClient.PostAsJsonAsync(uri, user).Result;

                if((int)post.StatusCode == 200)
                {
                    var response = post.Content.ReadAsStringAsync().Result;
                    var json = JsonConvert.DeserializeObject<ResponseTokenModel>(response);
                    
                    var tokenHeader = json.Type + " " + json.Token;
                    Helpers.Header = tokenHeader;
                    
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}

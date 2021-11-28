using ClientConsoleApp.Helper;
using ClientConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp.Services.Figure
{
    public class FigureService : IFigureService
    {
        private HttpClient _httpClient;

        public FigureService()
        {
            string baseAddress = "https://localhost:5001/api/Figure/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Authorization", Helpers.Header);
        }

        public bool AddFigure(FigureModel figure)
        {
            var result = false;
            try
            {
                string address = $"{_httpClient.BaseAddress}Add";

                var post = _httpClient.PostAsJsonAsync(address, figure).Result;
                if((int)post.StatusCode == 201)
                {
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        public List<FigureResponseModel> GetAllFiguresByName(string figureName)
        {
            var result = default(List<FigureResponseModel>);
            try
            {
                string address = $"{_httpClient.BaseAddress}GetAllFromFigure?figureName={figureName}";

                var response = _httpClient.GetAsync(address).Result;
                if((int)response.StatusCode == 200)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var figuresList = JsonConvert.DeserializeObject<List<FigureResponseModel>>(json);
                    result = figuresList;
                    return result;
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

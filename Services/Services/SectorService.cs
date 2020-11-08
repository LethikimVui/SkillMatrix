using Newtonsoft.Json;
using Services.Interfaces;
using SharedObjects.Common;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SectorService : BaseService, ISectorService
    {
        public async Task<ResponseResult> Add( AddSectorViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/Sector/add", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }


        public async Task<VSector> FindSector(string sectorName)
        {
            VSector sector = new VSector();

            using (var response = await httpClient.GetAsync("api/sector/search/" + sectorName))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                sector = JsonConvert.DeserializeObject<VSector>(apiResponse);

            }
            return sector;
        }

        public async Task<List<VSector>> GetAll()
        {
            List<VSector> sectors = new List<VSector>();

            using (var response = await httpClient.GetAsync("api/sector/get-all"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                sectors = JsonConvert.DeserializeObject<List<VSector>>(apiResponse);
            }
            return sectors;
        }
    }
}

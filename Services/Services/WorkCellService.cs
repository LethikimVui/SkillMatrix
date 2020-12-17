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
    public class WorkCellService : BaseService, IWorkCellService
    {

        public async Task<List<VWC>> GetAll()
        {
            List<VWC> WCs = new List<VWC>();

            using (var response = await httpClient.GetAsync("api/workcell/get-all"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                WCs = JsonConvert.DeserializeObject<List<VWC>>(apiResponse);
            }
            return WCs;
        }
    }
}

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
    public class PositionService : BaseService, IPositionService
    {

        public async Task<List<VPosition>> GetAll()
        {
            List<VPosition> WCs = new List<VPosition>();

            using (var response = await httpClient.GetAsync("api/position/get-all"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                WCs = JsonConvert.DeserializeObject<List<VPosition>>(apiResponse);
            }
            return WCs;
        }
    }
}

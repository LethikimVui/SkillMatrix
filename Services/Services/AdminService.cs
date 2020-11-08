using Newtonsoft.Json;
using Services.Interfaces;
using SharedObjects.Common;
using SharedObjects.Models;
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
    public class AdminService : BaseService, IAdminService
    {
        public async Task<ResponseResult> Add(AddEmployeeModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/employee/add", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }

      

        public async Task<List<VEmployee>> GetAll()
        {
            List<VEmployee> employees = new List<VEmployee>();

            using (var response = await httpClient.GetAsync("api/employee/get-all"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<VEmployee>>(apiResponse);
            }
            return employees;
        }

        public async Task<VEmployee> GetBySAP(string sap)
        {
            VEmployee employee = new VEmployee();

            using (var response = await httpClient.GetAsync("api/employee/search/" + sap))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<VEmployee>(apiResponse);
            }
            return employee;
        }
        public async Task<int> Count()
        {
            int count = 0;

            using (var response = await httpClient.GetAsync("api/employee/count"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                count = JsonConvert.DeserializeObject<int>(apiResponse);
            }
            return count;
        }
        public async Task<List<VEmployee>> GetPagination(PaginationViewModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            List<VEmployee> employees = new List<VEmployee>();

            using (var response = await httpClient.PostAsync("api/employee/pagination", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<VEmployee>>(apiResponse);
            }
            return employees;
        }
    }
}

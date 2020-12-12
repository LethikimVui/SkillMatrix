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
    public class SkillMatrixService : BaseService, ISkillMatrixService
    {
        public async Task<int> CountSkillMatrix(string input)
        {
            int count = 0;

            using (var response = await httpClient.GetAsync("api/ SkilMatrix/countskillmatrix/" + input))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                count = JsonConvert.DeserializeObject<int>(apiResponse);
            }
            return count;
        }

        public async Task<List<VSkillMatrix>> GetPaginationWithCondition(PaginationConditionViewModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            List<VSkillMatrix> skilmatrix = new List<VSkillMatrix>();

            using (var response = await httpClient.PostAsync("api/SkilMatrix/pagination", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                skilmatrix = JsonConvert.DeserializeObject<List<VSkillMatrix>>(apiResponse);
            }
            return skilmatrix;
        }

        public async Task<List<VSkillMatrix>> GetSkill(string sap)
        {
            List<VSkillMatrix> skillmatrix = new List<VSkillMatrix>();

            using (var response = await httpClient.GetAsync("api/SkilMatrix/getskill/" + sap))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                skillmatrix = JsonConvert.DeserializeObject<List<VSkillMatrix>>(apiResponse);
            }
            return skillmatrix;
        }

        public async Task<List<VTopicByTrainer>> GetTopicByTrainerNTID(string sap)
        {
            List<VTopicByTrainer> skillmatrix = new List<VTopicByTrainer>();

            using (var response = await httpClient.GetAsync("api/SkilMatrix/gettopicbyntid/" + sap))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                skillmatrix = JsonConvert.DeserializeObject<List<VTopicByTrainer>>(apiResponse);
            }
            return skillmatrix;
        }

        public async Task<ResponseResult> UpdateScore(UpdateScoreViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/SkilMatrix/updatescore", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }



    }
}

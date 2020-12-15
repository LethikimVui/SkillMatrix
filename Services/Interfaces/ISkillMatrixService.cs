using SharedObjects.Common;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISkillMatrixService
    {
        Task<List<VSkillMatrix>> GetSkill(string sap);
        Task<List<VTopicByTrainer>> GetTopicByTrainerNTID(string sap);
        Task<List<VSkillMatrix>> GetPaginationWithCondition(PaginationConditionViewModel model);
        Task<int> CountSkillMatrix(string input);
        Task<ResponseResult> UpdateScore(UpdateScoreViewModel model);
        Task<VResult> GetSingleResult(GetSingleResultViewModel model);

    }
}

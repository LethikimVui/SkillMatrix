using SharedObjects.Common;
using SharedObjects.Models;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<VEmployee>> GetAll();
        Task<VEmployee> GetBySAP(string sap);
        Task<List<VEmployee>> GetEmployeeBySAP(string sap);
        Task<ResponseResult> Add(AddEmployeeModel model);
        Task<List<VEmployee>> GetPagination(PaginationViewModel model);
        Task<int> Count();
        Task<List<VEmployee>> GetPaginationWithCondition(PaginationConditionViewModel model);
        Task<int> CountEmployeeWithCondition(string input);
        Task<ResponseResult> Update(UpdateEmployeeModel model);



    }
}

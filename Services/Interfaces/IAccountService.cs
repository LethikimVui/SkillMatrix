using SharedObjects.Common;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseResult> Login(LoginViewModel model);
        Task<ResponseResult> Add(CreateUserViewModel model, string token);
    }
}

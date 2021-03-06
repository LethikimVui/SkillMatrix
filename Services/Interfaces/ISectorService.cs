﻿using SharedObjects.Common;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISectorService
    {
        Task<List<VSector>> GetAll();
        Task<List<VSector>> GetAllNotActive();
        Task<VSector> FindSector(string sectorName);
        Task<ResponseResult> Add(AddSectorViewModel model);
        Task<ResponseResult> Delete(int id);
        Task<ResponseResult> Recover(int id);
    }
}

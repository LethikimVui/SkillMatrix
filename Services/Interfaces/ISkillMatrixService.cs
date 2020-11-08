using SharedObjects.ValueObjects;
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

    }
}

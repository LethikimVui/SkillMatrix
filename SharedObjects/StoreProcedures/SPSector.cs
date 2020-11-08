using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.StoreProcedures
{
    public class SPSector
    {
        public static string GetAll = "SP_GetSector";
        public static string AddSector = "SP_CreateSector @p0";
        public static string FindSector = "SP_FindSector @p0";

    }
}

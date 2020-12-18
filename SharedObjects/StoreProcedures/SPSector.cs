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
        public static string GetAllNotActive = "SP_GetSectorNotActive";
        public static string AddSector = "SP_CreateSector @p0";
        public static string FindSector = "SP_FindSector @p0";
        public static string Delete = "SP_DeleteSector @p0";
        public static string Recover = "SP_RecoverSector @p0";


    }
}

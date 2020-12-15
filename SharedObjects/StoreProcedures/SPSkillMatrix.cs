using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.StoreProcedures
{
    public class SPSkillMatrix
    {
        public static string SkillMatrix = "SP_SelectSkillMatrixByNTID @p0";
        public static string GetTopicByTrainerNTID = "SP_GetTopicByTrainerNTID @p0";

        public static string CountSkillMatrix = "SP_CountSkillMatrixByNTID @p0,@p1 OUT";
        public static string GetSkillMatrixPagination = "SP_GetSkillMatrixPagination @p0,@p1,@p2";

        public static string UpdateScore = "SP_UpdateScore @p0,@p1,@p2,@p3,@p4";
        public static string GetSingleResult = "SP_GetSingleResult @p0,@p1";



        

    }
}

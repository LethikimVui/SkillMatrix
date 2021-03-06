﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.StoreProcedures
{
    public class SPEmployee
    {
        public static string GetAll = "SP_GetAll";
        public static string GetBySAP = "SP_GetEmployeeBySAP @p0";
        public static string GetScoreBySAP = "SP_GetScoreBySAP @p0";
        public static string AddEmployee = "SP_AddEmployee @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7";

        public static string CountEmployee = "SP_CountEmployee @p0 OUT";
        public static string GetEmployeePagination = "SP_GetEmployeePagination @p0,@p1";

        public static string CountEmployeeWithCondition = "SP_CountEmployeeWithCondition @p0,@p1 OUT";
        public static string GetEmployeePaginationWithCondition = "SP_GetEmployeePaginationWithCondition @p0,@p1,@p2";

        public static string Update = "SP_UpdateEmployeeImage @p0,@p1";
        public static string GetImageBySAP = "SP_GetImageBySAP @p0";






    }
}

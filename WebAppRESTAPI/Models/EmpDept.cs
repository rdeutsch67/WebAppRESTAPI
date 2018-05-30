using System;
using System.Collections.Generic;

namespace WebAppRESTAPI.Models
{
    public class EmpDept
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Deptno { get; set; }
        public string Dname { get; set; }

    }
}
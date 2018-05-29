using System;
using System.Collections.Generic;

namespace WebAppRESTAPI.Models
{
    public partial class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public double? Sal { get; set; }
        public double? Comm { get; set; }
        public int? Deptno { get; set; }

        // public Dept DeptnoNavigation { get; set; }
    }
}

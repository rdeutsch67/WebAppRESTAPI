using System;
using System.Collections.Generic;

namespace WebAppRESTAPI.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emp = new HashSet<Emp>();
        }

        public int Deptno { get; set; }
        public string Dname { get; set; }
        public string Loc { get; set; }

        public ICollection<Emp> Emp { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppRESTAPI.Models
{
    public class EmpDataAccessLayer
    {

        ModelContext db = new ModelContext();

        public IEnumerable<Emp> GetAllEmployees()
        {
            try
            {
                return db.Emp.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Get the list of Departments
        public List<Dept> GetDepartments()
        {
            List<Dept> listDep = new List<Dept>();
            listDep = (from Dept in db.Dept select Dept).ToList();
            return listDep;
        }

    }
}

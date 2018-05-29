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

        //To Update the records of a particluar employee  
        public int UpdateEmployee(Emp employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record   
        public int AddEmployee(Emp employee)
        {
            try
            {
                db.Emp.Add(employee);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee  
        public int DeleteEmployee(int id)
        {
            try
            {
                Emp emp = db.Emp.Find(id);
                db.Emp.Remove(emp);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee  
        public Emp GetEmployeeData(int id)
        {
            try
            {
                Emp employee = db.Emp.Find(id);
                return employee;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppRESTAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppRESTAPI.Controllers
{
    public class EmployeeController : Controller
    {
        EmpDataAccessLayer objemployee = new EmpDataAccessLayer();

        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Emp> Index()
        {
            return objemployee.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] Emp employee)
        {
            return objemployee.AddEmployee(employee);
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Emp Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit([FromBody]Emp employee)
        {
            return objemployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("api/Employee/GetDeptList")]
        public IEnumerable<Dept> Details()
        {
            return objemployee.GetDepartments();
        }
    }
}

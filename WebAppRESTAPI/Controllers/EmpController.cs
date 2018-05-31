using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppRESTAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Devart.Data.Oracle;

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

        [HttpGet]
        [Route("api/GetEmpList")]
        //public IEnumerable<Emp> myIndex()
        //public IEnumerable<Emp> Json(List<Emp> searchresults, object allowGet)
        public IEnumerable<Emp> Json(List<Emp> searchresults)
        {            
            string mySelectQuery = "SELECT empno, ename, job, mgr, hiredate, sal, comm, deptno FROM Emp";
            OracleConnection myConnection = new OracleConnection(GlobalVar.OraDBConnString);
            OracleCommand myCommand = new OracleCommand(mySelectQuery, myConnection);
            myConnection.Open();

            OracleDataReader myReader = myCommand.ExecuteReader();
            try
            {
                //List<Emp> searchresults = new List<Emp>();

                while (myReader.Read())
                {
                    Emp sr = new Emp();
                    sr.Empno = Convert.ToInt32(myReader["Empno"]);
                    sr.Ename = myReader["Ename"].ToString();
                    sr.Job   = myReader["Job"].ToString();
                    if (myReader["Mgr"].GetType() != typeof(DBNull)) { sr.Mgr = Convert.ToInt32(myReader["Mgr"]); }
                    if (myReader["Hiredate"].GetType() != typeof(DBNull)) { sr.Hiredate = Convert.ToDateTime(myReader["Hiredate"]); }
                    if (myReader["Sal"].GetType() != typeof(DBNull)) { sr.Sal = Convert.ToDouble(myReader["Sal"]); }
                    if (myReader["Comm"].GetType() != typeof(DBNull)) { sr.Comm = Convert.ToDouble(myReader["Comm"]); }
                    if (myReader["Deptno"].GetType() != typeof(DBNull)) { sr.Deptno = Convert.ToInt32(myReader["Deptno"]); }

                    searchresults.Add(sr);
                }                

                //retrun json result
                return searchresults;                
            }
            finally
            {
                // always call Close when done reading.
                myReader.Close();
                // always call Close when done reading.
                myConnection.Close();
            }
        }

        [HttpGet]
        [Route("api/GetEmpDeptList")]
        public IEnumerable<EmpDept> MyIndex2()
        //public IEnumerable<Emp> Json(List<EmpDept> searchresEmpDept)
        {
            string mySelectQuery = "SELECT e.empno, e.ename, e.job, e.deptno, d.dname"   
                                   + " FROM emp e, dept d"
                                   + " where e.deptno = d.deptno";
            OracleConnection myConnection = new OracleConnection(GlobalVar.OraDBConnString);
            OracleCommand myCommand = new OracleCommand(mySelectQuery, myConnection);
            myConnection.Open();

            OracleDataReader myReader = myCommand.ExecuteReader();
            try
            {
                List<EmpDept> searchresEmpDept = new List<EmpDept>();

                while (myReader.Read())
                {
                    EmpDept sr = new EmpDept();
                    sr.Empno = Convert.ToInt32(myReader["Empno"]);
                    sr.Ename = myReader["Ename"].ToString();
                    sr.Job = myReader["Job"].ToString();
                    sr.Deptno = Convert.ToInt32(myReader["Deptno"]);
                    sr.Dname = myReader["Dname"].ToString();
                    
                    searchresEmpDept.Add(sr);

                }

                //build json result
                return searchresEmpDept;

            }
            finally
            {
                // always call Close when done reading.
                myReader.Close();
                // always call Close when done reading.
                myConnection.Close();
            }
        }


        void ModifyDept()
        {
            string myUpdateQuery = "UPDATE DEPT SET LOC='VEGAS' WHERE DEPTNO > 20";
            OracleConnection myConnection = new OracleConnection(GlobalVar.OraDBConnString);
            OracleCommand myCommand = new OracleCommand(myUpdateQuery, myConnection);
            //OracleCommand command = myConnection.CreateCommand();
            //command.CommandText = "UPDATE DEPT SET LOC='VEGAS' WHERE DEPTNO > 20";myConnection.Open();
            myConnection.Open();

            // return value of ExecuteNonQuery (i) is the number of rows affected by the command
            int i = myCommand.ExecuteNonQuery();
            Console.WriteLine(Environment.NewLine + "Rows in DEPT updated: {0}", i + Environment.NewLine);
        }

        [HttpPut]
        [Route("api/updatedeptloc")]
        public void Put([FromBody]string value)
        {
            ModifyDept();
        }        
    }
}

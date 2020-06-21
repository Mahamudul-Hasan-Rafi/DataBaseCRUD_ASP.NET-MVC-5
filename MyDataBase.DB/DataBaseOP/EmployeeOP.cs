using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataBase.Model;

namespace MyDataBase.DB.DataBaseOP
{
    public class EmployeeOP
    {
        public int AddEmployee(Employee employee)
        {
            using (var context = new EmplyeeEntities())
            {
                tbl_Employee _Employee = new tbl_Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    City = employee.City,
                    ZipCode = employee.ZipCode
                };

                context.tbl_Employee.Add(_Employee);
                context.SaveChanges();

                return _Employee.ID;
            }
        }

        public List<Employee> GetAllData()
        {
            using(var context=new EmplyeeEntities())
            {
                var list = context.tbl_Employee.
                    Select(x => new Employee()
                    {
                        ID = x.ID,
                        FirstName=x.FirstName,
                        LastName=x.LastName,
                        City=x.City,
                        ZipCode=x.ZipCode
                    }).ToList();

                return list;
            }
        }

        public Employee GetEmployeeDetails(int id)
        {
            using(var context = new EmplyeeEntities())
            {
                var result = context.tbl_Employee.Where(x => x.ID == id).
                    Select(x => new Employee()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        City = x.City,
                        ZipCode = x.ZipCode
                    }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateRecord(Employee employee)
        {
            using(var context = new EmplyeeEntities())
            {
                var emp = context.tbl_Employee.Where(x => x.ID == employee.ID).FirstOrDefault();

                if (emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.City = employee.City;
                    emp.ZipCode = employee.ZipCode;
                }

                context.SaveChanges();
                return true;
            }
           
        }

        public bool DeleteRecord(int id)
        {
            using (var context = new EmplyeeEntities())
            {
                var emp = context.tbl_Employee.Where(x => x.ID == id).FirstOrDefault();

                if (emp != null)
                {
                    context.tbl_Employee.Remove(emp);
                    context.SaveChanges();
                }
                return true;
            }
        }
    }
}

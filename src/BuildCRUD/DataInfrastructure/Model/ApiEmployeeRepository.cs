using DataInfrastructure.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInfrastructure.Infrastructure;
using System.Data.Entity.Validation;

namespace DataInfrastructure.Model
{
    public class ApiEmployeeRepository : IRepository<ApiEmployee>
    {
        
        public ApiEmployeeRepository()
        {
             
        }

        public ApiEmployee Add(ApiEmployee item)
        {
            ApiEmployee returnValue = null;

            using (var _context = new EmployeesEntities())
            {
                try
                {

                   
                    Employee user = _context.Employees.Add(item.AsEmployee());
                    _context.SaveChanges();

                    returnValue = user.AsApiEmployee();

                }
                catch (DbEntityValidationException ex)
                {
                    throw ex.DBValidationEntityExceptionAsFriendlyException();
                }
                catch (Exception ex)
                {
                    throw ex.EntityExceptionAsFriendlyException();
                }
            }

            return returnValue;
        }

        public ApiEmployee Add(ApiEmployee item, int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ApiEmployee Get(int id)
        {
            ApiEmployee em = new ApiEmployee();

            using (var context = new EmployeesEntities())
            {
               var  emplo = context.Employees.Where(p => p.id == id).FirstOrDefault();
                if (emplo != null)
                    em = emplo.AsApiEmployee();
            }
            return em;
        }

        public IEnumerable<ApiEmployee> GetAll()
        {
            List<ApiEmployee> List = new List<ApiEmployee>();

            using (var context = new EmployeesEntities())
            {
                foreach (Employee employee in context.Employees.ToList())
                    List.Add(employee.AsApiEmployee());
            }
            return List;
        }

        public IEnumerable<ApiEmployee> GetAll(string limiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            using (var context = new EmployeesEntities())
            {
                var employer = context.Employees.Where(p => p.id == id).FirstOrDefault();
                context.Employees.Attach(employer);
                context.Employees.Remove(employer);
                context.SaveChanges();
            }
        }

        public bool Update(ApiEmployee item)
        {
            using (var context = new EmployeesEntities())
            {
                var employer = context.Employees.Where(p => p.id == item.id).FirstOrDefault();
                employer.fullName = item.fullName;
                employer.aditional_info = item.aditional_info;
                employer.aditional_service = item.aditional_service;
                employer.another_building = item.another_building;
                employer.another_company = item.another_company;
                employer.fk_buildingaccess = item.fk_buildingaccess;
                employer.cellphone = item.cellphone;
                employer.email = item.email;
                employer.fk_companylist = item.fk_companylist;
                employer.fk_hiredfor = item.fk_hiredfor;
                employer.hiringManagerEmail = item.hiringManagerEmail;
                employer.initiationDate = item.initiationDate;
                employer.restricted_access = item.restricted_access;
                employer.service_equipmentneeded = item.service_equipmentneeded;
                employer.startDate = item.startDate;
                
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(ApiEmployee item, int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiEmployee
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public System.DateTime initiationDate { get; set; }
        public int fk_hiredfor { get; set; }
        public string email { get; set; }
        public string cellphone { get; set; }
        public System.DateTime startDate { get; set; }
        public string service_equipmentneeded { get; set; }
        public string aditional_service { get; set; }
        public Nullable<int> fk_companylist { get; set; }
        public string another_company { get; set; }
        public string aditional_info { get; set; }
        public string another_building { get; set; }
        public string restricted_access { get; set; }
        public string hiringManagerEmail { get; set; }
        public Nullable<int> fk_buildingaccess { get; set; }
    }
}

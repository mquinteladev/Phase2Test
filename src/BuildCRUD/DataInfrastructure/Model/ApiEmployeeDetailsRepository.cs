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
    public class ApiEmployeeDetailsRepository : IRepository<ApiEmployeeDetails>
    {
        
        public ApiEmployeeDetailsRepository()
        {
             
        }

        public ApiEmployeeDetails Add(ApiEmployeeDetails item)
        {
            throw new NotImplementedException();
        }

        public ApiEmployeeDetails Add(ApiEmployeeDetails item, int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ApiEmployeeDetails Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApiEmployeeDetails> GetAll()
        {
            List<ApiEmployeeDetails> List = new List<ApiEmployeeDetails>();

            using (var context = new EmployeesEntities())
            {
                foreach (EmployeeDetail employee in context.EmployeeDetails.ToList())
                    List.Add(employee.AsApiEmployeeDetails());
            }
            return List;
        }

        public IEnumerable<ApiEmployeeDetails> GetAll(string limiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiEmployeeDetails item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiEmployeeDetails item, int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiEmployeeDetails
    {
        public int id { get; set; }

        public string fullName { get; set; }

        public string email { get; set; }

        public string cellphone { get; set; }

        public string service_equipmentneeded { get; set; }

        public string aditional_service { get; set; }

        public string hiringManagerEmail { get; set; }

        public string restricted_access { get; set; }

        public string another_building { get; set; }

        public string companyName { get; set; }

        public string buildingName { get; set; }

        public string beinghiredFor { get; set; }
    }
}

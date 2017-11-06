using DataInfrastructure.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInfrastructure.Infrastructure;

namespace DataInfrastructure.Model
{
    public class ApiCompanyRepository : IRepository<ApiCompany>
    {
        
        public ApiCompanyRepository()
        {
             
        }

        public ApiCompany Add(ApiCompany item)
        {
            throw new NotImplementedException();
        }

        public ApiCompany Add(ApiCompany item, int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ApiCompany Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApiCompany> GetAll()
        {
            List<ApiCompany> List = new List<ApiCompany>();

            using (var context = new EmployeesEntities())
            {
                foreach (Company company in context.Companies.ToList())
                    List.Add(company.AsApiCompany());
            }
            return List;
        }

        public IEnumerable<ApiCompany> GetAll(string limiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiCompany item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiCompany item, int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiCompany
    {
        public int id { get; set; }
        public string labelDescription { get; set; }
    }
}

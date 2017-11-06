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
    public class ApiBeingHiredForRepository : IRepository<ApiBeingHiredFor>
    {
        
        public ApiBeingHiredForRepository()
        {
             
        }

        public ApiBeingHiredFor Add(ApiBeingHiredFor item)
        {
            throw new NotImplementedException();
        }

        public ApiBeingHiredFor Add(ApiBeingHiredFor item, int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ApiBeingHiredFor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApiBeingHiredFor> GetAll()
        {
            List<ApiBeingHiredFor> List = new List<ApiBeingHiredFor>();

            using (var context = new EmployeesEntities())
            {
                foreach (BeingHiredFor bhfr in context. BeingHiredFors.ToList())
                    List.Add(bhfr.AsApiBeingHiredFor());
            }
            return List;
        }

        public IEnumerable<ApiBeingHiredFor> GetAll(string limiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiBeingHiredFor item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiBeingHiredFor item, int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiBeingHiredFor
    {
        public int id { get; set; }
        public string labelDescription { get; set; }
    }
}

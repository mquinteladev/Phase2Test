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
    public class ApiBuildingRepository : IRepository<ApiBuilding>
    {
        
        public ApiBuildingRepository()
        {
             
        }

        public ApiBuilding Add(ApiBuilding item)
        {
            throw new NotImplementedException();
        }

        public ApiBuilding Add(ApiBuilding item, int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ApiBuilding Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApiBuilding> GetAll()
        {
            List<ApiBuilding> List = new List<ApiBuilding>();

            using (var context = new EmployeesEntities())
            {
                foreach (Building building in context.Buildings.ToList())
                    List.Add(building.AsApiBuilding());
            }
            return List;
        }

        public IEnumerable<ApiBuilding> GetAll(string limiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiBuilding item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiBuilding item, int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiBuilding
    {
        public int id { get; set; }
        public string labelDescription { get; set; }
    }
}

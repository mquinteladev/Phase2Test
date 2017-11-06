using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInfrastructure.Interfaces;
using DataInfrastructure.Model;

namespace DataInfrastructure
{
    static public class FactoryClass
    {
        public static IRepository<ApiEmployee> MakeEmployeeRepository()
        {
          return  new ApiEmployeeRepository();
        }

        public static IRepository<ApiBeingHiredFor> MakeBeingHiredForRepository()
        {
            return new ApiBeingHiredForRepository();
        }

        public static IRepository<ApiCompany> MakeCompanyRepository()
        {
            return new ApiCompanyRepository();
        }

        public static IRepository<ApiEmployeeDetails> MakeEmployeeDetailsRepository()
        {
            return new ApiEmployeeDetailsRepository();
        }

        public static IRepository<ApiBuilding> MakeBuildingRepository()
        {
            return new ApiBuildingRepository();
        }
    }
}

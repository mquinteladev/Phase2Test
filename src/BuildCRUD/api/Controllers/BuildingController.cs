using DataInfrastructure;
using DataInfrastructure.Interfaces;
using DataInfrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    [AllowAnonymous]
    public class BuildingController : ApiController
    {

        private readonly IRepository<ApiBuilding> _repository;


        public BuildingController()
        {

            _repository = FactoryClass.MakeBuildingRepository();
        }


        public IEnumerable<ApiBuilding> GetAllEmployees()
        {

            try
            {

                return _repository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return new List<ApiBuilding>();
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

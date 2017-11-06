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
    public class CompanyController : ApiController
    {

        private readonly IRepository<ApiCompany> _repository;


        public CompanyController()
        {

            _repository = FactoryClass.MakeCompanyRepository();
        }


        public IEnumerable<ApiCompany> GetAllEmployees()
        {

            try
            {

                return _repository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return new List<ApiCompany>();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web;
using DataInfrastructure.Model;
using DataInfrastructure.Interfaces;
using DataInfrastructure;

namespace CRUD.Controllers
{
    [AllowAnonymous]
    public class EmployeeDetailsController : ApiController
    {
      
        private readonly IRepository<ApiEmployeeDetails> _repository;


        public EmployeeDetailsController(  )
        {
         
            _repository = FactoryClass.MakeEmployeeDetailsRepository();
        }

     
        public IEnumerable<ApiEmployeeDetails> GetAllEmployeeDetails()
        {

            try
            {
            
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                 
            }
            return new List<ApiEmployeeDetails>();
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

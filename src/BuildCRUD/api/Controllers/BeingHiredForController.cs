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
    public class BeingHiredForController : ApiController
    {
      
        private readonly IRepository<ApiBeingHiredFor> _repository;


        public BeingHiredForController(  )
        {
         
            _repository = FactoryClass.MakeBeingHiredForRepository();
        }

     
        public IEnumerable<ApiBeingHiredFor> GetAllEmployees()
        {

            try
            {
            
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                 
            }
            return new List<ApiBeingHiredFor>();
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

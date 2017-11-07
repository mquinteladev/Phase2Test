using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataInfrastructure.Model;
using DataInfrastructure.Interfaces;
using DataInfrastructure;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class ApiEmployeeRepository_UnitTest
    {
        [TestMethod]
        public void Add_ApiEmployeeAsParameter_ExpectedInsertedRow()
        {
            ApiEmployee item = new ApiEmployee();
            item.aditional_info = "additional info from UnitTest";
            item.aditional_service = "additional service from UnitTest";
            item.another_building = "CheckAlt Building";
            item.another_company = "CheckAlt Company";
            item.cellphone = "777-777-7777";
            item.email = "unitTest@gmail.com";
            item.fk_buildingaccess = 1;
            item.fk_companylist = 1;
            item.fk_hiredfor = 1;
            item.fullName = "Unit Test Phase 2"; 
            item.hiringManagerEmail = "donaldTrump@gmail.com";
            item.initiationDate = DateTime.Now;
            item.restricted_access = ""; 
            item.service_equipmentneeded = "Laptop"; 
            item.startDate = DateTime.Now;
            IRepository<ApiEmployee> _repository = FactoryClass.MakeEmployeeRepository();
            ApiEmployee employeerow = _repository.Add(item);
            Assert.IsTrue(employeerow.email == "unitTest@gmail.com" && employeerow.service_equipmentneeded == "Laptop");
        }

        [TestMethod]
        public void GetAll_EmptyParameter_ExpectedLengthGraterThanZero()
        { 
            IRepository<ApiEmployee> _repository = FactoryClass.MakeEmployeeRepository(); 
            List<ApiEmployee> allEmployee = _repository.GetAll().ToList();
            Assert.IsTrue(allEmployee.Count >0); 
        }

        [TestMethod]
        public void Get_EmptyIDParameter_ExpectedObjectnotNUll()
        {
            IRepository<ApiEmployee> _repository = FactoryClass.MakeEmployeeRepository();
            List<ApiEmployee> allEmployee = _repository.GetAll().ToList();
            int id = allEmployee.FirstOrDefault().id;
            ApiEmployee employee = _repository.Get(id);
            Assert.IsTrue(employee != null);
        }

    }
}

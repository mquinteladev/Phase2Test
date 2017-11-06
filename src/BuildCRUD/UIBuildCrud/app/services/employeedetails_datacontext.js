(function () {
    'use strict';

    var serviceId = 'employeedetails_datacontext';
    angular.module('app').factory(serviceId, ['common', 'API_HTTP', employeedetails_datacontext]);

    function employeedetails_datacontext(common, API_HTTP) {

      
        var service = {
            getEmployeeDetailsList: getEmployeeDetailsList
        };

        return service;
         
 
        function getEmployeeDetailsList(callback, errorcallback) {
            return API_HTTP.$http('/api/EmployeeDetails', 'GET', {}, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }

        


    }
})();
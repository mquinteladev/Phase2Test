(function () {
    'use strict';

    var serviceId = 'employee_datacontext';
    angular.module('app').factory(serviceId, ['common', 'API_HTTP', employee_datacontext]);

    function employee_datacontext(common, API_HTTP) {

      
        var service = {
            getEmployeeList: getEmployeeList,
            getEmployee: getEmployee,
            postEmployee: postEmployee,
            putEmployee: putEmployee,
            deleteEmployee: deleteEmployee
        };

        return service;
         

        function deleteEmployee(id, callback, errorcallback) {
            return API_HTTP.$http('/api/Employees/'+id, 'DELETE', {}, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }

        function putEmployee(data, callback, errorcallback) {
            return API_HTTP.$http('/api/Employees/' + data.id, 'PUT', data, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }

        function postEmployee(data, callback, errorcallback) {
            return API_HTTP.$http('/api/Employees/' , 'POST', data, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }
  
        function getEmployeeList(callback, errorcallback) {
            return API_HTTP.$http('/api/Employees', 'GET', {}, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }


        function getEmployee(id, callback, errorcallback) {
            return API_HTTP.$http('/api/Employees/'+id, 'GET', {}, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }

        


    }
})();
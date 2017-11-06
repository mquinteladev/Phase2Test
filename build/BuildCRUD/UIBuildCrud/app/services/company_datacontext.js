(function () {
    'use strict';

    var serviceId = 'company_datacontext';
    angular.module('app').factory(serviceId, ['common', 'API_HTTP', company_datacontext]);

    function company_datacontext(common, API_HTTP) {

      
        var service = {
            getCompanyList: getCompanyList
        };

        return service;
         

  
        function getCompanyList(callback, errorcallback) {
            return API_HTTP.$http('/api/Company', 'GET', {}, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }

        


    }
})();
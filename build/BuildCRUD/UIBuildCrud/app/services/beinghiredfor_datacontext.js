(function () {
    'use strict';

    var serviceId = 'beinghiredfor_datacontext';
    angular.module('app').factory(serviceId, ['common', 'API_HTTP', beinghiredfor_datacontext]);

    function beinghiredfor_datacontext(common, API_HTTP) {

      
        var service = {
            getHiredForList: getHiredForList
        };

        return service;
         

  
        function getHiredForList(callback, errorcallback) {
            return API_HTTP.$http('/api/BeingHiredFor', 'GET', {}, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }

        


    }
})();
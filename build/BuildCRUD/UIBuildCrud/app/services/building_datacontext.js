(function () {
    'use strict';

    var serviceId = 'building_datacontext';
    angular.module('app').factory(serviceId, ['common', 'API_HTTP', building_datacontext]);

    function building_datacontext(common, API_HTTP) {

      
        var service = {
            getBuildingList: getBuildingList
        };

        return service;
         

  
        function getBuildingList(callback, errorcallback) {
            return API_HTTP.$http('/api/Building', 'GET', {}, function (response) {
                if (callback != null)
                    callback(response);
            }, function (response) {
                if (errorcallback != null && errorcallback != undefined)
                    errorcallback(response.data.Message);
            });
        }

        


    }
})();
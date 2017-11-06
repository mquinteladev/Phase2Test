(function () {
    'use strict';

    var serviceId = 'API_HTTP';
    angular.module('app').factory(serviceId, ['common', 'appSettings', '$location', '$http', API_HTTP]);

    function API_HTTP(common, appSettings, $location, $http) {
        var logLive = common.logger.logger_live;
        var $q = common.$q;
        var URL ="";
        function _http(url,method,data,OnSucces,OnError) {

            url = appSettings.serverPath+url;
		
            if(method == undefined || method == null)
                method = "GET";


            var configuration = {
            };

           
            var _GET = function () {
                
             
             function _request()
                {
                  return  $http.get(url, configuration).then(function Succes(response) {
                        OnSucces(response);
                  }, function Error(response) {
                      if (response.status != 401 || response.status != 403)
                          OnError(response);
                      
                    })
                }

              return  _request();
            };

            var _POST = function() {
                function _request() {
                    return $http.post(url, data, configuration).then(function Succes(response) {
                        OnSucces(response);
                    }, function Error(response) {
                        if (response.status != 401 || response.status != 403)
                            OnError(response);
                      
                    })
                }

                return _request();
            };

            var _PUT = function() {

                function _request() {
                    return $http.put(url,data, configuration).then(function Succes(response) {
                        OnSucces(response);
                    }, function Error(response) {
                        if (response.status != 401 || response.status != 403)
                            OnError(response);
                         
                    })
                }

                return _request();
            };
			
            var _DELETE = function() {
                function _request() {
                    return $http.delete(url, data, configuration).then(function Succes(response) {
                        OnSucces(response);
                    }, function Error(response) {
                        if (response.status != 401 || response.status != 403)
                            OnError(response);
                        
                    })
                }

                return _request();
            };
			
            
            function _ProccessRequest()
            {
                switch(method) {
                    case "POST":
                        return _POST();
                        break;
                    case "DELETE":
                        _DELETE();
                        break;
                    case "GET":
                        return _GET();
                        break;
                    case "PUT":
                        return _PUT();
                        break;
                } 
            }

            _ProccessRequest();
 
        }

        
        var service = {
            $http: _http 
        };

        return service;

        
    };

})();
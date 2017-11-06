(function () {
    'use strict';
     
    var serviceId = 'API_HTTP_INTERCEPTOR';
    angular.module('app').factory(serviceId, ['$q', 'common', '$cookieStore', 'dynamicLocalStore', API_HTTP_INTERCEPTOR]);

    function API_HTTP_INTERCEPTOR($q, common, $cookies, dynamicLocalStore) {

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logLive = common.logger.logger_live;

         function request(config) {
            


             if (config.url.indexOf("html") == -1) {
                 config.headers['Content-Type'] = 'application/json; charset=utf-8'; 
                 config.headers['X-Requested-With'] = 'XMLHttpRequest';
                 config.headers['Accept'] = 'application/json';
                 
                 if (dynamicLocalStore.profile.token != "" && dynamicLocalStore.profile.token != undefined && config.url.indexOf("/api/auth") == -1 && config.url.indexOf("/api/account") == -1 && config.url.indexOf("/api/BankConfiguration") == -1 && config.url.indexOf("/api/UserResetPassword") == -1)
                     config.headers['Authorization'] = "Bearer " + dynamicLocalStore.profile.token;
                 else
                     if (dynamicLocalStore.profile.guestUID != "" && dynamicLocalStore.profile.token != "" && dynamicLocalStore.profile.token != undefined && config.url.indexOf("/api/auth") == -1 && config.url.indexOf("/api/account") == -1 && config.url.indexOf("/api/UserResetPassword") == -1)
                         config.headers['Authorization'] = "Bearer " + dynamicLocalStore.profile.tokenGuestUID;
                }

            return config;
         }

        
 
 

        // optional method
         function response (response) {
             try {
             //    logLive(JSON.stringify(response), "ERROR");
             } catch (e) {

             }
            return response;
        }
        
        // Intercept the failed request.
         function requestError(rejection) {
             try {
              //   logLive(JSON.stringify(rejection), "ERROR");
             } catch (e) {

             }
             return ($q.reject(rejection));
         }


        // Intercept the failed response.
         function responseError(response) {
             try {
                // logLive(JSON.stringify(response), "ERROR");
             } catch (e) {

             }
             return ($q.reject(response));
         }


         return {

             request: request,
             requestError: requestError,
             response: response,
             responseError: responseError
        };
    };

    angular.module('app').config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('LPAPI_HTTP_INTERCEPTOR');
    }]);

})();

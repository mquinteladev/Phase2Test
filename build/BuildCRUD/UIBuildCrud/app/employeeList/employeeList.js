(function () {
    'use strict';
    var controllerId = 'employeeList';
    angular.module('app').controller(controllerId, ['common', 'employee_datacontext', 'employeedetails_datacontext', 'scopesService', '$location', employeeList]);

    function employeeList(common, employee_datacontext, employeedetails_datacontext, scopesService, $location) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        var vm = this;
        vm.title = 'All Employee';

        activate();

        function Remove(id) {
            employee_datacontext.deleteEmployee(id,function(response){
                employeedetails_datacontext.getEmployeeDetailsList(function (response) {
                    vm.employees = response.data;
                }, _errorcallback); 
            },_errorcallback);
        }

        vm.Remove = Remove;

        function _errorcallback(response) {
            vm.isBusy = false;
            logError(response);
        }


        vm.Update = Update;
        function Update(id) {
            scopesService.store('employee', id);
            $location.path("/newemployee");
        }
       

        function activate() {
            common.activateController([], controllerId)
                .then(function () {

                    log('Activated Employee List View');

                    employeedetails_datacontext.getEmployeeDetailsList(function (response) {
                        vm.employees = response.data;
                    }, _errorcallback);


                });
        }
    }
})();
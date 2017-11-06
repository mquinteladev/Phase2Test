(function () {
    'use strict';
    var controllerId = 'employeeList';
    angular.module('app').controller(controllerId, ['common', 'employee_datacontext', employeeList]);

    function employeeList(common, employee_datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        var vm = this;
        vm.title = 'All Employee';

        activate();


        function _errorcallback(response) {
            vm.isBusy = false;
            logError(response);
        }

        function activate() {
            common.activateController([], controllerId)
                .then(function () {

                    log('Activated Employee List View');

                    employee_datacontext.getEmployeeList(function (response) {
                        vm.employees = response.data;
                    }, _errorcallback);


                });
        }
    }
})();
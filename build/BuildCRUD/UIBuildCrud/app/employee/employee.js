(function () {
    'use strict';
    var controllerId = 'employee';
    angular.module('app').controller(controllerId, ['common', 'beinghiredfor_datacontext', 'company_datacontext', 'building_datacontext', 'employee_datacontext', '$location', 'scopesService', employee]);

    function employee(common, beinghiredfor_datacontext, company_datacontext, building_datacontext, employee_datacontext, $location, scopesService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        var vm = this; 
        vm.title = 'New Employee Initiation';

        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;
        vm.spinnerOptions = {
            radius: 40,
            lines: 7,
            length: 0,
            width: 30,
            speed: 1.7,
            corners: 1.0,
            trail: 100,
            color: '#F58A00'
        };


        var viewModel = {
            form: {
             id: 0,
             fullName:"",
             initiationDate:"", 
             fk_hiredfor:-1,
             email:"",
             cellphone:"",
             startDate:"",
             service_equipmentneeded :"",
             aditional_service:"",
             fk_companylist:-1,
             another_company:"",
             aditional_info:"",
             fk_buildingaccess: null,
             another_building:"",
             restricted_access: "",
             hiringManagerEmail:""
            },
            operation: "Insert",
            ButtonLabel: "Save",
            companyList: [],
            buildingList: [],
            beingHiredForList: [],
            service_equipmentneededList: [
                 { id: '1', equipmentneeded: 'Company email' },
                  { id: '2', equipmentneeded: 'Opus login' },
                  { id: '3', equipmentneeded: 'Desk' },
                  { id: '4', equipmentneeded: 'Computer' },
                  { id: '5', equipmentneeded: 'Landline extension' },
                  { id: '6', equipmentneeded: 'Company mobile phone' },
                  { id: '7', equipmentneeded: 'Company laptop' }, 
                  { id: '8', equipmentneeded: 'ADP (includes being enrolled in time clock)' },
            ],
            
            StartDatedatepickerOptions: {

                format: 'mm/dd/yyyy',
                language: 'en',
                //startDate: new Date(),
                //endDate: 0,
                autoclose: true,
                weekStart: 0
            }, 
            openStartDatePicker: function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                this.StartDateOpened = true;
            },
            StartDateOpened: false,
            openInitiationDatePicker: function ($event) {
                $event.preventDefault();
                $event.stopPropagation();

                this.EndDateOpened = true;
            },
            InitiationDateOpened: false,
            InitiationDatedatepickerOptions: {
                format: 'mm/dd/yyyy',
                language: 'en',
                //startDate: 0,
                //endDate: 0,
                autoclose: true,
                weekStart: 0
            },
            dateDisabled: function (date, mode) {
                var currentDate = new Date();
                currentDate.setHours(date.getHours())
                currentDate.setMinutes(date.getMinutes())
                currentDate.setSeconds(date.getSeconds())
                currentDate.setMilliseconds(date.getMilliseconds())

                var inputDate = new Date();

                inputDate.setFullYear(date.getFullYear());
                inputDate.setMonth(date.getMonth());
                inputDate.setDate(date.getDate());

                inputDate.setHours(date.getHours());
                inputDate.setMinutes(date.getMinutes());
                inputDate.setSeconds(date.getSeconds());
                inputDate.setMilliseconds(date.getMilliseconds());

                
                return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6 || inputDate.getTime() < currentDate.getTime()  ));
            },
            Save: Save,
            Cancel: Cancel, 
        }

        viewModel.operationCount = 1;


        function checkboxchange()
        {
            vm.viewModel.form.service_equipmentneeded = "";
            $('input:checkbox:checked').each(function () {
                var sThisVal = (this.checked ? $(this).val() : "");
                if (vm.viewModel.form.service_equipmentneeded == "")
                    vm.viewModel.form.service_equipmentneeded = sThisVal;
                else
                    vm.viewModel.form.service_equipmentneeded = vm.viewModel.form.service_equipmentneeded + ',' + sThisVal;
            });
        }

        vm.checkboxchange = checkboxchange;


        function Back() {
            vm.viewModel.operationCount--;
        }
        viewModel.Back = Back;

        function Next(form) {

             

            if (vm.viewModel.operationCount == 1) {

                if (vm.viewModel.form.fk_hiredfor == "" || vm.viewModel.form.fk_hiredfor == -1) {
                    form['fk_hiredfor'].$invalid = true;
                    form['fk_hiredfor'].$valid = false;
                    form['fk_hiredfor'].$setPristine();
                    return false;
                }
                else 
                    if (vm.viewModel.form.startDate != "" && vm.viewModel.form.hiringManagerEmail != "" && vm.viewModel.form.fullName != "" && vm.viewModel.form.fk_hiredfor != -1 && vm.viewModel.form.email != "" && vm.viewModel.form.cellphone != "" && vm.viewModel.form.initiationDate!="")
                      vm.viewModel.operationCount++; 
            }
            else
                if (vm.viewModel.operationCount == 2) {

                    if (vm.viewModel.form.service_equipmentneeded == "" || vm.viewModel.form.service_equipmentneeded == null) {
                     ;
                    }
                    else
                        vm.viewModel.operationCount++;


                }
                else
                    if (vm.viewModel.operationCount == 3) {

                        if (vm.viewModel.form.fk_companylist == "" || vm.viewModel.form.fk_companylist == -1) {
                            form['fk_companylist'].$invalid = true;
                            form['fk_companylist'].$valid = false;
                            form['fk_companylist'].$setPristine();
                            return false;
                        }
                        else
                            vm.viewModel.operationCount++; 
                    }
                    else
                        if (vm.viewModel.operationCount == 4) {

                            if (vm.viewModel.form.fk_buildingaccess == "" || vm.viewModel.form.fk_buildingaccess == -1 || vm.viewModel.form.fk_buildingaccess == null) {
                                form['fk_buildingaccess'].$invalid = true;
                                form['fk_buildingaccess'].$valid = false;
                                form['fk_buildingaccess'].$setPristine();
                                vm.viewModel.form.fk_buildingaccess = -1;
                                return false;
                            }
                            else
                                vm.viewModel.operationCount++;
                        }
                    else
                            vm.viewModel.operationCount++;
            return true;
        }

        viewModel.Next = Next;

        function Save(form) {

            $('input:checkbox:checked').each(function () {
                var sThisVal = (this.checked ? $(this).val() : "");
                if (vm.viewModel.form.service_equipmentneeded == "")
                    vm.viewModel.form.service_equipmentneeded = sThisVal;
                else
                  vm.viewModel.form.service_equipmentneeded = vm.viewModel.form.service_equipmentneeded+ ',' + sThisVal;
            });

            if (form.$valid) {
                if (CheckValidForm(form) == true) {
                    vm.isBusy = true;

                    if (vm.viewModel.operation == "Insert")
                        employee_datacontext.postEmployee(vm.viewModel.form, _callback, _errorcallback);
                    else
                        employee_datacontext.putEmployee(vm.viewModel.form, _callback, _errorcallback);
                }
            }
        }

        function _callback(response) { 
            vm.isBusy = false;
            log('Your request has been forwarded to the appropriate departments. You will be updated as your request is fulfilled.');
            $location.path("/");
            return;
        }

        function CheckValidForm(form) {
          return  Next(form);
        }


        viewModel.Save = Save;

        function Cancel()
        { }

        function _errorcallback(response) {
            vm.isBusy = false;
            logError(response);
        }


        vm.viewModel = viewModel;

        activate();

        function activate() {
            var promises = [ ];
            common.activateController(promises, controllerId)
                .then(function () {
                    
                    log('Activated Employee View');
                    _fillOutForm(function ()
                    {

                        beinghiredfor_datacontext.getHiredForList(function (response) {
                            vm.viewModel.beingHiredForList = response.data;
                            vm.isBusy = false;

                            company_datacontext.getCompanyList(function (response) {
                                vm.viewModel.companyList = response.data;

                                building_datacontext.getBuildingList(function (response) {
                                    vm.viewModel.buildingList = response.data;

                                }, _errorcallback);

                            }, _errorcallback);


                        }, _errorcallback);

                    });
                    

                });
        }

        function _fillOutForm(_callback)
        {
            var id = scopesService.get("employee");
            if (id != undefined && id != null) {
                vm.viewModel.operation = "Update";
                vm.title = 'Update Employee';

                vm.viewModel.form.id = id;

                employee_datacontext.getEmployee(id, function (response) {
                    vm.viewModel.form = response.data;
                    scopesService.store('employee', null);


                    var equipments = vm.viewModel.form.service_equipmentneeded.split(',');


                    for (var i = 0; i < equipments.length; i++) {
                        $("input[type=checkbox][value='" + equipments[i] + "']").prop("checked", true);
                        
                    }

                    vm.viewModel.form.service_equipmentneeded = "";
                    vm.checkboxchange();
                    _callback();
                }, _errorcallback);
                 
            }
            else
                _callback();

        }

        
    }
})();
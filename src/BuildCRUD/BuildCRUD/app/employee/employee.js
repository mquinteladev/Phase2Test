(function () {
    'use strict';
    var controllerId = 'employee';
    angular.module('app').controller(controllerId, ['common', 'beinghiredfor_datacontext', 'company_datacontext', 'building_datacontext', 'employee_datacontext', employee]);

    function employee(common, beinghiredfor_datacontext, company_datacontext, building_datacontext, employee_datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        var vm = this; 
        vm.title = 'Employee Initiation';

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
             building_access:"",
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

        function Back() {
            vm.viewModel.operationCount--;
        }
        viewModel.Back = Back;

        function Next()
        {
            vm.viewModel.operationCount++;
        }

        viewModel.Next = Next;

        function Save(form) {

            $('input:checkbox.class').each(function () {
                var sThisVal = (this.checked ? $(this).val() : "");
                m.viewModel.form.service_equipmentneeded = sThisVal;
            });


            if (CheckValidForm(form) == true) {
                vm.isBusy = true;
                employee_datacontext.postEmployee(vm.viewModel.form, _callback, _errorcallback);
            }
        }

        function _callback(response) { 
            vm.isBusy = false;
            log('Employee saved.'); 
        }

        function CheckValidForm(form) {
            var result = true;

            //if (vm.viewModel.form.state == "" || vm.viewModel.form.state == null) {
            //    form.State.$invalid = true;
            //    form.State.$valid = false;
            //    form.State.$setPristine();
            //    result = false;
            //}


            if (result == true)

                result = true;
            else
                result = false;


            return result;
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

                    beinghiredfor_datacontext.getHiredForList(function (response)
                    {
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
        }

      

        
    }
})();
(function () {
    "use strict";

    angular
        .module("common")
        .factory("scopesService", ["$rootScope", scopesService])

    function scopesService($rootScope)
    {
        var mem = {};

        return {
            store: function (key, value) {
                $rootScope.$emit('scope.stored', key);
                mem[key] = value;
            },
            get: function (key) {
                return mem[key];
            }
        };
    }
})();
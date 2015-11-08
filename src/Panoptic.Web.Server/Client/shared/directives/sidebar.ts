///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.shared {
    angular.module('panoptic.shared')
        .directive('sidebar',
        function () {
            return {
                restrict: 'EA',
                scope: {
                    teams: "=",
                },
                templateUrl: 'client/shared/directives/SideBar.html'
            };
        });
}

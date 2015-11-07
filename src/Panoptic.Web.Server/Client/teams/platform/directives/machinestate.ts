///<reference path="../../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.teams.platform
{
    angular.module('panoptic.teams.platform')
        .directive('machineState',
            function ()
            {
                return {
                    restrict: 'EA',
                    scope: {
                        machine: "="
                    },
                    templateUrl: 'client/teams/platform/directives/MachineState.html'
                };
            });
}

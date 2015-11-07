///<reference path="../../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.teams.platform
{
    angular.module('panoptic.teams.platform')
        .directive('serviceState',
            function ()
            {
                return {
                    restrict: 'EA',
                    scope: {
                        service: "="
                    },
                    templateUrl: 'client/teams/platform/directives/ServiceState.html'
                };
            });
}

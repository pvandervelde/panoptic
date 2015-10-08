///<reference path="../../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.teams.development
{
    angular.module('panoptic.teams.development')
        .directive('buildState',
            function ()
            {
                return {
                    restrict: 'EA',
                    scope: {
                        build: "="
                    },
                    templateUrl: 'client/teams/development/directives/BuildState.html'
                };
            });
}

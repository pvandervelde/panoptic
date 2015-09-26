///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.ops
{
    angular.module('panoptic.ops')
        .directive('serviceState',
            function ()
            {
                return {
                    restrict: 'EA',
                    scope: {
                        service: "="
                    },
                    templateUrl: 'client/ops/directives/ServiceState.html'
                };
            });
}

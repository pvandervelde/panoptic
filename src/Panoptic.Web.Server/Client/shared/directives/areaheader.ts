///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.shared
{
    angular.module('panoptic.shared')
        .directive('areaHeader',
            function ()
            {
                return {
                    restrict: 'EA',
                    scope: {
                        name: "=",
                        description: "=",
                    },
                    templateUrl: 'client/shared/directives/AreaHeader.html'
                };
            });
}

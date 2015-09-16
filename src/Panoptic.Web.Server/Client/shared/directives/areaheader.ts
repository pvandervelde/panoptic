///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.shared
{
    angular.module('panoptic.shared')
        .directive('areaHeader',
            function ()
            {
                return {
                    templateUrl: 'Client/shared/directives/areaHeader.html'
                };
            });
}

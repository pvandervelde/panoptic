///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.shared.directives
{
    angular.module('panoptic.shared.directives', [])
        .directive('areaHeader',
            function ()
            {
                return {
                    templateUrl: 'Client/shared/directives/areaHeader.html'
                };
            });
}

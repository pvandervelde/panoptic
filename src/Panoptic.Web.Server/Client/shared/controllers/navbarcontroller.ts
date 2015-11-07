///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../Scripts/typings/restangular/restangular.d.ts" />

///<reference path="../../core/modules/globals.ts" />

///<reference path="../modules/areas.ts" />

module panoptic.shared
{
    interface INavbarScope extends ng.IScope
    {
        navigate: (path: string) => void;
        areas: Array<panoptic.shared.IAreaInformation>;
    }

    class NavbarController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: INavbarScope,
            private areaService: panoptic.shared.IAreaService)
        {
            super();
            $scope.navigate = function (path: string)
            {
                $location.path(path);
            };

            areaService.getAreas()
                .success(function (data)
                {
                    $scope.areas = new Array<panoptic.shared.IAreaInformation>();
                    angular.forEach(data, function (area: panoptic.shared.IAreaInformation)
                    {
                        $scope.areas.push(area);
                    });
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('error');
                });
        }
    }

    angular.module('panoptic.shared')
        .controller('NavbarController', ['$location', '$scope', 'areaService',
            function (
                $location: ng.ILocationService,
                $scope: INavbarScope,
                areaService: panoptic.shared.IAreaService)
            {
                return new NavbarController($location, $scope, areaService);
            }]);
}


///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../Scripts/typings/restangular/restangular.d.ts" />

///<reference path="../../core/modules/globals.ts" />

///<reference path="../modules/areas.ts" />

module panoptic.shared.controllers
{
    interface INavbarScope extends ng.IScope
    {
        navigate: (path: string) => void;
        areas: Array<panoptic.shared.modules.IAreaInformation>;
    }

    class NavbarController extends panoptic.core.controllers.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: INavbarScope,
            private areaService: panoptic.shared.services.IAreaService)
        {
            super();
            $scope.navigate = function (path: string)
                {
                    $location.path(path);
                };

            $scope.areas = new Array<panoptic.shared.modules.IAreaInformation>();
            areaService.getAreas()
                .success(function (data)
                    {
                        angular.forEach(data, function (area: panoptic.shared.modules.IAreaInformation)
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

    angular.module('panoptic.shared.controllers',
        [
            'panoptic.shared.services'
        ])
        .controller('navbarController', ['$location', '$scope', 'panoptic.shared.services.AreaService',
            function (
                $location: ng.ILocationService,
                $scope: INavbarScope,
                areaService: panoptic.shared.services.IAreaService)
            {
                    return new NavbarController($location, $scope, areaService);
            }]);
}


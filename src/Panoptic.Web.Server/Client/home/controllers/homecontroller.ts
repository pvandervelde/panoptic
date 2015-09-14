﻿///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../Scripts/typings/restangular/restangular.d.ts" />

///<reference path="../../shared/modules/areas.ts" />
///<reference path="../../shared/services/areaservice.ts" />

module panoptic.controllers
{
    interface IHomeScope extends ng.IScope
    {
        navigate: (path: string) => void;
        areas: Array<Array<panoptic.shared.modules.IAreaInformation>>;
        areaName: string;
        areaDescription: string;
    }

    class HomeController extends panoptic.core.controllers.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IHomeScope,
            private areaService: panoptic.shared.services.IAreaService)
        {
            super();

            function divideIntoColumns(arr: any[], size: number)
            {
                var newArr = [];
                for (var i = 0; i < arr.length; i += size)
                {
                    newArr.push(arr.slice(i, i + size));
                }
                return newArr;
            }

            $scope.navigate = function (path: string)
            {
                $location.path(path);
            };

            $scope.areaName = 'Home';
            $scope.areaDescription = 'some long text thing that just goes on for ever and ever and ever';

            $scope.areas = new Array<Array<panoptic.shared.modules.IAreaInformation>>();
            areaService.getAreas()
                .success(function (data)
                {
                    var newArr = [];
                    angular.forEach(data, function (area: panoptic.shared.modules.IAreaInformation)
                    {
                        newArr.push(area);
                    });

                    $scope.areas = divideIntoColumns(newArr, 3)
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('error');
                });
        }
    }

    angular.module('panoptic.home.controllers',
        [
            'panoptic.shared.services'
        ])
        .controller('HomeController', ['$location', '$scope', 'panoptic.shared.services.AreaService',
            function (
                $location: ng.ILocationService,
                $scope: IHomeScope,
                areaService: panoptic.shared.services.IAreaService)
            {
                return new HomeController($location, $scope, areaService);
            }]);
}

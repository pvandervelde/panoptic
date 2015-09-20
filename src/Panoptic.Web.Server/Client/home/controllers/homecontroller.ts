///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../Scripts/typings/restangular/restangular.d.ts" />

///<reference path="../../shared/modules/areas.ts" />
///<reference path="../../shared/services/areaservice.ts" />

module panoptic.home
{
    interface IHomeScope extends ng.IScope
    {
        navigate: (path: string) => void;
        areas: Array<Array<panoptic.shared.IAreaInformation>>;
        areaName: string;
        areaDescription: string;
    }

    class HomeController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IHomeScope,
            private descriptionService: panoptic.home.IHomeDescriptionService,
            private areaService: panoptic.shared.IAreaService)
        {
            super();

            function divideIntoColumns(arr: any[], size: number)
            {
                var newArr = [];
                for (var i = 0; i < size; i++)
                {
                    var column = [];
                    newArr.push(column);
                }

                for (var i = 0; i < arr.length; i += size)
                {
                    for (var j = 0; j < size; j++)
                    {
                        newArr[j].push(arr[i + j]);
                    }
                }
                return newArr;
            }

            $scope.navigate = function (path: string)
            {
                $location.path(path);
            };

            descriptionService.getDescription()
                .success(function (data)
                {
                    $scope.areaName = data.Name;
                    $scope.areaDescription = data.Description;
                    $scope.$apply();
                })
                .error(function (data)
                {
                    alert('failed to get the name and description for the home area.');
                });

            $scope.areas = new Array<Array<panoptic.shared.IAreaInformation>>();
            areaService.getAreas()
                .success(function (data)
                {
                    var newArr = [];
                    angular.forEach(data, function (area: panoptic.shared.IAreaInformation)
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

    angular.module('panoptic.home')
        .controller('HomeController', ['$location', '$scope', 'homeDescriptionService', 'areaService',
            function (
                $location: ng.ILocationService,
                $scope: IHomeScope,
                descriptionService: panoptic.home.IHomeDescriptionService,
                areaService: panoptic.shared.IAreaService)
            {
                return new HomeController($location, $scope, descriptionService, areaService);
            }]);
}

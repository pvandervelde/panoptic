///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../Scripts/typings/restangular/restangular.d.ts" />

module panoptic.home
{
    interface IHomeScope extends ng.IScope
    {
        navigate: (path: string) => void;
        teams: Array<Array<panoptic.home.ITeamInformation>>;
        areaName: string;
        areaDescription: string;
    }

    class HomeController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IHomeScope,
            private descriptionService: panoptic.home.IHomeDescriptionService,
            private teamService: panoptic.home.ITeamService)
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

            $scope.teams = new Array<Array<panoptic.home.ITeamInformation>>();
            teamService.getTeams()
                .success(function (data)
                {
                    var newArr = [];
                    angular.forEach(data, function (team: panoptic.home.ITeamInformation)
                    {
                        newArr.push(team);
                    });

                    $scope.teams = divideIntoColumns(newArr, 3)
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('error');
                });
        }
    }

    angular.module('panoptic.home')
        .controller('HomeController', ['$location', '$scope', 'homeDescriptionService', 'teamService',
            function (
                $location: ng.ILocationService,
                $scope: IHomeScope,
                descriptionService: panoptic.home.IHomeDescriptionService,
                teamService: panoptic.home.ITeamService)
            {
                return new HomeController($location, $scope, descriptionService, teamService);
            }]);
}

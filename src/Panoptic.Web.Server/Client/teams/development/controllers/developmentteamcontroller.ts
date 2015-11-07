///<reference path="../../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../../Scripts/typings/restangular/restangular.d.ts" />

module panoptic.teams.development
{
    interface IDevelopmentTeamScope extends ng.IScope
    {
        navigate: (path: string) => void;
        builds: Array<Array<panoptic.teams.development.IBuildInformation>>;
        workitems: Array<panoptic.teams.shared.IWorkItemInformation>;
        burnDown: Array<panoptic.teams.development.IBurnDownGraph>;
        areaName: string;
        areaDescription: string;

        burnDownGraphAxes: Array<any>;
        burnDownGraphOptions: any;
    }

    interface IDevelopmentTeamRouteParams extends ng.route.IRouteParamsService
    {
        id: string;
    }

    class DevelopmentTeamController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IDevelopmentTeamScope,
            private $routeParams: IDevelopmentTeamRouteParams,
            private descriptionService: panoptic.teams.development.IDevelopmentTeamDescriptionService,
            private buildService: panoptic.teams.development.IBuildService,
            private workitemService: panoptic.teams.development.IWorkItemService,
            private burnDownService: panoptic.teams.development.IBurnDownService)
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

            $scope.burnDownGraphAxes = ['left', 'right', 'bottom'];
            $scope.burnDownGraphOptions =
            {
                ticks:
                {
                    right: 0,
                    bottom: 0,
                    left: 0
                },
            }

            descriptionService.getDescription($routeParams.id)
                .success(function (data)
                {
                    $scope.areaName = data.Name;
                    $scope.areaDescription = data.Description;
                    $scope.$apply();
                })
                .error(function (data)
                {
                    alert('failed to get the name and description for the development team page.');
                });

            $scope.builds = new Array<Array<panoptic.teams.development.IBuildInformation>>();
            buildService.getBuilds($routeParams.id)
                .success(function (data)
                {
                    var newArr = [];
                    angular.forEach(data, function (build: panoptic.teams.development.IBuildInformation)
                    {
                        newArr.push(build);
                    });

                    $scope.builds = divideIntoColumns(newArr, 3)
                    $scope.$apply();
                })
                .error(function (data)
                {
                    alert('no builds');
                });

            $scope.workitems = new Array<panoptic.teams.shared.IWorkItemInformation>();
            workitemService.getWorkItems($routeParams.id)
                .success(function (data)
                {
                    $scope.workitems = data;
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('no workitems');
                });

            $scope.burnDown =
            [{
                label: '',
                values: new Array<panoptic.teams.development.IBurnDownEntryView>(),
            }];
            burnDownService.getBurnDown($routeParams.id)
                .success(function (data)
                {
                    $scope.burnDown[0].label = data.Name
                    angular.forEach(data.BurnDown, function (cpuLoad: panoptic.teams.development.IBurnDownEntry)
                    {
                        $scope.burnDown[0].values.push({ x: cpuLoad.Time, y: cpuLoad.Count });
                    });
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('no burn down graph');
                });
        }
    }

    angular.module('panoptic.teams.development')
        .controller('DevelopmentTeamController',
            [
                '$location',
                '$scope',
                '$routeParams',
                'developmentTeamDescriptionService',
                'buildService',
                'developmentTeamWorkItemService',
                'burnDownService',
                function (
                    $location: ng.ILocationService,
                    $scope: IDevelopmentTeamScope,
                    $routeParams: IDevelopmentTeamRouteParams,
                    descriptionService: panoptic.teams.development.IDevelopmentTeamDescriptionService,
                    buildService: panoptic.teams.development.IBuildService,
                    workitemService: panoptic.teams.development.IWorkItemService,
                    burnDownService: panoptic.teams.development.IBurnDownService)
                {
                    return new DevelopmentTeamController(
                        $location,
                        $scope,
                        $routeParams,
                        descriptionService,
                        buildService,
                        workitemService,
                        burnDownService);
                }]);
}

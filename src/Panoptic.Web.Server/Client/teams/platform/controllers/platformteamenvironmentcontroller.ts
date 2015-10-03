///<reference path="../../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../../Scripts/typings/restangular/restangular.d.ts" />

module panoptic.teams.platform
{
    interface IPlatformTeamEnvironmentScope extends ng.IScope
    {
        navigate: (path: string) => void;
        services: Array<panoptic.teams.platform.IServiceInformation>;
        machines: Array<panoptic.teams.platform.IMachineStatisticsInformation>;
        areaName: string;
        areaDescription: string;
    }

    interface IPlatformTeamEnvironmentRouteParams extends ng.route.IRouteParamsService
    {
        id: string;
    }

    class PlatformTeamEnvironmentController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IPlatformTeamEnvironmentScope,
            private $routeParams: IPlatformTeamEnvironmentRouteParams,
            private environmentService: panoptic.teams.platform.IEnvironmentService,
            private machineService: panoptic.teams.platform.IMachineService)
        {
            super();

            $scope.navigate = function (path: string)
            {
                $location.path(path);
            };

            $scope.services = new Array<panoptic.teams.platform.IServiceInformation>();
            environmentService.getEnvironment($routeParams.id)
                .success(function (data)
                {
                    $scope.services = data.Services;
                    $scope.areaName = data.Name;
                    $scope.areaDescription = data.Description;
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('no environments');
                });

            $scope.machines = new Array<panoptic.teams.platform.IMachineStatisticsInformation>();
            machineService.getMachines($routeParams.id)
                .success(function (data)
                {
                    $scope.machines = data;
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('no machines');
                });
        }
    }

    angular.module('panoptic.teams.platform')
        .controller('PlatformTeamEnvironmentController',
            [
                '$location',
                '$scope',
                '$routeParams',
                'environmentService',
                'machineService',
                function (
                    $location: ng.ILocationService,
                    $scope: IPlatformTeamEnvironmentScope,
                    $routeParams: IPlatformTeamEnvironmentRouteParams,
                    environmentService: panoptic.teams.platform.IEnvironmentService,
                    machineService: panoptic.teams.platform.IMachineService)
                {
                    return new PlatformTeamEnvironmentController(
                        $location,
                        $scope,
                        $routeParams,
                        environmentService,
                        machineService);
                }]);
}

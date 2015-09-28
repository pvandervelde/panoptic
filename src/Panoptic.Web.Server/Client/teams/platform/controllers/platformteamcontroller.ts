///<reference path="../../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../../Scripts/typings/restangular/restangular.d.ts" />

///<reference path="../../../shared/modules/areas.ts" />
///<reference path="../../../shared/services/areaservice.ts" />

module panoptic.teams.platform
{
    interface IPlatformTeamScope extends ng.IScope
    {
        navigate: (path: string) => void;
        environments: Array<panoptic.teams.platform.IEnvironmentInformation>;
        workitems: Array<panoptic.teams.platform.IWorkItemInformation>;
        releases: Array<panoptic.teams.platform.IReleaseInformation>;
        areaName: string;
        areaDescription: string;
    }

    class PlatformTeamController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IPlatformTeamScope,
            private descriptionService: panoptic.teams.platform.IPlatformTeamDescriptionService,
            private environmentService: panoptic.teams.platform.IEnvironmentService,
            private workitemService: panoptic.teams.platform.IWorkItemService,
            private releaseService: panoptic.teams.platform.IReleaseService)
        {
            super();

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
                    alert('failed to get the name and description for the ops area.');
                });

            $scope.environments = new Array<panoptic.teams.platform.IEnvironmentInformation>();
            environmentService.getEnvironments()
                .success(function (data)
                {
                    $scope.environments = data;
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('no environments');
                });

            $scope.workitems = new Array<panoptic.teams.platform.IWorkItemInformation>();
            workitemService.getWorkItems()
                .success(function (data)
                {
                    $scope.workitems = data;
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('no workitems');
                });

            $scope.releases = new Array<panoptic.teams.platform.IReleaseInformation>();
            releaseService.getReleases()
                .success(function (data)
                {
                    $scope.releases = data;
                    $scope.$apply();
                })
                .error(function ()
                {
                    alert('no releases');
                });
        }
    }

    angular.module('panoptic.teams.platform')
        .controller('PlatformTeamController',
            [
                '$location',
                '$scope',
                'opsDescriptionService',
                'environmentService',
                'workitemService',
                'releaseService',
                function (
                    $location: ng.ILocationService,
                    $scope: IPlatformTeamScope,
                    descriptionService: panoptic.teams.platform.IPlatformTeamDescriptionService,
                    environmentService: panoptic.teams.platform.IEnvironmentService,
                    workitemService: panoptic.teams.platform.IWorkItemService,
                    releaseService: panoptic.teams.platform.IReleaseService)
                {
                    return new PlatformTeamController(
                        $location,
                        $scope,
                        descriptionService,
                        environmentService,
                        workitemService,
                        releaseService);
                }]);
}

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
        areaName: string;
        areaDescription: string;
    }

    class PlatformTeamController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IPlatformTeamScope,
            private descriptionService: panoptic.teams.platform.IOpsDescriptionService,
            private environmentService: panoptic.teams.platform.IEnvironmentService,
            private workitemService: panoptic.teams.platform.IWorkItemService)
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
        }
    }

    angular.module('panoptic.teams.platform')
        .controller('PlatformTeamController', ['$location', '$scope', 'opsDescriptionService', 'environmentService', 'workitemService',
            function (
                $location: ng.ILocationService,
                $scope: IPlatformTeamScope,
                descriptionService: panoptic.teams.platform.IOpsDescriptionService,
                environmentService: panoptic.teams.platform.IEnvironmentService,
                workitemService: panoptic.teams.platform.IWorkItemService)
            {
                return new PlatformTeamController($location, $scope, descriptionService, environmentService, workitemService);
            }]);
}

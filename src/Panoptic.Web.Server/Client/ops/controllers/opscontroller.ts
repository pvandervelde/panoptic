///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../Scripts/typings/restangular/restangular.d.ts" />

///<reference path="../../shared/modules/areas.ts" />
///<reference path="../../shared/services/areaservice.ts" />

module panoptic.ops
{
    interface IOpsScope extends ng.IScope
    {
        navigate: (path: string) => void;
        environments: Array<panoptic.ops.IEnvironmentInformation>;
        workitems: Array<panoptic.ops.IWorkItemInformation>;
        areaName: string;
        areaDescription: string;
    }

    class OpsController extends panoptic.core.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IOpsScope,
            private descriptionService: panoptic.ops.IOpsDescriptionService,
            private environmentService: panoptic.ops.IEnvironmentService,
            private workitemService: panoptic.ops.IWorkItemService)
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

            $scope.environments = new Array<panoptic.ops.IEnvironmentInformation>();
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

            $scope.workitems = new Array<panoptic.ops.IWorkItemInformation>();
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

    angular.module('panoptic.ops')
        .controller('OpsController', ['$location', '$scope', 'opsDescriptionService', 'environmentService', 'workitemService',
            function (
                $location: ng.ILocationService,
                $scope: IOpsScope,
                descriptionService: panoptic.ops.IOpsDescriptionService,
                environmentService: panoptic.ops.IEnvironmentService,
                workitemService: panoptic.ops.IWorkItemService)
            {
                return new OpsController($location, $scope, descriptionService, environmentService, workitemService);
            }]);
}

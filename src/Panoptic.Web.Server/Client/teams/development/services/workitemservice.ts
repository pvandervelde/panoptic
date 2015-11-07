///<reference path="../../../core/modules/globals.ts" />

module panoptic.teams.development
{
    export interface IWorkItemServiceProvider extends ng.IServiceProvider
    {
        $get: () => IWorkItemService;
    }

    export interface IWorkItemService
    {
        getWorkItems: (id : string) => ng.IHttpPromise<Array<panoptic.teams.shared.IWorkItemInformation>>;
    }

    class WorkItemService implements IWorkItemService
    {
        getWorkItems: (id : string) => ng.IHttpPromise<Array<panoptic.teams.shared.IWorkItemInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getWorkItems = function (id)
            {
                return $http.get(globals.webApiBaseUrl + 'teams/development/work/items/' + id);
            };
        }
    }

    angular.module('panoptic.teams.development')
        .factory('developmentTeamWorkItemService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new WorkItemService($http, globals);
        });
}
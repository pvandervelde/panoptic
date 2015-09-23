﻿///<reference path="../../core/modules/globals.ts" />

module panoptic.ops
{
    export interface IWorkItemServiceProvider extends ng.IServiceProvider
    {
        $get: () => IWorkItemService;
    }

    export interface IWorkItemService
    {
        getWorkItems: () => ng.IHttpPromise<Array<panoptic.ops.IWorkItemInformation>>;
    }

    class WorkItemService implements IWorkItemService
    {
        getWorkItems: () => ng.IHttpPromise<Array<panoptic.ops.IWorkItemInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getWorkItems = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'ops/work');
            };
        }
    }

    angular.module('panoptic.ops')
        .factory('workitemService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new WorkItemService($http, globals);
        });
}
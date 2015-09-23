///<reference path="../../core/modules/globals.ts" />

module panoptic.ops
{
    export interface IEnvironmentServiceProvider extends ng.IServiceProvider
    {
        $get: () => IEnvironmentService;
    }

    export interface IEnvironmentService
    {
        getEnvironments: () => ng.IHttpPromise<Array<panoptic.ops.IEnvironmentInformation>>;
    }

    class EnvironmentService implements IEnvironmentService
    {
        getEnvironments: () => ng.IHttpPromise<Array<panoptic.ops.IEnvironmentInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getEnvironments = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'ops/environment');
            };
        }
    }

    angular.module('panoptic.ops')
        .factory('environmentService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new EnvironmentService($http, globals);
        });
}
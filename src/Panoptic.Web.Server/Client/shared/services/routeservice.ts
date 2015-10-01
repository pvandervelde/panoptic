///<reference path="../../core/modules/globals.ts" />

module panoptic.shared
{
    export interface IRouteServiceProvider extends ng.IServiceProvider
    {
        $get: () => IRouteService;
    }

    export interface IRouteService
    {
        getRoutes: () => ng.IHttpPromise<Array<panoptic.shared.IRouteInformation>>;
    }

    class RouteService implements IRouteService
    {
        getRoutes: () => ng.IHttpPromise<Array<panoptic.shared.IRouteInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getRoutes = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'home/route');
            };
        }
    }

    angular.module('panoptic.shared')
        .factory('routeService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new RouteService($http, globals);
        });
}
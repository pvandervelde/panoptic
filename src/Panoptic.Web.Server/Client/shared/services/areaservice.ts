///<reference path="../../core/modules/globals.ts" />

module panoptic.shared
{
    export interface IAreaServiceProvider extends ng.IServiceProvider
    {
        $get: () => IAreaService;
    }

    export interface IAreaService
    {
        getAreas: () => ng.IHttpPromise<Array<panoptic.shared.IAreaInformation>>;
    }

    class AreaService implements IAreaService
    {
        getAreas: () => ng.IHttpPromise<Array<panoptic.shared.IAreaInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getAreas = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'area');
            };
        }
    }

    angular.module('panoptic.shared')
        .factory('areaService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new AreaService($http, globals);
        });
}
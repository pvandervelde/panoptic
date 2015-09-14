///<reference path="../../core/modules/globals.ts" />

module panoptic.shared.services
{
    export interface IAreaServiceProvider extends ng.IServiceProvider
    {
        $get: () => IAreaService;
    }

    export interface IAreaService
    {
        getAreas: () => ng.IHttpPromise<Array<panoptic.shared.modules.IAreaInformation>>;
    }

    class AreaService implements IAreaService
    {
        getAreas: () => ng.IHttpPromise<Array<panoptic.shared.modules.IAreaInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.modules.IGlobalVariables)
        {

            this.getAreas = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'area');
            };
        }
    }

    angular.module('panoptic.shared.services', [])
        .factory('areaService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.modules.IGlobalVariables = <panoptic.core.modules.IGlobalVariables>injector.get('globalsService');
            return new AreaService($http, globals);
        });
}
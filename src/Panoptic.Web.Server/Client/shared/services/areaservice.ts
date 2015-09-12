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
                return $http.get(globals.webApiBaseUrl + '/api/v1/areas');
            };
        }
    }

    angular.module('panoptic.shared.services', [])
        .factory('panoptic.shared.services.AreaService', function ()
        {
            var injector = angular.injector(['ng', 'app.globalsModule']);
            var $http: ng.IHttpService = injector.get('$http');
            var globals: panoptic.core.modules.IGlobalVariables = injector.get('globalsService');
            return new AreaService($http, globals);
        });
}
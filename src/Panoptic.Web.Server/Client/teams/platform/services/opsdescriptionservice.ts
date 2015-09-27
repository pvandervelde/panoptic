///<reference path="../../core/modules/globals.ts" />

module panoptic.ops
{
    export interface IOpsDescriptionServiceProvider extends ng.IServiceProvider
    {
        $get: () => IOpsDescriptionService;
    }

    export interface IOpsDescriptionService
    {
        getDescription: () => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
    }

    class OpsDescriptionService implements IOpsDescriptionService
    {
        getDescription: () => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getDescription = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'ops/description');
            };
        }
    }

    angular.module('panoptic.ops')
        .factory('opsDescriptionService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new OpsDescriptionService($http, globals);
        });
}
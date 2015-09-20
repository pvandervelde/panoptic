///<reference path="../../core/modules/globals.ts" />

module panoptic.home
{
    export interface IHomeDescriptionServiceProvider extends ng.IServiceProvider
    {
        $get: () => IHomeDescriptionService;
    }

    export interface IHomeDescriptionService
    {
        getDescription: () => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
    }

    class HomeDescriptionService implements IHomeDescriptionService
    {
        getDescription: () => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getDescription = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'home/description');
            };
        }
    }

    angular.module('panoptic.home')
        .factory('homeDescriptionService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new HomeDescriptionService($http, globals);
        });
}
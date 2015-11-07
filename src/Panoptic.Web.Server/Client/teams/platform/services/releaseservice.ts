///<reference path="../../../core/modules/globals.ts" />

module panoptic.teams.platform
{
    export interface IReleaseServiceProvider extends ng.IServiceProvider
    {
        $get: () => IReleaseService;
    }

    export interface IReleaseService
    {
        getReleases: () => ng.IHttpPromise<Array<panoptic.teams.platform.IReleaseInformation>>;
    }

    class ReleaseService implements IReleaseService
    {
        getReleases: () => ng.IHttpPromise<Array<panoptic.teams.platform.IReleaseInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getReleases = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'teams/platform/release');
            };
        }
    }

    angular.module('panoptic.teams.platform')
        .factory('releaseService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new ReleaseService($http, globals);
        });
}
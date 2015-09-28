///<reference path="../../../core/modules/globals.ts" />

module panoptic.teams.platform
{
    export interface IOpsDescriptionServiceProvider extends ng.IServiceProvider
    {
        $get: () => IPlatformTeamDescriptionService;
    }

    export interface IPlatformTeamDescriptionService
    {
        getDescription: () => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
    }

    class OpsDescriptionService implements IPlatformTeamDescriptionService
    {
        getDescription: () => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getDescription = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'teams/platform/description');
            };
        }
    }

    angular.module('panoptic.teams.platform')
        .factory('opsDescriptionService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new OpsDescriptionService($http, globals);
        });
}
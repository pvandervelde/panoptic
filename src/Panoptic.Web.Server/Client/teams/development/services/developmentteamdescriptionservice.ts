///<reference path="../../../core/modules/globals.ts" />

module panoptic.teams.development
{
    export interface IDevelopmentTeamDescriptionServiceProvider extends ng.IServiceProvider
    {
        $get: () => IDevelopmentTeamDescriptionService;
    }

    export interface IDevelopmentTeamDescriptionService
    {
        getDescription: (id: string) => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
    }

    class DevelopmentTeamDescriptionService implements IDevelopmentTeamDescriptionService
    {
        getDescription: (id: string) => ng.IHttpPromise<panoptic.shared.IAreaDescriptionInformation>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getDescription = function (id)
            {
                return $http.get(globals.webApiBaseUrl + 'teams/development/description/' + id);
            };
        }
    }

    angular.module('panoptic.teams.development')
        .factory('developmentTeamDescriptionService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new DevelopmentTeamDescriptionService($http, globals);
        });
}
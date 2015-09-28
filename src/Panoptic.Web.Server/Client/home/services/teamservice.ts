///<reference path="../../core/modules/globals.ts" />

module panoptic.home
{
    export interface ITeamServiceProvider extends ng.IServiceProvider
    {
        $get: () => ITeamService;
    }

    export interface ITeamService
    {
        getTeams: () => ng.IHttpPromise<Array<panoptic.home.ITeamInformation>>;
    }

    class TeamService implements ITeamService
    {
        getTeams: () => ng.IHttpPromise<Array<panoptic.home.ITeamInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getTeams = function ()
            {
                return $http.get(globals.webApiBaseUrl + 'home/team');
            };
        }
    }

    angular.module('panoptic.home')
        .factory('teamService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new TeamService($http, globals);
        });
}
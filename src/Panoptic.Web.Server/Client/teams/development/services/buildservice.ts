///<reference path="../../../core/modules/globals.ts" />

module panoptic.teams.development
{
    export interface IBuildServiceProvider extends ng.IServiceProvider
    {
        $get: () => IBuildService;
    }

    export interface IBuildService
    {
        getBuilds: (id: string) => ng.IHttpPromise<Array<panoptic.teams.development.IBuildInformation>>;
    }

    class BuildService implements IBuildService
    {
        getBuilds: (id: string) => ng.IHttpPromise<Array<panoptic.teams.development.IBuildInformation>>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getBuilds = function (id)
            {
                return $http.get(globals.webApiBaseUrl + 'teams/development/build/' + id);
            };
        }
    }

    angular.module('panoptic.teams.development')
        .factory('buildService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new BuildService($http, globals);
        });
}
///<reference path="../../../core/modules/globals.ts" />

module panoptic.teams.development
{
    export interface IBurnDownServiceProvider extends ng.IServiceProvider
    {
        $get: () => IBurnDownService;
    }

    export interface IBurnDownService
    {
        getBurnDown: (id: string) => ng.IHttpPromise<panoptic.teams.development.IBurnDownInformation>;
    }

    class BurnDownService implements IBurnDownService
    {
        getBurnDown: (id: string) => ng.IHttpPromise<panoptic.teams.development.IBurnDownInformation>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getBurnDown = function (id)
            {
                return $http.get(globals.webApiBaseUrl + 'teams/development/work/burndown/' + id);
            };
        }
    }

    angular.module('panoptic.teams.development')
        .factory('burnDownService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new BurnDownService($http, globals);
        });
}
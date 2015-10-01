///<reference path="../../../core/modules/globals.ts" />

module panoptic.teams.platform
{
    export interface IMachineServiceProvider extends ng.IServiceProvider
    {
        $get: () => IMachineService;
    }

    export interface IMachineService
    {
        getMachines: (environment: string) => ng.IHttpPromise<Array<panoptic.teams.platform.IMachineStatisticsInformation>>;
        getMachine: (id: string) => ng.IHttpPromise<panoptic.teams.platform.IMachineStatisticsInformation>;
    }

    class MachineService implements IMachineService
    {
        getMachines: (environment: string) => ng.IHttpPromise<Array<panoptic.teams.platform.IMachineStatisticsInformation>>;
        getMachine: (id: string) => ng.IHttpPromise<panoptic.teams.platform.IMachineStatisticsInformation>;
        constructor(private $http: ng.IHttpService, private globals: panoptic.core.IGlobalVariables)
        {

            this.getMachines = function (environment)
            {
                return $http.get(globals.webApiBaseUrl + 'teams/platform/environment/machines/' + environment);
            };

            this.getMachine = function (id)
            {
                return $http.get(globals.webApiBaseUrl + 'teams/platform/environment/machine/' + id);
            }
        }
    }

    angular.module('panoptic.teams.platform')
        .factory('machineService', function ()
        {
            var injector = angular.injector(['ng', 'panoptic.globals']);
            var $http: ng.IHttpService = <ng.IHttpService>injector.get('$http');
            var globals: panoptic.core.IGlobalVariables = <panoptic.core.IGlobalVariables>injector.get('globalsService');
            return new MachineService($http, globals);
        });
}
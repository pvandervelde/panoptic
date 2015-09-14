///<reference path="../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../Scripts/typings/restangular/restangular.d.ts" />

///<reference path="core/modules/globals.ts" />
///<reference path="shared/directives/areaheader.ts" />
///<reference path="shared/modules/areas.ts" />
///<reference path="shared/services/areaservice.ts" />
///<reference path="home/controllers/homecontroller.ts" />

module panoptic
{
    class appUtils
    {
        static createViewUrl(fragmnt: string, globals: panoptic.core.modules.IGlobalVariables)
        {
            return globals.baseUrl + fragmnt;
        }
    }

    var app = angular.module('panoptic',
        [
            'ngRoute',
            'restangular',
            'panoptic.globals',
            'panoptic.shared.controllers',
            'panoptic.shared.directives',
            'panoptic.shared.services',
            'panoptic.home.controllers'
        ])
        .config(['$locationProvider', '$routeProvider', '$windowProvider', 'RestangularProvider', 'globalsServiceProvider', 'areaServiceProvider',
            function (
                $locationProvider: ng.ILocationProvider,
                $routeProvider: angular.route.IRouteProvider,
                $window: ng.IWindowService,
                RestangularProvider : restangular.IProvider,
                globalsServiceProvider: panoptic.core.modules.IGlobalsProvider,
                areaServiceProvider: panoptic.shared.services.IAreaServiceProvider)
            {
                $locationProvider.html5Mode(true);

                RestangularProvider.setBaseUrl('/api/v1');

                var globals: panoptic.core.modules.IGlobalVariables = globalsServiceProvider.$get();
                var areaService: panoptic.shared.services.IAreaService = areaServiceProvider.$get();
                areaService.getAreas()
                    .success(function (data) {
                    angular.forEach(data, function (area: panoptic.shared.modules.IAreaInformation)
                    {
                        $routeProvider.when(
                            area.path,
                            {
                                controller: area.controller,
                                templateUrl: appUtils.createViewUrl(area.templateUri, globals)
                            });
                        });
                    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });
                    })
                    .error(function (error)
                    {
                        $window.alert('Could not get the menu');
                    });
            }]);
}

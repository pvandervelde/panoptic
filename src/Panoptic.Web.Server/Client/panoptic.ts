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
        static createViewUrl(fragmnt: string, globals: panoptic.core.IGlobalVariables)
        {
            return globals.baseUrl + fragmnt;
        }
    }

    var app = angular.module('panoptic',
        [
            'ngRoute',
            'restangular',
            'panoptic.globals',
            'panoptic.core',
            'panoptic.shared',
            'panoptic.home'
        ])
        .config(['$locationProvider', '$routeProvider', '$windowProvider', 'RestangularProvider', 'globalsServiceProvider', 'areaServiceProvider',
            function (
                $locationProvider: ng.ILocationProvider,
                $routeProvider: angular.route.IRouteProvider,
                $window: ng.IWindowService,
                RestangularProvider : restangular.IProvider,
                globalsServiceProvider: panoptic.core.IGlobalsProvider,
                areaServiceProvider: panoptic.shared.IAreaServiceProvider)
            {
                $locationProvider.html5Mode(true);

                RestangularProvider.setBaseUrl('/api/v1');

                $routeProvider
                    .when('/', {
                        controller: 'HomeController',
                        templateUrl: 'Client/shared/views/home.html'
                    })
                    .otherwise({
                        redirectTo: '/'
                    });

                var globals: panoptic.core.IGlobalVariables = globalsServiceProvider.$get();
                var areaService: panoptic.shared.IAreaService = areaServiceProvider.$get();
                areaService.getAreas()
                    .success(function (data) {
                    angular.forEach(data, function (area: panoptic.shared.IAreaInformation)
                    {
                        $routeProvider.when(
                            area.path,
                            {
                                controller: area.controller,
                                templateUrl: appUtils.createViewUrl(area.templateUri, globals)
                            });
                        });
                    })
                    .error(function (error)
                    {
                        $window.alert('Could not get the menu');
                    });
            }]);
}

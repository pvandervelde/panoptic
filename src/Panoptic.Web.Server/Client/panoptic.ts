﻿///<reference path="../Scripts/typings/angularjs/angular.d.ts" /> 
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
            return globals.baseUrl + 'Client/' + fragmnt;
        }
    }

    var app = angular.module('panoptic',
        [
            'ngRoute',
            'ng.epoch',
            'restangular',
            'panoptic.globals',
            'panoptic.core',
            'panoptic.shared',
            'panoptic.home',
            'panoptic.teams.platform'
        ])
        .config([
            '$locationProvider',
            '$routeProvider',
            '$windowProvider',
            'RestangularProvider',
            'globalsServiceProvider',
            'routeServiceProvider',
            function (
                $locationProvider: ng.ILocationProvider,
                $routeProvider: angular.route.IRouteProvider,
                $window: ng.IWindowService,
                RestangularProvider: restangular.IProvider,
                globalsServiceProvider: panoptic.core.IGlobalsProvider,
                routeServiceProvider: panoptic.shared.IRouteServiceProvider)
            {
                $locationProvider.html5Mode(true);

                RestangularProvider.setBaseUrl('/api/v1');

                $routeProvider
                    .when('/', {
                        controller: 'HomeController',
                        templateUrl: 'client/home/views/home.html'
                    })
                    .otherwise({
                        redirectTo: '/'
                    });

                var globals: panoptic.core.IGlobalVariables = globalsServiceProvider.$get();
                var routeService: panoptic.shared.IRouteService = routeServiceProvider.$get();
                routeService.getRoutes()
                    .success(function (data)
                    {
                        angular.forEach(data, function (area: panoptic.shared.IRouteInformation)
                        {
                            $routeProvider.when(
                                '/' + area.Path,
                                {
                                    controller: area.Controller,
                                    templateUrl: appUtils.createViewUrl(area.TemplateUri, globals)
                                });
                        });
                    })
                    .error(function (error)
                    {
                        $window.alert('Could not get the routes');
                    });
            }]);

    app.run([
        '$rootScope',
        function ($rootScope)
        {
            // see what's going on when the route tries to change
            $rootScope.$on('$routeChangeStart', function (event, next, current)
            {
                // next is an object that is the route that we are starting to go to
                // current is an object that is the route where we are currently
                var currentPath = current.originalPath;
                var nextPath = next.originalPath;

                console.log('Starting to leave %s to go to %s', currentPath, nextPath);
            });
        }
    ]);
}

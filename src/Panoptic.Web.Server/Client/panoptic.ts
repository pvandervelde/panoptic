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
            'panoptic.teams.development',
            'panoptic.teams.platform',
            'panoptic.teams.shared'
        ])
        .config([
            '$locationProvider',
            '$routeProvider',
            '$windowProvider',
            'RestangularProvider',
            'globalsServiceProvider',
            function (
                $locationProvider: ng.ILocationProvider,
                $routeProvider: angular.route.IRouteProvider,
                $window: ng.IWindowService,
                RestangularProvider: restangular.IProvider,
                globalsServiceProvider: panoptic.core.IGlobalsProvider)
            {
                RestangularProvider.setBaseUrl('/api/v1');
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

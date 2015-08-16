declare var angular;

// Create the app and set up the routes
var app = angular.module('panoptic', ['panoptic.filters', 'panoptic.services', 'panoptic.directives', 'panoptic.controllers'])
    .config([<any> '$locationProvider', '$routeProvider', function ($locationProvider: any, $routeProvider: any) {
        $locationProvider.html5Mode(true);
        $routeProvider
            .when('/', {
                controller: 'HomeController',
                templateUrl: 'views/home.html'
            })
            .when('/admin', {
                controller: 'AdminController',
                templateUrl: 'views/admin.html'
            })
            .otherwise({
                redirectTo: '/'
            });
    }]);

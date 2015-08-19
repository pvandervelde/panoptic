///<reference path="../typings/angularjs/angular.d.ts" /> 
///<reference path="../typings/angularjs/angular-route.d.ts" />

declare var ang;

ang.module('panoptic.controllers', [])
    .controller('NavBarController', [<any> '$scope', function ($scope) {
        // Store the information about the available areas here
        $scope.Areas = [{
            name: 'Home',
            url: '~/home'
        },
        {
            name: 'Admin',
            url: '~/admin'
        }]
    }]);
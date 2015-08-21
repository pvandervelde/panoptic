﻿///<reference path="../typings/angularjs/angular.d.ts" /> 
///<reference path="../typings/angularjs/angular-route.d.ts" />

app.controller('NavBarController', [<any> '$scope', function ($scope) {
    $scope.areas = [
        {
            name: 'Home',
            url: '~/home'
        },
        {
            name: 'Admin',
            url: '~/admin'
        }
    ];
}]);
///<reference path="../typings/angularjs/angular.d.ts" /> 
///<reference path="../typings/angularjs/angular-route.d.ts" />

app.controller('PageNavBarController', [<any> '$scope', function ($scope) {
    $scope.areas = [
        {
            name: 'Admin',
            url: '/admin'
        }
    ];
}]);
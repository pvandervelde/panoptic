///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
declare var app: ng.IModule;

app.controller('AdminController', [<any> '$scope', function ($scope) {
    $scope.areaName = 'Admin';
    $scope.areaDescription = 'This is where you can administer your this web application from.';
}]);
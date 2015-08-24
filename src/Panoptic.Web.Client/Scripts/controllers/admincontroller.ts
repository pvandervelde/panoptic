///<reference path="../typings/angularjs/angular.d.ts" /> 
///<reference path="../typings/angularjs/angular-route.d.ts" />

app.controller('AdminController', [<any> '$scope', function ($scope) {
    $scope.areaname = 'Admin';
    $scope.areadescription = 'This is where you can administer your this web application from.';
}]);
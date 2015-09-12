///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />
///<reference path="../../../Scripts/typings/restangular/restangular.d.ts" />
module panoptic.controllers {

}
app.controller('HomeController', [<any> '$scope', function ($scope, Restangular) {

    function divideIntoColumns(arr: any[], size: number) {
        var newArr = [];
        for (var i = 0; i < arr.length; i += size) {
            newArr.push(arr.slice(i, i + size));
        }
        return newArr;
    }

    var areas = Restangular.all('area');

    // This will query /accounts and return a promise.
    areas.getList().then(function (areas) {
        $scope.availableAreaDescriptions = divideIntoColumns(areas, 3);
    });

    $scope.areaName = 'Home';
    $scope.areaDescription = 'some long text thing that just goes on for ever and ever and ever';
}]);
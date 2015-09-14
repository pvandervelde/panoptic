///<reference path="../../../Scripts/typings/angularjs/angular.d.ts" /> 
///<reference path="../../../Scripts/typings/angularjs/angular-route.d.ts" />

module panoptic.shared.controllers
{
    interface IPageFooterScope extends ng.IScope
    {
        navigate: (path: string) => void;
        date: Date;
    }

    class PageFooterController extends panoptic.core.controllers.BaseController
    {
        constructor(
            private $location: ng.ILocationService,
            private $scope: IPageFooterScope)
        {
            super();
            $scope.navigate = function (path: string)
            {
                $location.path(path);
            };

            $scope.date = new Date();
        }
    }

    angular.module('panoptic.shared.controllers',
        [])
        .controller('PageFooterController', ['$location', '$scope',
            function (
                $location: ng.ILocationService,
                $scope: IPageFooterScope)
            {
                return new PageFooterController($location, $scope);
            }]);
}

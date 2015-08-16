declare var angular;

angular.module('panoptic.controllers', [])
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
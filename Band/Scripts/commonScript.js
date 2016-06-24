var mainApp = angular.module('main', []);

mainApp.controller('BandController', ['$scope', function ($scope) {

    this.list = [{ 'name': '밴드 이름1', 'cost': 100, 'color': '#59CDDF' },
                           { 'name': '밴드 이름2', 'cost': 200, 'color': '#B76AAA' },
                           { 'name': '밴드 이름3', 'cost': 300, 'color': '#EAC81E' }];
}]);
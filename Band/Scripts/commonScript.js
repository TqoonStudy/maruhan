﻿var mainApp = angular.module('main', []);

mainApp.controller('BandController', ['$scope', '$http', function ($scope, $http) {
    $scope.list = {};
    getBandList();

    $scope.getBoard = function () {
        var groupId = this.banditem.Id;
        var formId = "#form" + groupId;
        var form = $(formId);
        form.submit();
    }


    function getBandList() {
        $http.post("/Group/getListByUserId", {UserId : 1}).then(function (res) {
            $scope.list =  res.data;
        });
    }


}]);

mainApp.controller('BoardController', function ($scope, $http) {

    $scope.openModal = function () {
        $("#writeModal").show();
        $("#realModal").show();
    }

    $scope.closeModal = function () {
        $("#writeModal").hide();
        $("#realModal").hide();
    }

    $scope.postBoard = function () {
        $http.post("/Board/Write", { UserId: 1, GroupId: 1, Content: $scope.contents }).then(function (res) {
            $scope.closeModal();
            $rootScope.$emit("reloadBoardList");
        });
    }

});

mainApp.controller('GroupController', function ($scope, $http) {
    var colorCodeArr = ['#95d8f8', '#f19e9e', '#f39b47', '#fff430', '#a5a5a5', '#c2ef61', '#9c86e6', '#97a4f1', '#d68ffc', '#9cf8da', '#fcabf0', '#ffd73a'];
    $scope.example = getImgArr();

    function shuffle(array) {
        var copy = [], n = array.length, i;
        while (n) {
            i = Math.floor(Math.random() * array.length);
            if (i in array) {
                copy.push(array[i]);
                delete array[i];
                n--;
            }
        }
        return copy;
    }

    function getImgArr() {
        var result = [];
        for (var i = 1; i < 31; i++) {
            var item = "img" + i+".jpg";
            result.push(item);
        }
        $scope.bandImg = result[0];
        return shuffle(result);
    }

    $scope.colorSettingInit = function () {
        var randomcolor = colorCodeArr[parseInt(Math.random() * 12)];
        $(".bandLine").css("background-color", randomcolor);
        $(".colorChange").css("background-color", randomcolor);
        $(".smallBandLine").css("background-color", randomcolor);
    };

    function RGBtoHexColor(color) {
        if (color.substr(0, 1) === '#') {
            return color;
        }
        var digits = /(.*?)rgb\((\d+), (\d+), (\d+)\)/.exec(color);

        var red = parseInt(digits[2]);
        var green = parseInt(digits[3]);
        var blue = parseInt(digits[4]);
        var rgb = blue | (green << 8) | (red << 16);
        return digits[1] + '#' + rgb.toString(16);
    }

    $scope.bandColorChange = function () {
        $("#colorSelector").toggle();
    }

    $("#colorSelector span").on("click", function () {
        var selectColor = $(this).css("background-color");
        var hexCode = RGBtoHexColor(selectColor);
        $(".bandLine").css("background-color", selectColor);
        $(".colorChange").css("background-color", selectColor);
        $(".smallBandLine").css("background-color", selectColor);

    });

    $scope.inputBandName = function () {
        if ($scope.bandName.toString() !="") {
            if ($scope.bandName.length > 12) {
                $scope.bandName = $scope.bandName.substr(0, 12);
                $('#example').popover('show');
            }
        }
    }

    $scope.changeBandImg = function () {
        $scope.bandImg = this.item;
    }

    $scope.CreateSubmit = function () {
        console.log("그룹생성버튼을 눌렀다.");
    }

    $scope.CreateCancel = function () {
        console.log("그룹생성취소버튼을 눌렀다.");

    }

});
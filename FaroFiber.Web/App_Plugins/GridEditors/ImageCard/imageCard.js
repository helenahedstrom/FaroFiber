angular.module('umbraco').controller('imageCard', function ($scope, editorService) {
    if (!$scope.control.card) {
        $scope.control.card = {};
    }
    if (!$scope.control.card.link) { $scope.control.card.link = {}; }

    //LINK PICKER
    $scope.selectLink = function () {
        var linkSelected = function (data) {
            $scope.control.card.link = { name: data.target.name, id: data.target.id, target: data.target.target };
            editorService.close();
        };

        var options = {
            submit: linkSelected,
            close: function () { editorService.close(); },
            value: !$scope.control && !$scope.control.card ? {} : $scope.control.card
        };

        editorService.linkPicker(options);
    };

    //if (!$scope.control.card.list) {
    //    $scope.control.card.list = [];
    //}

    //if (!$scope.control.card.listContainerNodeId) {
    //    $scope.control.card.listContainerNodeId = {};
    //}

    //function search(nameKey, myArray, prop) {
    //    for (var i = 0; i < myArray.length; i++) {
    //        if (myArray[i][prop] === nameKey) {
    //            return myArray[i];
    //        }
    //    }
    //}

    ////CONTENT PICKER
    //$scope.selectContent = function () {
    //    var contentSelected = function (data) {

    //        $scope.control.card = {
    //                id: data.selection[0].id,
    //                name: data.selection[0].name
    //        };

    //        console.log($scope.control.card);
    //    };

    //    var options = {
    //        submit: contentSelected,
    //        multipicker: false,
    //        close: function () {
    //            editorService.close();
    //        }
    //    };

    //    editorService.contentPicker(options);
    //};

    //$scope.openInfinite = function () {
    //    var options = {
    //        submit: function (model) {
    //            editorService.close();
    //        },
    //        close: function () {
    //            editorService.close();
    //        }
    //    };
    //    editorService.open(options);
    //};

    //$scope.resetContent = function () {
    //    $scope.control.card = {};
    //};
});

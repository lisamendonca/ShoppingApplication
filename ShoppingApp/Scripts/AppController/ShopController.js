var app = angular.module('myApp', [])
app.controller('ShopController', function ($scope, ShopFactory, $sce) {
    $scope.IsSubmit = false;
    $scope.data = {};

    $scope.Page = [
        { section: [{ control: "<input type='text'/>" }, { control: "<img src='https://static.pexels.com/photos/39517/rose-flower-blossom-bloom-39517.jpeg'/>" }] },
        { section: [] },
        { section: [] },
        { section: [] }
    ]

    $scope.returnhtml = function (html) {
        console.log(html);
        return $sce.trustAsHtml(html);
    }

    $scope.display = function () {
        ShopFactory.getdetails().then(function (response) {

            $scope.Inventory = JSON.parse(response.data);

        });
        //ShopFactory.getPurchasedItems().then(function (response) {
        //    $scope.Purchased = response.data;
        //    console.log($scope.Purchased);
        //});
    }
    $scope.addFoodItem = function () {
        $scope.IsSubmit = true;

        if ($scope.myform.$valid) {
            //$scope.data.Total = $scope.data.unitprice * $scope.data.quantity;
            ShopFactory.postdetails($scope.data).then(function (response) {
                $scope.IsSubmit = false;
                //$scope.Inventory.push($scope.data);
                $scope.data = {};
                ShopFactory.getdetails().then(function (response) {
                    //debugger;
                    $scope.Inventory = JSON.parse(response.data);

                });

            });
        }

    }


    $scope.Edit = function ($index) {
        //debugger;
        console.log($scope.Inventory[0]);
        $scope.Inventory[$index].EditClicked = true;

    }

    $scope.Save = function ($index) {
       debugger;
        $scope.Inventory[$index].EditClicked = false;
        ShopFactory.savedetails($scope.Inventory[$index]).then(function (response) {


        });
    }
    $scope.Delete = function ($index) {
        debugger;
        console.log($scope.Inventory[$index].InventoryId);
        //ShopFactory.delDetails($scope.Inventory[$index]).then(function (response) {
        ShopFactory.delDetails($scope.Inventory[$index].InventoryId).then(function (response) {
            ShopFactory.getdetails().then(function (response) {
                //debugger;
                $scope.Inventory = JSON.parse(response.data);

            });
        });
    }

    $scope.Purchase = function ($index) {
        //debugger;
        ShopFactory.purchaseditem($scope.Inventory[$index]).then(function (response) {
            $scope.display();
            //ShopFactory.getPurchasedItems().then(function (response) {
            //    $scope.Purchased = response.data;
            //    //console.log($scope.Purchased);
            //});
          
            //delfrominventory();
        });
    }

    function delfrominventory()
    {
        alert('hh');

    }

});

angular.module('myApp').factory('ShopFactory',['$http',function($http)
{
    var factory = {};

    factory.getdetails = function () {
        return $http({
            url: '../../Shopping/InventoryDetails',
            method: "GET"
    
        });
        
    };
   
    factory.postdetails = function (model) {
           return $http({
            url: '../../Shopping/AddedInventory',
            method: "POST",
            data: { InventoryEntity: model }
        });
    };

    factory.savedetails = function (model) {
  return $http({
            url: '../../Shopping/SaveDetails',
            method: "POST",
            data: { InventoryEntity: model }
        });
    };
    factory.delDetails = function (inventoryId) {
        debugger;
    return $http({
        url: '../../Shopping/DelDetails?InventoryId=' + inventoryId,
      //  url: '../../Shopping/DelDetails',
            method: "POST",
      // data: { InventoryId: inventoryId}
        });

    };




    //factory.delDetails = function (inventoryId) {
    //    debugger;
    //    return $http({
    //        url: '../../Shopping/DelDetails?InventoryId=' + inventoryId,
    //        method: "GET"

    //    });

    //};
    factory.purchaseditem = function (model)
    {
 
        return $http({
            url: '../../Shopping/PurchasedItem',
            method: 'POST',
            data: { InventoryEntity: model }


        });

    }


    factory.getPurchasedItems = function () {
   
        return $http({
            url: '../../Shopping/GetPurchasedItems',
            method:'GET'

        });

    }
    return factory;
    //function getdetails() {
    //    $.ajax({
    //        url: '../../Controllers/ShoppingController/Shop',
    //        type: 'GET',
           
           
    //    });
    //}
  


}
    
]);

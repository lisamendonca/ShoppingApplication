using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL;
using Entities;

namespace Web_API.Controllers
{
    
    public class ShopController : ApiController
    {
        ShoppingDetailsBAL shop = new ShoppingDetailsBAL();

        [HttpGet]
        public List<InventoryEntity> FetchDetails() {

            return  shop.FetchDetails();
        }
        [HttpPost]
        public void  SendDetails(InventoryEntity inventoryentity)
        {

           shop.SendDetails(inventoryentity);
        }


        [HttpPost]
        public void SaveDetails(InventoryEntity inventoryentity)
        {

            shop.SaveDetails(inventoryentity);
            
        }



        [HttpPost]
        public void DelDetails([FromBody]int InventoryId)
        {

            shop.DelDetails(InventoryId);
        }
    }
}

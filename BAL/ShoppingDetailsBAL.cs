using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BAL
{
    public class ShoppingDetailsBAL
    {
        ShoppingDetails shopping = new ShoppingDetails();
        public List<InventoryEntity> FetchDetails()
        {
            return shopping.FetchDetails();
        }

        public void SendDetails( InventoryEntity inventoryentity) 
        {
          inventoryentity.Total =inventoryentity.Quantity*inventoryentity.UnitPrice;
            shopping.SendDetails(inventoryentity);
        }

        public void SaveDetails(InventoryEntity inventoryentity)
        {
            inventoryentity.Total = inventoryentity.Quantity * inventoryentity.UnitPrice;
            shopping.SaveDetails(inventoryentity);
        }
        public void DelDetails(int InventoryId)
        {

            shopping.DelDetails(InventoryId);
        }


        public void PurchasedItem(InventoryEntity inventoryentity)
        {

            shopping.PurchasedItem(inventoryentity);
        }
        public List<PurchaseEntity> GetPurchasedItems()
        {

           return shopping.GetPurchasedItems();
        }
    }
}

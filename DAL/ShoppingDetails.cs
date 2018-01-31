using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;

namespace DAL
{
    public class ShoppingDetails
    {

        public List<InventoryEntity> FetchDetails()
        {
            using (ShoppingEntities entities = new ShoppingEntities())
            {
               List<InventoryEntity> inventory = new List<InventoryEntity>();
               inventory = entities.Inventories.Where(p=>( p.isDelete==false || p.isDelete==null) &&( p.isPurchased==false || p.isPurchased==null)).Select(p => new InventoryEntity
                   {
                       InventoryId = p.Inventory_Id,
                       Name = p.Name,
                       UnitPrice = p.UnitPrice,
                       Quantity = p.Quantity,
                       Total = p.Total
                   }).ToList();
               return inventory;

            }

        }


        public void SendDetails( InventoryEntity inventoryentity)
        {
            using (ShoppingEntities entities = new ShoppingEntities())
            {
                Inventory inv = new Inventory
                {
                    Name = inventoryentity.Name,
                    Quantity = inventoryentity.Quantity,
                    UnitPrice = inventoryentity.UnitPrice,
                    Total=inventoryentity.Total,
                    isDelete=false

                };
                //Inventory inv = new Inventory();
                //inv.Name=inventoryentity.Name;
                //inv.Quantity=inventoryentity.Quantity;
                //inv.UnitPrice = inventoryentity.UnitPrice;

 entities.Inventories.Add(inv);
    entities.SaveChanges();
                }
           
        }


           public void SaveDetails(InventoryEntity inventoryentity)
        {
            using (ShoppingEntities entities= new ShoppingEntities())
            {

                Inventory  inv = entities.Inventories.Where(p => p.Inventory_Id == inventoryentity.InventoryId).FirstOrDefault();
                    
                   inv.Name=inventoryentity.Name;
                inv.UnitPrice=inventoryentity.UnitPrice;
                inv.Quantity=inventoryentity.Quantity;
                inv.Total = inventoryentity.Total;
                  
               
    entities.SaveChanges();

             }


        }


           public void DelDetails(int InventoryId)
           {

               using (ShoppingEntities entities = new ShoppingEntities())
               {

                  Inventory inv= entities.Inventories.Where(p=> p.Inventory_Id==InventoryId).FirstOrDefault();
                  inv.isDelete = true;
                  entities.SaveChanges();
               }
           }



        public void PurchasedItem(InventoryEntity inventoryentity) 
        {
            using (ShoppingEntities entities = new ShoppingEntities()) 
            {
         //Purchase pur = new Purchase
         //{

         //    Name=purchasedentity.Name,
         //    UnitPrice=purchasedentity.UnitPrice,
         //    Quantity=purchasedentity.Quantity,
         //    Total=purchasedentity.Total
         //};
             Inventory inv =  entities.Inventories.Where(p => p.Inventory_Id == inventoryentity.InventoryId).FirstOrDefault();
             inv.isPurchased = true;
                Purchase pur = new Purchase
                {

                    Name = inventoryentity.Name,
                    UnitPrice = inventoryentity.UnitPrice,
                    Quantity = inventoryentity.Quantity,
                    Total = inventoryentity.Total

                };
           
               entities.Purchases.Add(pur);
                entities.SaveChanges();


         }
            
            }

        public List<PurchaseEntity> GetPurchasedItems()
        {

            using (ShoppingEntities entities = new  ShoppingEntities())
            {
                List<PurchaseEntity> purchase = new List<PurchaseEntity>();
                 purchase=   entities.Purchases.Select(p => new PurchaseEntity
                      {
                          PurchaseId = p.Purchase_Id,
                          Name = p.Name,
                          Quantity = p.Quantity,
                          UnitPrice = p.UnitPrice,
                          Total = p.Total



                      }).ToList();
                return purchase;
            }
            
        }


        }

    }


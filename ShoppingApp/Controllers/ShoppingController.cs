using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShoppingApp.Common;
using Newtonsoft.Json;


using Entities;
namespace ShoppingApp.Controllers
{
    public class ShoppingController : Controller
    {
        private const string baseuri = "http://localhost:58513/";
        JsonResponseModel json = new JsonResponseModel();
        // GET: Shopping
  
        public ActionResult Shop()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> InventoryDetails() {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseuri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync( "api/Shop/FetchDetails");
                if (Res.IsSuccessStatusCode)

                {
                    json.ResponseData = Res.Content.ReadAsStringAsync().Result;
            
                }

                return Json(json.ResponseData, JsonRequestBehavior.AllowGet);
            }



        }
        [HttpPost]
        public async Task<ActionResult> AddedInventory(InventoryEntity inventoryentity)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseuri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage Res = await client.PostAsJsonAsync("api/Shop/SendDetails", inventoryentity);

                    if (Res.IsSuccessStatusCode)

                    {
                        json.ResponseData = Res.Content.ReadAsStringAsync().Result;


                    }
                }
                catch (Exception)
                {

                    throw;
                }
               
                return RedirectToAction("Shop");

            }
            
          
           
        }
        [HttpPost]
        public async Task<ActionResult> SaveDetails(InventoryEntity inventoryentity)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseuri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/Shop/SaveDetails", inventoryentity);
                if (Res.IsSuccessStatusCode)

                {
                    json.ResponseData = Res.Content.ReadAsStringAsync().Result;


                }
                return RedirectToAction("Shop");

            }



        }

        [HttpPost]
        public async Task<ActionResult> DelDetails(int InventoryId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseuri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HttpResponseMessage Res = await client.PostAsJsonAsync("api/Shop/DelDetails", InventoryId);
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/Shop/DelDetails",InventoryId);
                if (Res.IsSuccessStatusCode)

                {
                    json.ResponseData = Res.Content.ReadAsStringAsync().Result;


                }
                return RedirectToAction("Shop");

            }



        }


        //[HttpGet]
        //public async Task<ActionResult> DelDetails(int InventoryId)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(baseuri);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        // HttpResponseMessage Res = await client.PostAsJsonAsync("api/Shop/DelDetails", InventoryId);
        //        HttpResponseMessage Res = await client.GetAsync("api/Shop/DelDetails?InventoryId=" + InventoryId);
        //        if (Res.IsSuccessStatusCode)

        //        {
        //            json.ResponseData = Res.Content.ReadAsStringAsync().Result;


        //        }
        //        return RedirectToAction("Shop");

        //    }



        //}
        //}
        //[HttpPost]
        //public void DelDetails(int InventoryId)
        //{
        //    shop.DelDetails(InventoryId);


        //}
        //[HttpPost]
        //public void PurchasedItem(InventoryEntity inventoryentity)
        //{
        //    shop.PurchasedItem(inventoryentity);
        //}
        //[HttpGet]
        //public ActionResult GetPurchasedItems()
        //{
        //    return Json(shop.GetPurchasedItems(), JsonRequestBehavior.AllowGet);

        //}
    }
}
   

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ApplicationModels;
//using Newtonsoft.Json;
//using System.Diagnostics;
//using WebApi.Models;
//using Newtonsoft.Json;

//namespace WebSite.Controllers
//{
//    public class DeliveryController : Controller
//    {
//        public async Task<IActionResult> AddNewDelivery()
//        {
//            HttpClient client = new HttpClient();
//            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Delivery");
//            string json = await response.Content.ReadAsStringAsync();
//            List<DeliveryView> dataDelivery = JsonConvert.DeserializeObject<List<DeliveryView>>(json);
//            var deliveries = dataDelivery.ToList();
//            ViewBag.Delivery = deliveries;

//            HttpResponseMessage ResponseCassette = await client.GetAsync("https://localhost:7022/Show/Cassette");
//            json = await ResponseCassette.Content.ReadAsStringAsync();
//            List<CassetteView> dataCassette = JsonConvert.DeserializeObject<List<CassetteView>>(json);
//            var cassettes = dataCassette.ToList();
//            ViewBag.Cassette = cassettes;

//            return View();
//        }

//        public IActionResult DeleteDelivery()
//        {
//            return View();
//        }

//        public async Task<IActionResult> DeliveryPageAsync()
//        {
//            HttpClient client = new HttpClient();
//            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Delivery");
//            string json = await response.Content.ReadAsStringAsync();
//            List<DeliveryView> data = JsonConvert.DeserializeObject<List<DeliveryView>>(json);
//            var delivery = data.ToList();
//            ViewBag.Delivery = delivery;
//            return View(data);
//        }

//    }
//}

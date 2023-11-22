using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApi.Models;
using Newtonsoft.Json;

namespace WebSite.Controllers
{
    public class SaleController : Controller
    {
        public async Task<IActionResult> AddNewSale()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Sale");
            string json = await response.Content.ReadAsStringAsync();
            List<SaleView> dataSale = JsonConvert.DeserializeObject<List<SaleView>>(json);
            var sales = dataSale.ToList();
            ViewBag.Sale = sales;

            HttpResponseMessage ResponseCassette = await client.GetAsync("https://localhost:7022/Show/Vinyl");
            json = await ResponseCassette.Content.ReadAsStringAsync();
            List<VinylView> data = JsonConvert.DeserializeObject<List<VinylView>>(json);
            var vinyl = data.ToList();
            ViewBag.VinylView = vinyl;

            HttpResponseMessage ResponseEmployee = await client.GetAsync("https://localhost:7022/Show/Employee");
            json = await ResponseEmployee.Content.ReadAsStringAsync();
            List<Employee> dataEmployee = JsonConvert.DeserializeObject<List<Employee>>(json);
            var employee = dataEmployee.ToList();
            ViewBag.Employee = employee;

            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public async Task<IActionResult> SalePageAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Sale");
            string json = await response.Content.ReadAsStringAsync();
            List<SaleView> data = JsonConvert.DeserializeObject<List<SaleView>>(json);
            var sale = data.ToList();
            ViewBag.Sale = sale;
            return View(data);
        }

}
}

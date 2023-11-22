using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebSite.Controllers
{
    public class VinylController : Controller
    {
        public async Task<IActionResult> AddNewVinyl()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Vinyl");
            string json = await response.Content.ReadAsStringAsync();
            List<VinylView> data = JsonConvert.DeserializeObject<List<VinylView>>(json);
            var vinyls = data.ToList();
            ViewBag.Vinyl = vinyls;

            HttpResponseMessage ResponseCountry = await client.GetAsync("https://localhost:7022/ShowCountry/InfoVinyl");

            json = await ResponseCountry.Content.ReadAsStringAsync();

            List<Country> dataCountry = JsonConvert.DeserializeObject<List<Country>>(json);

            var country = dataCountry.ToList();

            ViewBag.Country = country;

            HttpResponseMessage ResponseCondition = await client.GetAsync("https://localhost:7022/ShowCondition/InfoVinyl");

            json = await ResponseCondition.Content.ReadAsStringAsync();

            List<Condition> dataCondition = JsonConvert.DeserializeObject<List<Condition>>(json);

            var condition = dataCondition.ToList();

            ViewBag.Condition = condition;

            HttpResponseMessage ResponseType = await client.GetAsync("https://localhost:7022/ShowType/InfoVinyl");

            json = await ResponseType.Content.ReadAsStringAsync();

            List<Type_plate> dataType = JsonConvert.DeserializeObject<List<Type_plate>>(json);

            var type = dataType.ToList();

            ViewBag.Type = type;

            HttpResponseMessage ResponseAlbum = await client.GetAsync("https://localhost:7022/ShowAlbum/InfoVinyl");

            json = await ResponseAlbum.Content.ReadAsStringAsync();

            List<Album> dataAlbum = JsonConvert.DeserializeObject<List<Album>>(json);

            var album = dataAlbum.ToList();

            ViewBag.Album = album;


            HttpResponseMessage ResponseArtist = await client.GetAsync("https://localhost:7022/ShowArtist/InfoVinyl");

            json = await ResponseArtist.Content.ReadAsStringAsync();

            List<Artist> dataArtist = JsonConvert.DeserializeObject<List<Artist>>(json);

            var artist = dataArtist.ToList();

            ViewBag.Artist = artist;

            HttpResponseMessage ResponseLabel = await client.GetAsync("https://localhost:7022/ShowLabel/InfoVinyl");

            json = await ResponseLabel.Content.ReadAsStringAsync();

            List<Label> dataLabel = JsonConvert.DeserializeObject<List<Label>>(json);

            var label = dataLabel.ToList();

            ViewBag.Label = label;

            return View();


        }

        public IActionResult DeleteVinyl()
        {
            return View(VinylPage);
        }

        public async Task<IActionResult> VinylPage(string SearchBy, string search)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7022/Show/Vinyl");
            string json = await response.Content.ReadAsStringAsync();
            List<VinylView> data = JsonConvert.DeserializeObject<List<VinylView>>(json);
            var vinyls = data.ToList();
            ViewBag.Vinyl = vinyls;

            if (SearchBy == "name_record" && !string.IsNullOrWhiteSpace(search))
            {
                var record = vinyls.Where(x => x.name_record == search || search == null).ToList();
                return View(record);
            }
            else
            {
                var artist = vinyls.Where(x => x.artist == search || search == null).ToList();
                return View(artist);
            }
        }

    }
}

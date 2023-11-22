using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]

    public class InfoVinylController : Controller
    {
        [Route("AddCountry/[controller]")]
        [HttpPost]
        public IActionResult AddCountry([FromBody] Country NewCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                NewCountry.id_country = NewCountry.NewIndex();
                DB.Add(NewCountry);
                DB.SaveChanges();
                return Ok();
            }
        }

        [Route("AddArtist/[controller]")]
        [HttpPost]
        public IActionResult AddArtist([FromBody] Artist NewArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                NewArtist.id_artist = NewArtist.NewIndex();
                DB.Add(NewArtist);
                DB.SaveChanges();
                return Ok();
            }
        }

        [Route("AddLabel/[controller]")]
        [HttpPost]
        public IActionResult AddLabel([FromBody] Label NewLabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                NewLabel.id_label = NewLabel.NewIndex();
                DB.Add(NewLabel);
                DB.SaveChanges();
                return Ok();
            }
        }

        [Route("ShowCountry/[controller]")]
        [HttpGet]
        public IActionResult ShowCountry()
        {
            ContextDB DB = new ContextDB();
            Country newCountry = new Country();
            var country = DB.country.ToList();
            return Ok(country);
        }

        [Route("ShowType/[controller]")]
        [HttpGet]
        public IActionResult ShowType()
        {
            ContextDB DB = new ContextDB();
            Type_plate newType_plate = new Type_plate();
            var type = DB.type.ToList();
            return Ok(type);
        }

        [Route("ShowCondition/[controller]")]
        [HttpGet]
        public IActionResult ShowCondition()
        {
            ContextDB DB = new ContextDB();
            Condition newCondition = new Condition();
            var condition = DB.condition.ToList();
            return Ok(condition);
        }

        [Route("ShowAlbum/[controller]")]
        [HttpGet]
        public IActionResult ShowAlbum()
        {
            ContextDB DB = new ContextDB();
            Album newAlbum = new Album();
            var album = DB.album.ToList();
            return Ok(album);
        }

        [Route("ShowArtist/[controller]")]
        [HttpGet]
        public IActionResult ShowArtist()
        {
            ContextDB DB = new ContextDB();
            Artist newArtist = new Artist();
            var artist = DB.artist.ToList();
            return Ok(artist);
        }

        [Route("ShowLabel/[controller]")]
        [HttpGet]
        public IActionResult ShowLabel()
        {
            ContextDB DB = new ContextDB();
            Label newLabel = new Label();
            var label = DB.label.ToList();
            return Ok(label);
        }

        [Route("DeleteCountry/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCountryByID(int id_country)
        {
            using (ContextDB DB = new ContextDB())
            {
                Country data = DB.country.Find(id_country);
                if (data != null)
                {
                    DB.country.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }

        [Route("DeleteArtist/[controller]")]
        [HttpDelete]
        public IActionResult DeleteArtistByID(int id_artist)
        {
            using (ContextDB DB = new ContextDB())
            {
                Artist data = DB.artist.Find(id_artist);
                if (data != null)
                {
                    DB.artist.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }

        [Route("DeleteLabel/[controller]")]
        [HttpDelete]
        public IActionResult DeleteLabelByID(int id_label)
        {
            using (ContextDB DB = new ContextDB())
            {
                Label data = DB.label.Find(id_label);
                if (data != null)
                {
                    DB.label.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }
    }
}

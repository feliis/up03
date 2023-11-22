using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    public class VinylController : Controller
    {

        [Route("Show/[controller]")]
        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            using (ContextDB db = new ContextDB())
            {
                var vinylList = await db.vinyl_record
                .Include(s => s.country)
                .Include(s => s.type)
                .Include(s => s.artist)
                .Include(s => s.album)
                .Include(s => s.label)
                .Include(s => s.p_condition )
                .Include(s => s.e_condition)
                .ToListAsync();



                var vinylViewList = vinylList.Select(s => new VinylView
                {
                    img = s.img,
                    id_record = s.id_record,
                    name_record = s.name_record,
                    type = s.type.name_type,
                    album = s.album.name_album,
                    country = s.country.name_country,
                    year_of_issue = s.year_of_issue,
                    year_of_public = s.year_of_public,
                    artist = s.artist.name_artist,
                    label = s.label.name_label,
                    disk_size = s.disk_size,
                    plate_condition = s.p_condition.name_condition,
                    envelope_condition = s.e_condition.name_condition,
                }).ToList();

                return Ok(vinylViewList);
            }
        }

        [Route("Add/Vinyl/{id_record}/{img}/{name_record}/{id_artist}/{id_album}/{id_label}/{id_type}/{id_country}/{plate_condition}/{envelope_condition}/{year_of_issue}/{year_of_public}/{disk_size}")]
        [HttpGet]
        [ValidateAntiForgeryToken]
        [EnableCors(PolicyName = "AllowAll")]
        public IActionResult AddNewVinyl([FromRoute] int id_record, [FromRoute] string img, [FromRoute] string name_record, [FromRoute] int id_artist, [FromRoute] int id_album, [FromRoute] int id_label,
            [FromRoute] int id_type, [FromRoute] int id_country, [FromRoute] int year_of_issue, [FromRoute] int year_of_public, [FromRoute] int plate_condition, 
            [FromRoute] int envelope_condition, [FromRoute] string disk_size)
        {
            
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            using (ContextDB DB = new ContextDB())
            {
                Vinyl_Record NewRecord = new Vinyl_Record();
                NewRecord.id_record = NewRecord.NewIndex();
                NewRecord.img = img;
                NewRecord.name_record = name_record;
                NewRecord.id_country = id_country;
                NewRecord.id_album = id_album;
                NewRecord.id_label = id_label;
                NewRecord.id_type = id_type;
                NewRecord.id_artist = id_artist;
                NewRecord.year_of_issue = year_of_issue;
                NewRecord.year_of_public = year_of_public;
                NewRecord.plate_condition = plate_condition;
                NewRecord.envelope_condition = envelope_condition;
                NewRecord.disk_size = disk_size;

                DB.Add(NewRecord);
                DB.SaveChanges();
                return Ok();
            }
        }

        

        [Route("Delete/[controller]/{id_record}")]
        [HttpGet]
        public IActionResult DeleteCassetteByID(int id_record)
        {
            using (ContextDB DB = new ContextDB())
            {
                Vinyl_Record data = DB.vinyl_record.Find(id_record);
                if (data != null)
                {
                    DB.vinyl_record.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }
    }
}

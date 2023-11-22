//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApi.Models;

//namespace WebApi.Controllers
//{
//    public class DeliveryController : Controller
//    {
//        [Route("Add/[controller]/{id_delivery}/{id_cassette}/{qty}")]
//        [HttpGet]
//        public IActionResult AddDelivery([FromRoute] int id_delivery,[FromRoute] int id_cassette, [FromRoute] int qty)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            using (ContextDB DB = new ContextDB())
//            {
//                Delivery NewDelivery = new Delivery();
//                NewDelivery.id_delivery = NewDelivery.NewIndex();
//                NewDelivery.id_cassette = id_cassette;
//                NewDelivery.qty = qty;
//                DB.Add(NewDelivery);
//                DB.SaveChanges();
//                return Ok();
//            }
//        }

//        [Route("Show/[controller]")]
//        [HttpGet]
//        [EnableCors(PolicyName = "AllowAll")]
//        public async Task<IActionResult> ShowAll()
//        {
//            using (ContextDB db = new ContextDB())
//            {
//                var deliveryList = await db.delivery
//                .Include(s => s.cassette)
//                .ToListAsync();



//                var deliveryViewList = deliveryList.Select(s => new DeliveryView
//                {
//                    id_delivery = s.id_delivery,
//                    id_cassette = s.id_cassette,
//                    name_movie = s.cassette.name_movie,
//                    qty = s.qty
//                }).ToList();

//                return Ok(deliveryViewList);
//            }
//        }

//        [Route("DeleteDelivery/[controller]/{id_delivery}")]
//        [HttpGet]
//        public IActionResult DeleteDeliveryByID(int id_delivery)
//        {
//            using (ContextDB DB = new ContextDB())
//            {
//                Delivery data = DB.delivery.Find(id_delivery);
//                if (data != null)
//                {
//                    DB.delivery.Remove(data);
//                    DB.SaveChanges();
//                    return Ok();
//                }
//                return BadRequest(ModelState);

//            }
//        }
//    }
//}

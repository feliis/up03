using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]

    public class SaleController : Controller
    {
        [Route("Show/[controller]")]
        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            using (ContextDB db = new ContextDB())
            {
                var saleList = await db.sale
                .Include(s => s.vinyl_record)
                .Include(s => s.employee)
                .ToListAsync();



                var saleViewList = saleList.Select(s => new SaleView
                {
                    id_sale = s.id_sale,
                    id_record = s.id_record,
                    name_record = s.vinyl_record.name_record,
                    employee_firstname = s.employee.firstname,
                    employee_surname = s.employee.surname,
                    //date = s.date
                }).ToList();

                return Ok(saleViewList);
            }
        }
        [Route("Add/[controller]/{id_sale}/{id_record}/{id_employee}")]
        [HttpGet]
        public IActionResult AddSale([FromRoute] int id_sale, [FromRoute] int id_record, [FromRoute] int id_employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB DB = new ContextDB())
            {
                Sale NewSale = new Sale();
                NewSale.id_sale = NewSale.NewIndex();
                NewSale.id_record = id_record;
                NewSale.id_employee = id_employee;
                DB.Add(NewSale);
                DB.SaveChanges();
                return Ok();
            }
        }

        [Route("Delete/[controller]/{id_sale}")]
        [HttpGet]
        public IActionResult DeleteSaleByID(int id_sale)
        {
            using (ContextDB DB = new ContextDB())
            {
                Sale data = DB.sale.Find(id_sale);
                if (data != null)
                {
                    DB.sale.Remove(data);
                    DB.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }
    }
}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Sale
    {

        [Key]
        public int id_sale { get; set; }

        public int id_record { get; set; }

        public int id_employee { get; set; }

        public DateTime date { get; set; }

        [ForeignKey("id_record")]
        public Vinyl_Record vinyl_record { get; set; }

        [ForeignKey("id_employee")]
        public Employee employee { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var SaleList = DB.sale.ToList();
                foreach (Sale p in SaleList)
                {
                    if (p.id_sale > Max) Max = p.id_sale;
                }
                return (Max + 1);
            }
        }
    }
}

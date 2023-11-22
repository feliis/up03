
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Style_Record
    {

        [Key]
        public int id_styles_record { get; set; }

        public string id_vinyl_record { get; set; }

        public string id_style { get; set; }

        [ForeignKey("id_record")]
        public Vinyl_Record vinyl_record { get; set; }

        [ForeignKey("id_style")]
        public Style style { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var StyleList = DB.style.ToList();
                foreach (Style p in StyleList)
                {
                    if (p.id_style > Max) Max = p.id_style;
                }
                return (Max + 1);
            }
        }
    }
}

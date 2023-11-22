
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Style
    {

        [Key]
        public int id_style { get; set; }

        public string name_style { get; set; }

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

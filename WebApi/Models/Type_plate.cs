using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Type_plate
    {

        [Key]
        public int id_type { get; set; }

        public string name_type { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var TypeList = DB.type.ToList();
                foreach (Type_plate p in TypeList)
                {
                    if (p.id_type > Max) Max = p.id_type;
                }
                return (Max + 1);
            }
        }
    }
}

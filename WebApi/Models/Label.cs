using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Label
    {

        [Key]
        public int id_label { get; set; }

        public string name_label { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var LabelList = DB.label.ToList();
                foreach (Label p in LabelList)
                {
                    if (p.id_label > Max) Max = p.id_label;
                }
                return (Max + 1);
            }
        }
    }
}

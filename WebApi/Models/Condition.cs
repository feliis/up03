
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Condition
    {

        [Key] 
        public int id_condition { get; set; }

        public string name_condition { get; set; }

        public string decryption { get; set; }

        public string description { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var ConditionList = DB.condition.ToList();
                foreach (Condition p in ConditionList)
                {
                    if (p.id_condition > Max) Max = p.id_condition;
                }
                return (Max + 1);
            }
        }
    }
}

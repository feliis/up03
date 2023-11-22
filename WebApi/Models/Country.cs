
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Country
    {

        [Key] 
        public int id_country { get; set; }

        public string name_country { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var CountryList = DB.country.ToList();
                foreach (Country p in CountryList)
                {
                    if (p.id_country > Max) Max = p.id_country;
                }
                return (Max + 1);
            }
        }
    }
}

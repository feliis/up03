
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Artist
    {

        [Key] 
        public int id_artist { get; set; }

        public string name_artist { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var ArtistList = DB.artist.ToList();
                foreach (Artist p in ArtistList)
                {
                    if (p.id_artist > Max) Max = p.id_artist;
                }
                return (Max + 1);
            }
        }
    }
}

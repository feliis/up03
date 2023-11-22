using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class Album
    {

        [Key]
        public int id_album { get; set; }

        public string name_album { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var AlbumList = DB.album.ToList();
                foreach (Album p in AlbumList)
                {
                    if (p.id_album > Max) Max = p.id_album;
                }
                return (Max + 1);
            }
        }
    }
}

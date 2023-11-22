
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace WebApi.Models
{
    public class Vinyl_Record
    {

        [Key]
        public int id_record { get; set; }

        public string img { get; set; }
        public string name_record { get; set; } = string.Empty;

        public int id_artist { get; set; }

        public int id_album { get; set; }

        public int id_country { get; set; }

        public int id_label { get; set; }
        public int year_of_issue { get; set; }
        public int year_of_public { get; set; }

        public int id_type { get; set; }

        public int plate_condition { get; set; }

        public int envelope_condition { get; set; }
        public string disk_size { get; set; }

        //Внешние ключи

        [ForeignKey("id_country")]
        public Country country { get; set; }

        [ForeignKey("id_type")]
        public Type_plate type { get; set; }

        [ForeignKey("plate_condition")]
        public Condition p_condition { get; set; }

        [ForeignKey("envelope_condition")]
        public Condition e_condition { get; set; }

        [ForeignKey("id_label")]
        public Label label { get; set; }

        [ForeignKey("id_album")]
        public Album album { get; set; }

        [ForeignKey("id_artist")]
        public Artist artist { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var VinylRecordList = DB.vinyl_record.ToList();
                foreach (Vinyl_Record p in VinylRecordList)
                {
                    if (p.id_record > Max) Max = p.id_record;
                }
                return (Max + 1);
            }
        }
    }
}

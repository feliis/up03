using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class VinylView
    {
        public string img { get; set; }
        public int id_record { get; set; }
        public string name_record { get; set; } = string.Empty;
        public string album { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public string name_artist { get; set; }
        public string country { get; set; }
        public string plate_condition { get; set; }
        public string envelope_condition { get; set; }
        public int year_of_issue { get; set; }
        public int year_of_public { get; set; }
        public string artist { get; set; }
        public string disk_size { get; set; }
        //public DateTime date { get; set; }
    }
}

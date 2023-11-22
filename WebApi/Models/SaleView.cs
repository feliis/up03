using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Models
{
    public class SaleView
    {
        public int id_sale { get; set; }

        public int id_record { get; set; }

        public string name_record { get; set; }

        public string employee_firstname { get; set; }

        public string employee_surname { get; set; }

        public DateTime date { get; set; }

    }
}

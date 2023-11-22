
//using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;


//namespace WebApi.Models
//{
//    public class Delivery
//    {

//        [Key]
//        public int id_delivery { get; set; }

//        public int id_cassette { get; set; }


//        public int qty { get; set; }

//        [ForeignKey("id_cassette")]
//        public Cassette cassette { get; set; }

//        public virtual int NewIndex() 
//        {
//            using (ContextDB DB = new ContextDB())
//            {
//                int Max = -1;
//                var DeliveryList = DB.delivery.ToList();
//                foreach (Delivery p in DeliveryList)
//                {
//                    if (p.id_delivery > Max) Max = p.id_delivery;
//                }
//                return (Max + 1);
//            }
//        }
//    }
//}
    
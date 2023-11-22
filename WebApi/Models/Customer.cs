
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;


//namespace WebApi.Models
//{
//    public class Customer
//    {

//        [Key] 
//        public int id_customer { get; set; }

//        public string surname { get; set; } 
//        public string firstname { get; set; }
//        public string phone { get; set; }

//        public virtual int NewIndex()
//        {
//            using (ContextDB DB = new ContextDB())
//            {
//                int Max = -1;
//                var CustomerList = DB.customer.ToList();
//                foreach (Customer p in CustomerList)
//                {
//                    if (p.id_customer > Max) Max = p.id_customer;
//                }
//                return (Max + 1);
//            }
//        }

//    }
//}

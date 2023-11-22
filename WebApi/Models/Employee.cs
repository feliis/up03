
using System.ComponentModel.DataAnnotations;


namespace WebApi.Models
{
    public class Employee
    {

        [Key]
        public int id_employee { get; set; } 

        public string surname { get; set; }

        public string firstname { get; set; }

        public string patronymic { get; set; }

        public string phone { get; set; }

        public virtual int NewIndex()
        {
            using (ContextDB DB = new ContextDB())
            {
                int Max = -1;
                var EmployeeList = DB.employee.ToList();
                foreach (Employee p in EmployeeList)
                {
                    if (p.id_employee > Max) Max = p.id_employee;
                }
                return (Max + 1);
            }
        }

    }
}

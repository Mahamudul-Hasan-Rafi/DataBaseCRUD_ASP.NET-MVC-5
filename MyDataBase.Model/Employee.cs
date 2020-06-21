using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyDataBase.Model
{
    public class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Invalid Input")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Invalid Input")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Invalid Input")]
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}

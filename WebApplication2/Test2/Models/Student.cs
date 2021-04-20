using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Fist Name")]
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        
        public int MyGroupId { get; set; }
        public MyGroup MyGroup { get; set; }


    }
}

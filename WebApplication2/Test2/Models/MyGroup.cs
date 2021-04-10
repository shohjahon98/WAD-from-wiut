using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class MyGroup
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }

        public List<Student> Students { get; set; }
    }
}

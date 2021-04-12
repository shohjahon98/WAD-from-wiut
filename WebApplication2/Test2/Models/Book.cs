using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorBook { get; set; }

        public int JanrId { get; set; }
        public Janr Janr { get; set; }
    }
}

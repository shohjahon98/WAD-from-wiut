﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string Fio { get; set; }
        public DateTime BirthDay { get; set; }
        
        public int MyGroupId { get; set; }
        public Groups MyGroup { get; set; }


    }
}
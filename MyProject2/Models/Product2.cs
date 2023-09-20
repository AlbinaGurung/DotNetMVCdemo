
   using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyProject2.Models
{
    [Table("in_prod")]
    public class Product2
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}


using MyProject2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MyProject2.ViewModels
{
    public class ProductAddVm
    {
       public int Id { get; set; }
       public String? Name { get; set; }
        
        public int Price { get; set; }
        public int CategoryId {get; set;}
        [ValidateNever]
        public List<Category> Categories { get; set; }

     public SelectList CategoryOptionSelectList()
    {
        return new SelectList(
            Categories, // List of items
            nameof(Category.Id), // Which Property to use for Value 
            nameof(Category.Name), // Which property to use for display
           CategoryId // Selected value
        );
    }
    }
}

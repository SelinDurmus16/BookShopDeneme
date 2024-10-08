﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookShop.Models
{
    // Category Model
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")] //validation for range 
        public int DisplayOrder { get; set; }
    }
}

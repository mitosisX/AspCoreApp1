﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspCategoryApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Range(1,100, ErrorMessage="Range must be between 1 and 100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
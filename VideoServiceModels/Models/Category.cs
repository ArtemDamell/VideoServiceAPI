﻿using System.ComponentModel.DataAnnotations;

namespace VideoService.Models.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int VideoId { get; set; }
    }
}

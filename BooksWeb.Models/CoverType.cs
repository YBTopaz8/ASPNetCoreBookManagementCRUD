using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BooksWeb.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Cover")]
        public string Name { get; set; }
    }
}

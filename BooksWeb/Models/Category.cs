using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksWeb.Models
{
    public class Category
    {
        [Key] //to set ID as a primary key, not null, Auto Incremented
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }

    //first add-migration _migration_name_
    //then, update-database
}

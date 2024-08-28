using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace PD324_01.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [ValidateNever]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [ValidateNever]
        public decimal Price { get; set; }
        public string Image { get; set; }

        [ForeignKey("Category")]
        public int CatgoryId { get; set; }
        public Category? Category { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiFelipe.Models;

[Index(nameof(Id))]
[Table("products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("description", TypeName = "VARCHAR(300)")]
    [Required(ErrorMessage = "Description is a required field!")]
    [MinLength(3, ErrorMessage = "Description field must contain at least 3 characters!")]
    [MaxLength(300, ErrorMessage = "Description field can not exceed 300 characters!")]
    public string Description { get; set; } = string.Empty;

    [Column("name", TypeName = "VARCHAR(150)")]
    [Required(ErrorMessage = "Name is a required field!")]
    [MinLength(3, ErrorMessage = "Name field must contain at least 3 characters!")]
    [MaxLength(150, ErrorMessage = "Name field can not exceed 150 characters!")]
    public string Name { get; set; } = string.Empty;

    [Column("price", TypeName = "DECIMAL(6, 2)")]
    [Required(ErrorMessage = "Price is a required field!")]
    [Range(1.0, 9999.99, ErrorMessage = "Price must be between 1.0 and 9999.99")]
    public decimal Price { get; set; }
}
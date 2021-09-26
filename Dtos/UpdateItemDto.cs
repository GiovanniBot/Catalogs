using System.ComponentModel.DataAnnotations;

namespace Catalogs.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init; }
        
        [Required]
        [Range(1, 99999)]
        public decimal Price { get; set; }
    }
}
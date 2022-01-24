using Catalogs.Dtos;
using Catalogs.Entities;

namespace Catalogs.Extensions
{
    public static class AsDtoExtension
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}
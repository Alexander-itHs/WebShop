using WebShop.DTOs;

namespace WebShop.Models;

public static class ModelExtensions
{
	public static Product ToProduct(this PostProductDTO postProductDTO)
	{
		return new Product
		{
			Name = postProductDTO.Name,
			Description = postProductDTO.Description,
			Price = postProductDTO.Price,
			Quantity = postProductDTO.Quantity
		};
	}
	public static Image ToImage(this PostImageDTO postImageDTO) 
	{
		return new Image
		{
			URL = postImageDTO.URL
		};
	}
}

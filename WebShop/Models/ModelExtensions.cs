using WebShop.Client.Pages;
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

    public static List<ImageDTO> ToImageDTOs(this IEnumerable<Image> images) 
    {
        List<ImageDTO> imageDTOs = new List<ImageDTO>();

        foreach (Image image in images)
        {
            ImageDTO imageDTO = new ImageDTO()
            {
                Id = image.Id,
                URL = image.URL
            };
            imageDTOs.Add(imageDTO);
        }
        return imageDTOs;
    }

	public static Customer ToCustomer(this CustomerDTO customerDTO) 
	{
		return new Customer
		{
			FirstName = customerDTO.FirstName,
			LastName = customerDTO.LastName,
			Address = customerDTO.Address,
			PhoneNumber = customerDTO.PhoneNumber
		};		
	}  
}

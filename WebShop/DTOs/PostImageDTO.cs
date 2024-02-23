using WebShop.Models;

namespace WebShop.DTOs
{
	public class PostImageDTO
	{
		public required string URL { get; set; }
		public Product? Product { get; set; }
	}
}

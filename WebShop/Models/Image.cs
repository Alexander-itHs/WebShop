namespace WebShop.Models
{
	public class Image
	{
		public int Id { get; set; }
		public required string URL { get; set; }
		public  Product? Product { get; set; }
	}
}

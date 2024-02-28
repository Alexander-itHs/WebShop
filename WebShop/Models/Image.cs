namespace WebShop.Models
{
	public class Image
	{
		public int Id { get; set; }
		public string URL { get; set; } = null!;
		public  Product? Product { get; set; }
	}
}

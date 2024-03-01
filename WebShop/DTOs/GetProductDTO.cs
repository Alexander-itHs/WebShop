namespace WebShop.DTOs
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public List<ImageDTO>? Images { get; set; }
    }
}

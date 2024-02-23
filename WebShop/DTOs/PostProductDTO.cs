﻿namespace WebShop.DTOs
{
	public class PostProductDTO
	{
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public decimal? Price { get; set; }
		public int? Quantity { get; set; }
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.DTOs;
using WebShop.Models;

namespace WebShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

		[HttpPost]
		public async Task PostProduct(PostProductDTO postProductDTO)
		{
			Product product = postProductDTO.ToProduct();
			_context.Product.Add(product);
			await _context.SaveChangesAsync();
		}
    }
}

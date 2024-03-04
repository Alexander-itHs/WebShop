using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.DTOs;
using WebShop.Models;
using static System.Net.Mime.MediaTypeNames;

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

		[HttpGet]
        public async Task<IEnumerable<GetProductDTO>> GetProducts() 
        {
            var products = await _context.Product
                .Include(product => product.Images)
                .ToListAsync();

            List<GetProductDTO> productDTOsToReturn = new List<GetProductDTO>();

            foreach (Product product in products) 
            {
                GetProductDTO productDTO = new GetProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Images = product.Images?.ToImageDTOs()
                };
				
                productDTOsToReturn.Add(productDTO);
            }
            return productDTOsToReturn;
        }

        [HttpGet("{id}")]
        public async Task<GetProductDTO> GetProduct(int id)
        {
            Product? product = await _context.Product
                            .Include(product => product.Images)
                            .SingleOrDefaultAsync(product => product.Id == id);

            //if (product == null) 
            //{
            //    return NotFound();            
            //}

            GetProductDTO productDTOToReturn = new()
            { 
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images?.ToImageDTOs()            
            };
            return productDTOToReturn;
        }
       

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Data;
using WebShop.DTOs;
using WebShop.Models;

namespace WebShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
	private readonly ApplicationDbContext _context;
    public ProductImagesController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task <ActionResult<PostProductImageDTO>> PostProductImage(PostProductImageDTO postProductImageDTO)
    {
        Product? product = await _context.Product.FindAsync(postProductImageDTO.ProductId);

        if (product == null) 
        {
            return NotFound($"Product Id not found!");
        }

        Image? image = await _context.Image.FindAsync(postProductImageDTO.ImageId);
        
        if (image == null)
        {
            return NotFound($"Image Id not found!");
        }

        if (product.Images  == null) 
        {
            product.Images = new List<Image>();
        }
		product.Images.Add(image);

        
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

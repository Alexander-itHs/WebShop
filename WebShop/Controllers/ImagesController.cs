using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Data;
using WebShop.DTOs;
using WebShop.Models;

namespace WebShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
			_context = context;
        }

		[HttpPost]
		public async Task PostImage(PostImageDTO postImageDTO)
		{
			Image image = postImageDTO.ToImage();
			_context.Image.Add(image);
			await _context.SaveChangesAsync();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteImage(int id)
		{
			Image? image = await _context.Image.FindAsync(id);

			if (image == null) 
			{
				return NotFound();
			}

			_context.Image.Remove(image);
			await _context.SaveChangesAsync();

			return NoContent();
		}
		[HttpPatch]
		public async Task<IActionResult> EditImage(EditImageDTO editImageDTO)
		{
			Image? image =  _context.Image
				.FirstOrDefault(image => image.Id == editImageDTO.Id);

			if (image == null) 
			{
				return NotFound();
			}
			
			
			image.URL = editImageDTO.URL;

			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}

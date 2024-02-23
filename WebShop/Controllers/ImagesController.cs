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
    }
}

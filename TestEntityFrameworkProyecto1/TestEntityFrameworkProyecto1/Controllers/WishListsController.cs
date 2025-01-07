using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TestEntityFrameworkProyecto1.Context;
using TestEntityFrameworkProyecto1.Models;

namespace TestEntityFrameworkProyecto1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WishListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WishListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishListDto>>> GetWishLists()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var wishLists = await _context.WishLists
                .Where(w => w.UserId == userId)
                .Include(w => w.Items)
                .ThenInclude(i => i.Product)
                .Select(w => new WishListDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Products = w.Items.Select(i => new ProductDto
                    {
                        Id = i.Product.Id,
                        Name = i.Product.Name,
                        Description = i.Product.Description,
                        Price = i.Product.Price,
                        ImageUrl = i.Product.ImageUrl,
                        Stock = i.Product.Stock
                    }).ToList()
                })
                .ToListAsync();

            return Ok(wishLists);
        }

        [HttpPost]
        public async Task<ActionResult<WishListDto>> CreateWishList(CreateWishListDto createDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var wishList = new WishList
            {
                Name = createDto.Name,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.WishLists.Add(wishList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetWishList),
                new { id = wishList.Id },
                new WishListDto
                {
                    Id = wishList.Id,
                    Name = wishList.Name,
                    Products = new List<ProductDto>()
                });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WishListDto>> GetWishList(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var wishList = await _context.WishLists
                .Include(w => w.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(w => w.Id == id && w.UserId == userId);

            if (wishList == null)
                return NotFound();

            return new WishListDto
            {
                Id = wishList.Id,
                Name = wishList.Name,
                Products = wishList.Items.Select(i => new ProductDto
                {
                    Id = i.Product.Id,
                    Name = i.Product.Name,
                    Description = i.Product.Description,
                    Price = i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Stock = i.Product.Stock
                }).ToList()
            };
        }

        [HttpPost("{wishListId}/products/{productId}")]
        public async Task<IActionResult> AddProductToWishList(int wishListId, int productId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var wishList = await _context.WishLists
                .FirstOrDefaultAsync(w => w.Id == wishListId && w.UserId == userId);

            if (wishList == null)
                return NotFound("WishList not found");

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound("Product not found");

            var wishListItem = await _context.WishListItems
                .FirstOrDefaultAsync(w => w.WishListId == wishListId && w.ProductId == productId);

            if (wishListItem != null)
                return BadRequest("Product already in wishlist");

            wishListItem = new WishListItem
            {
                WishListId = wishListId,
                ProductId = productId,
                CreatedAt = DateTime.UtcNow
            };

            _context.WishListItems.Add(wishListItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{wishListId}/products/{productId}")]
        public async Task<IActionResult> RemoveProductFromWishList(int wishListId, int productId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var wishList = await _context.WishLists
                .FirstOrDefaultAsync(w => w.Id == wishListId && w.UserId == userId);

            if (wishList == null)
                return NotFound("WishList not found");

            var wishListItem = await _context.WishListItems
                .FirstOrDefaultAsync(w => w.WishListId == wishListId && w.ProductId == productId);

            if (wishListItem == null)
                return NotFound("Product not found in wishlist");

            _context.WishListItems.Remove(wishListItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishList(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var wishList = await _context.WishLists
                .FirstOrDefaultAsync(w => w.Id == id && w.UserId == userId);

            if (wishList == null)
                return NotFound();

            _context.WishLists.Remove(wishList);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

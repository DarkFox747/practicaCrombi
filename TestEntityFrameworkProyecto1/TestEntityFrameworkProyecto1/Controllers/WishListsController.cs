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
        private readonly ILogger<WishListsController> _logger;

        public WishListsController(ApplicationDbContext context, ILogger<WishListsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishListDto>>> GetWishLists()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                _logger.LogInformation($"Obteniendo wishlists para el usuario {userId}");

                var wishLists = await _context.WishLists
                    .AsNoTracking()
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

                _logger.LogInformation($"Se encontraron {wishLists.Count} wishlists");
                return Ok(wishLists);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener wishlists: {ex.Message}");
                return StatusCode(500, "Error interno al obtener las wishlists");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WishListDto>> GetWishList(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var wishList = await _context.WishLists
                .AsNoTracking()
                .Include(w => w.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(w => w.Id == id && w.UserId == userId);

            if (wishList == null)
                return NotFound($"No se encontró la wishlist con ID {id}");

            var wishListDto = new WishListDto
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

            return Ok(wishListDto);
        }

        [HttpPost]
        public async Task<ActionResult<WishListDto>> CreateWishList(CreateWishListDto createDto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var wishList = new WishList
            {
                Name = createDto.Name,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                Items = new List<WishListItem>()
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

        [HttpPost("{wishListId}/products")]
        public async Task<ActionResult<WishListDto>> AddProductToWishList(int wishListId, [FromBody] int productId)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

                var wishList = await _context.WishLists
                    .Include(w => w.Items)
                    .FirstOrDefaultAsync(w => w.Id == wishListId && w.UserId == userId);

                if (wishList == null)
                    return NotFound("WishList no encontrada");

                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                    return NotFound("Producto no encontrado");

                if (wishList.Items.Any(i => i.ProductId == productId))
                    return BadRequest("El producto ya está en la wishlist");

                var wishListItem = new WishListItem
                {
                    WishListId = wishListId,
                    ProductId = productId,
                    CreatedAt = DateTime.UtcNow
                };

                wishList.Items.Add(wishListItem);
                await _context.SaveChangesAsync();

                // Recargar la wishlist con los productos
                var updatedWishList = await _context.WishLists
                    .Include(w => w.Items)
                        .ThenInclude(i => i.Product)
                    .FirstOrDefaultAsync(w => w.Id == wishListId);

                var wishListDto = new WishListDto
                {
                    Id = updatedWishList.Id,
                    Name = updatedWishList.Name,
                    Products = updatedWishList.Items.Select(i => new ProductDto
                    {
                        Id = i.Product.Id,
                        Name = i.Product.Name,
                        Description = i.Product.Description,
                        Price = i.Product.Price,
                        ImageUrl = i.Product.ImageUrl,
                        Stock = i.Product.Stock
                    }).ToList()
                };

                return Ok(wishListDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al agregar producto a la wishlist: {ex.Message}");
                return StatusCode(500, "Error interno al agregar el producto a la wishlist");
            }
        }

        [HttpDelete("{wishListId}/products/{productId}")]
        public async Task<ActionResult<WishListDto>> RemoveProductFromWishList(int wishListId, int productId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

            var wishList = await _context.WishLists
                .Include(w => w.Items)
                .FirstOrDefaultAsync(w => w.Id == wishListId && w.UserId == userId);

            if (wishList == null)
                return NotFound("WishList no encontrada");

            var wishListItem = wishList.Items.FirstOrDefault(i => i.ProductId == productId);
            if (wishListItem == null)
                return NotFound("Producto no encontrado en la wishlist");

            wishList.Items.Remove(wishListItem);
            await _context.SaveChangesAsync();

            // Recargar la wishlist actualizada
            var updatedWishList = await _context.WishLists
                .Include(w => w.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(w => w.Id == wishListId);

            var wishListDto = new WishListDto
            {
                Id = updatedWishList.Id,
                Name = updatedWishList.Name,
                Products = updatedWishList.Items.Select(i => new ProductDto
                {
                    Id = i.Product.Id,
                    Name = i.Product.Name,
                    Description = i.Product.Description,
                    Price = i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Stock = i.Product.Stock
                }).ToList()
            };

            return Ok(wishListDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishList(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

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

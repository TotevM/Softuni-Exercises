using System.Globalization;
using System.Security.Claims;
using DeskMarket.Common;
using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DeskMarket.Common.ModelValidationConstants;

namespace DeskMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<CategoryViewModel> categories = await context.Categories
                .Select(g => new CategoryViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();


            AddProductView model = new AddProductView()
            {
                Categories = categories,
                AddedOn = DateTime.Now.ToString(DateFormat)
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!DateTime.TryParse(model.AddedOn, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime releasedOn))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            var product = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                AddedOn = releasedOn,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                SellerId = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                Price = model.Price
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<ProductViewModel> productViewModels = await context.Products.Where(x=>x.IsDeleted==false).Select(p => new ProductViewModel
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                IsSeller = p.SellerId == userId,
                HasBought = p.ProductsClients.Any(pc => pc.ClientId == userId)
            }).ToListAsync();

            return View(productViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<CartViewModel> cartViewModels = await context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.ClientId == userId))
                .Select(p => new CartViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                })
                .ToListAsync();

            return View(cartViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var productClient = await context.ProductsClients
                .FirstOrDefaultAsync(pc => pc.ProductId == id && pc.ClientId == userId);

            if (productClient != null)
            {
                context.ProductsClients.Remove(productClient);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
                AddedOn = product.AddedOn,
                Seller = product.Seller.UserName,
                HasBought = product.ProductsClients.Any(pc => pc.ClientId == userId), 
                IsSeller = product.SellerId == userId 
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product =await context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductEditViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                AddedOn = product.AddedOn.ToString(),
                CategoryId = product.CategoryId,
                SellerId = product.SellerId,
                Categories = context.Categories.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            model.Categories = await context.Categories.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (product == null)
            {
                return NotFound();
            }


            if (!DateTime.TryParse(model.AddedOn, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                model.Categories = context.Categories.ToList();
                return View(model);
            }

            product.ProductName = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.AddedOn = dateValue;
            product.CategoryId = model.CategoryId;

            context.Products.Update(product);
            await context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

            DeleteView model= new DeleteView();
            {
                model.Id = id;
                model.ProductName = product.ProductName;
                model.Seller = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteView model)
        {
            var product =await context.Products.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (product == null)
            {
                return NotFound();
            }

            product.IsDeleted = true;

            context.Products.Update(product);
            await context.SaveChangesAsync();           

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            bool isInCart = await context.ProductsClients.AnyAsync(pc => pc.ProductId == id && pc.ClientId == userId);

            if (isInCart)
            {
                TempData["Message"] = "This product is already in your cart.";
                return RedirectToAction("Details", new { id = id });
            }

            var productClient = new ProductClient
            {
                ProductId = product.Id,
                ClientId = userId
            };

            context.ProductsClients.Add(productClient);
            await context.SaveChangesAsync();

            TempData["Message"] = "Product successfully added to your cart.";
            return RedirectToAction("Index", "Product");
        }
    }
}
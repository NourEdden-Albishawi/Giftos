using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giftos.Entities;
using Giftos.Services;
using System.Linq;
using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Giftos.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductsController> _logger;


        public ProductsController(DataContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            List<Product> list = await _context.Products.ToListAsync();
            if (list.Count > 8)
            {
                return View(list.GetRange(0,7));
            }
            return View(list);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View(new Product());
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Description, Stock, Price, Image")] Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    product.Image = memoryStream.ToArray();
                }
            }
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Product saved to database.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving product to database: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while saving the product.");
                return View(product);
            }


            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        [Route("Products/Edit/{id:Guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("---------- Logging from Edit/GET METHOD ----------");
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            _logger.LogError(errors.ToString());

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Description,Stock,Price,Image")] Product product)
        {
            _logger.LogInformation("---------- Logging from Edit/POST METHOD ----------");
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            _logger.LogError(errors.ToString());

            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files.FirstOrDefault();
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        product.Image = memoryStream.ToArray();
                        _logger.LogInformation("File has been copied to Memory Stream!");
                    }
                }

                try
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();
                } catch (DbUpdateConcurrencyException) {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

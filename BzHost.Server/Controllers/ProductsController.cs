using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    private ApplicationDbContext _context;
    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Products.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_context.Products.FirstOrDefault(x => x.ID == id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody]Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }
}
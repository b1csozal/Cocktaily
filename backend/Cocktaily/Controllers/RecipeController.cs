using Cocktaily.Database;
using Cocktaily.Models;
using Microsoft.AspNetCore.Mvc;
using MyApp.Backend.Database;

namespace Cocktaily.Controllers;

[ApiController]
//[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly AppDbContext _context;

    public RecipeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        List<CategoryEntity> categories = _context.Categories.ToList();

        var result = categories.Select(x => new CategoryModel(x)).ToList();

        return Ok(result);
    }
}

using Cocktaily.Database;
using Cocktaily.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using MyApp.Backend.Database;

namespace Cocktaily.Controllers;

[ApiController]
//[Route("recipes")]
public class MainController : ControllerBase
{
    private readonly AppDbContext _context;

    public MainController(AppDbContext context)
    {
        _context = context;
    }

    // ------------------------------ CATEGORIES ------------------------------
    [HttpGet("all-categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        List<CategoryEntity> categories = _context.Categories.ToList();

        var result = categories.Select(x => new CategoryModel(x)).ToList();

        return Ok(result);
    }

    [HttpPost("category")]
    [Authorize]
    public async Task<IActionResult> AddCategory([FromBody] CategoryModel category)
    {
        try
        {
            if (category.Name == null)
            {
                return BadRequest("Kategória neve nem értelmezhető");
            }

            CategoryEntity categoryEntity = category.ToEntity();

            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();

            return Ok();
        } catch
        {
            return StatusCode(500);
        }
    }

    [HttpPut("categories/{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateCategory([FromQuery] int id, [FromBody] CategoryModel category)
    {
        try
        {
            if (category.Name == null)
            {
                return BadRequest("Kategória neve nem értelmezhető");
            }

            var updatingCategory = _context.Categories.Where(x => x.Id == id).FirstOrDefault();

            if (updatingCategory == null)
            {
                return BadRequest("Kategória az adott azonosítóval nem létezik");
            }

            updatingCategory.Name = category.Name;
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("categories/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteCategory([FromQuery] int id)
    {
        try
        {
            var deletingCategory = _context.Categories.Where(x => x.Id == id).FirstOrDefault();

            if (deletingCategory == null)
            {
                return BadRequest("Kategória az adott azonosítóval nem létezik");
            }

            _context.Categories.Remove(deletingCategory);
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // ------------------------------ INGREDIENT BASES ------------------------------
    [HttpGet("all-ingredientbases")]
    public async Task<IActionResult> GetAllIngredientBases()
    {
        List<IngredientBaseEntity> ingredientBases = _context.IngredientBases.ToList();

        var result = ingredientBases.Select(x => new IngredientBaseModel(x)).ToList();

        return Ok(result);
    }

    [HttpPost("ingredientbase")]
    [Authorize]
    public async Task<IActionResult> AddIngredientBase([FromBody] IngredientBaseModel ingredientBase)
    {
        try
        {
            if (ingredientBase.Name == null)
            {
                return BadRequest("Hozzávaló neve nem értelmezhető");
            }

            IngredientBaseEntity ingredientBaseEntity = ingredientBase.ToEntity();

            _context.IngredientBases.Add(ingredientBaseEntity);
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPut("ingredientbases/{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateIngredientBase([FromQuery] int id, [FromBody] IngredientBaseModel ingredientBase)
    {
        try
        {
            if (ingredientBase.Name == null)
            {
                return BadRequest("Hozzávaló neve nem értelmezhető");
            }

            var updatingIngredientBase = _context.IngredientBases.Where(x => x.Id == id).FirstOrDefault();

            if (updatingIngredientBase == null)
            {
                return BadRequest("Hozzávaló az adott azonosítóval nem létezik");
            }

            updatingIngredientBase.Name = ingredientBase.Name;
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("ingredientbases/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteIngredient([FromQuery] int id)
    {
        try
        {
            var deletingIngredient = _context.IngredientBases.Where(x => x.Id == id).FirstOrDefault();

            if (deletingIngredient == null)
            {
                return BadRequest("Hozzávaló az adott azonosítóval nem létezik");
            }

            _context.IngredientBases.Remove(deletingIngredient);
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }



    // ------------------------------ GLASSES ------------------------------
    [HttpGet("all-glasses")]
    public async Task<IActionResult> GetAllGlasses()
    {
        List<GlassEntity> glasses = _context.Glasses.ToList();

        var result = glasses.Select(x => new GlassModel(x)).ToList();

        return Ok(result);
    }

    [HttpPost("glass")]
    [Authorize]
    public async Task<IActionResult> AddGlass([FromBody] GlassModel glass)
    {
        try
        {
            if (glass.Name == null)
            {
                return BadRequest("Pohár neve nem értelmezhető");
            }

            if (glass.Capacity == null)
            {
                return BadRequest("Pohár űrtartalma nem értelmezhető");
            }

            GlassEntity glassEntity = glass.ToEntity();

            _context.Glasses.Add(glassEntity);
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPut("glasses/{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateIngredientBase([FromQuery] int id, [FromBody] GlassModel glass)
    {
        try
        {
            if (glass.Name == null)
            {
                return BadRequest("Pohár neve nem értelmezhető");
            }

            if (glass.Capacity == null)
            {
                return BadRequest("Pohár űrtartalma nem értelmezhető");
            }

            var updatingGlass = _context.Glasses.Where(x => x.Id == id).FirstOrDefault();

            if (updatingGlass == null)
            {
                return BadRequest("Pohár az adott azonosítóval nem létezik");
            }

            updatingGlass.Name = glass.Name;
            updatingGlass.Capacity = glass.Capacity;
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("glass/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteGlass([FromQuery] int id)
    {
        try
        {
            var deletingGlass = _context.Glasses.Where(x => x.Id == id).FirstOrDefault();

            if (deletingGlass == null)
            {
                return BadRequest("Pohár az adott azonosítóval nem létezik");
            }

            _context.Glasses.Remove(deletingGlass);
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }



    // ------------------------------ RECIPES ------------------------------
    [HttpGet("all-recipes")]
    public async Task<IActionResult> GetAllRecipes()
    {
        List<RecipeEntity> recipes = _context.Recipes.ToList();

        var result = recipes.Select(x => new RecipeModel(x)).ToList();

        return Ok(result);
    }

    [HttpGet("recipe/{id}")]
    public async Task<IActionResult> GetRecipe([FromQuery] int id)
    {
        var recipe = _context.Recipes.Where(y => y.Id == id).FirstOrDefault();

        if (recipe == null)
        {
            return BadRequest("Recept az adott azonosítóval nem létezik");
        }

        return Ok(new RecipeModel(recipe));
    }

    [HttpPost("recipe")]
    public async Task<IActionResult> AddRecipe([FromBody] RecipeModel recipe)
    {
        try
        {
            if (recipe.Name == null)
            {
                return BadRequest("Recept neve nem értelmezhető");
            }

            if (recipe.Author == null)
            {
                return BadRequest("Recept írója nem értelmezhető");
            }

            if (recipe.Steps == null)
            {
                return BadRequest("Recept elkészítése nem értelmezhető");
            }

            if (recipe.GlassId == 0)
            {
                return BadRequest("Nincs pohár kiválasztva");
            }

            if (recipe.Ingredients.ToList().Count() < 2)
            {
                return BadRequest("Túl kevés hozzávaló");
            }

            RecipeEntity recipeEntity = recipe.ToEntity();
            //recipeEntity.NumberOfRatings = 0;
            //recipeEntity.Views = 0;
            recipeEntity.IsValidated = false;

            _context.Recipes.Add(recipeEntity);
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost("recipe/upload-image")]
    public async Task<IActionResult> UploadRecipeImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file was uploaded");
        }

        const long MaxFileSize = 100 * 1024 * 1024; // 100 MB in bytes
        if (file.Length > MaxFileSize)
            return BadRequest("File too large. Maximum allowed size is 100 MB.");

        // 3️⃣ Check file type (only images)
        var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        string[] fileNameParts = file.FileName.Split(".");
        string fileName = $"{fileNameParts[0]}-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}.{fileNameParts[1]}";

        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new
        {
            fileName,
            file.Length,
            Path = $"/uploads/{fileName}"
        });
    }

    [HttpPut("recipes/{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateRecipe([FromQuery] int id, [FromBody] RecipeModel recipe)
    {
        try
        {
            if (recipe.Name == null)
            {
                return BadRequest("Recept neve nem értelmezhető");
            }

            if (recipe.Author == null)
            {
                return BadRequest("Recept írója nem értelmezhető");
            }

            if (recipe.Steps == null)
            {
                return BadRequest("Recept elkészítése nem értelmezhető");
            }

            if (recipe.GlassId == 0)
            {
                return BadRequest("Nincs pohár kiválasztva");
            }

            if (recipe.Ingredients.ToList().Count() < 2)
            {
                return BadRequest("Túl kevés hozzávaló");
            }

            if (recipe.ImagePath == null)
            {
                return BadRequest("Nincs kép megadva");
            }

            var updatingRecipe = _context.Recipes.Where(x => x.Id == id).FirstOrDefault();

            if (updatingRecipe == null)
            {
                return BadRequest("Recept az adott azonosítóval nem létezik");
            }

            updatingRecipe.Name = recipe.Name;
            updatingRecipe.Author = recipe.Author;
            updatingRecipe.GlassId = recipe.GlassId;
            updatingRecipe.Ingredients = recipe.Ingredients.Select(y => y.ToEntity()).ToList();
            updatingRecipe.ImagePath = recipe.ImagePath;
            updatingRecipe.Steps = recipe.Steps;
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("recipe/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteRecipe([FromQuery] int id)
    {
        try
        {
            var deletingRecipe = _context.Recipes.Where(x => x.Id == id).FirstOrDefault();

            if (deletingRecipe == null)
            {
                return BadRequest("Recept az adott azonosítóval nem létezik");
            }

            _context.Recipes.Remove(deletingRecipe);
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpGet("validate-recipe/{id}")]
    [Authorize]
    public async Task<IActionResult> ValidateRecipe([FromQuery] int id)
    {
        try
        {
            var recipe = _context.Recipes.Where(y => y.Id == id).FirstOrDefault();

            if (recipe == null)
            {
                return BadRequest("Recept az adott azonosítóval nem létezik");
            }

            recipe.IsValidated = true;
            _context.SaveChanges();

            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}


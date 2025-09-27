using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurmeseRecipeController : ControllerBase
    {
        [HttpGet("Ingredients")]
        public IActionResult GetRecipes()
        {
            var result = GetData();
            return Ok(result.Recipes);
        }

        private RecipesResponseModel GetData()
        {
            string fileName = "BurmeseRecipes.json";
            string json = System.IO.File.ReadAllText(fileName);
            var result = JsonConvert.DeserializeObject<RecipesResponseModel>(json)!;
            return (result);
        }

    }
}

public class RecipesResponseModel
{
    public Recipes[] Recipes { get; set; }
}

public class Recipes
{
    public string Guid { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string CookingInstructions { get; set; }
    public string UserType { get; set; }
}


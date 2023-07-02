using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.ServiceLibrary.Domains;
using RecipeBook.ServiceLibrary.Entities;
using RecipeBook.ServiceLibrary.Repositories;

namespace RecipeBook.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]



    public class RecipeController : ControllerBase
    {

        [HttpGet("{recipeId}")] // /recipe?{recipeId=1}
        public IActionResult GetOnce([FromRoute] Guid recipeId)
        {
            return Ok(recipeId);
        }


        [HttpGet] // /recipes/?pagesSize=10&pageNumber=1
        public IActionResult GetList([FromQuery] int pagesSize, [FromQuery] int pageNumber)
        {
            return Ok(pagesSize + " " + pageNumber);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RecipeEntity recipe)
        {
            return Ok(recipe);
        }

        [HttpPut]
        public IActionResult Put([FromBody] RecipeEntity recipe)
        {
            return Ok(recipe);
        }

        [HttpDelete("{recipeId}")]
        public IActionResult Delete([FromRoute] Guid recipeId)
        {
            return Ok(recipeId);
        }
    }
}

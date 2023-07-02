using RecipeBook.ServiceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace RecipeBook.ServiceLibrary.Repositories
{
    public interface IRecipeRepository
    {
        Task<int> InsertAsync(RecipeEntity entity);
    }

    public class RecipeRepository : IRecipeRepository
    {
        public async Task<int> InsertAsync(RecipeEntity entity)
        {
            using (var connection = new SqlConnection("Data Source=localhost,1431;Initial Catalog=RecipeBook;User Id=sa;Password=Str0ngP@$$w0rd;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=False;"))
            {
                connection.Open();
                var recipeId = Guid .NewGuid();
                var rowsAffected = await connection.ExecuteAsync(@"
                    INSERT INTO [dbo].[Recipes]
                        ([Id]
                        ,[Title]
                        ,[Description]
                        ,[Logo]
                        ,[CreatedDate])
                    VALUES
                        (@Id
                        ,@Title
                        ,@Description
                        ,@Logo
                        ,@CreatedDate)",
                    new
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        Logo = entity.Logo,
                        CreatedDate = entity.CreatedDate,
                        Ingredients = new List<IngredientEntity>()
                        {
                            new IngredientEntity()
                            {
                                RecipeId = recipeId,
                                OrdinalPosition = 0,
                                Unit = "lbs",
                                Ingredient = "Chicken"
                            }
                        },
                        Instructions = new List<InstructionEntity>()
                        {
                            new InstructionEntity()
                            {
                                RecipeId = recipeId,
                                OrdinalPosition = 0,
                                Instruction = "Cook it"
                            }
                        }
                    });
                return rowsAffected;
            }
        }
    }
}

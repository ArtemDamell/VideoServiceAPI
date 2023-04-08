using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VideoService.Models.Models;
using VideoService.Services.Interfaces;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="entity">The category to be added.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> Add(Category entity)
        {
            var sql = "INSERT INTO Category (Name) Values (@Name);";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var affectedRow = await connection.ExecuteAsync(sql, entity);

                return affectedRow;
            }
        }

        /// <summary>
        /// Deletes a category from the database.
        /// </summary>
        /// <param name="id">The id of the category to delete.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Category WHERE Id = @Id;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var affectedRow = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRow;
            }
        }

        /// <summary>
        /// Retrieves a Category from the database by its Id.
        /// </summary>
        /// <param name="id">The Id of the Category to retrieve.</param>
        /// <returns>The Category with the specified Id.</returns>
        public async Task<Category> Get(int id)
        {
            var sql = "SELECT * FROM Category WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var result = await connection.QueryAsync<Category>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Retrieves all categories from the database.
        /// </summary>
        /// <returns>A collection of categories.</returns>
        public async Task<IEnumerable<Category>> GetAll()
        {
            var sql = "SELECT * FROM Category;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var result = await connection.QueryAsync<Category>(sql);

                return result;
            }
        }

        /// <summary>
        /// Updates a Category entity in the database.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> Update(Category entity)
        {
            var sql = "UPDATE Category SET Name = @Name WHERE Id = @Id;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var affectedRow = await connection.ExecuteAsync(sql, entity);

                return affectedRow;
            }
        }
    }
}

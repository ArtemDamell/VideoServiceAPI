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
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;
        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Adds a new video to the database.
        /// </summary>
        /// <param name="entity">The video to be added.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> Add(VideoModel entity)
        {
            var sql = "INSERT INTO Video (Name, Path, CategoryId, Status, IsCorrect) Values (@Name, @Path, @CategoryId, @Status, @IsCorrect);";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var affectedRow = await connection.ExecuteAsync(sql, entity);

                return affectedRow;
            }
        }

        /// <summary>
        /// Deletes a video from the database.
        /// </summary>
        /// <param name="id">The id of the video to delete.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Video WHERE Id = @Id;";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var affectedRow = await connection.ExecuteAsync(sql, new { Id = id });

                return affectedRow;
            }
        }

        /// <summary>
        /// Retrieves a VideoModel from the database based on the given Id.
        /// </summary>
        /// <param name="id">The Id of the VideoModel to retrieve.</param>
        /// <returns>The VideoModel with the given Id.</returns>
        public async Task<VideoModel> Get(int id)
        {
            var sql = "SELECT * FROM Video WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var result = await connection.QueryAsync<VideoModel>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Retrieves all videos from the database.
        /// </summary>
        /// <returns>A collection of VideoModel objects.</returns>
        public async Task<IEnumerable<VideoModel>> GetAll()
        {
            var sql = "SELECT * FROM Video;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                await connection.OpenAsync();

                var result = await connection.QueryAsync<VideoModel>(sql);

                return result;
            }
        }

        /// <summary>
        /// Updates a Video entity in the database.
        /// </summary>
        /// <param name="entity">The Video entity to update.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> Update(VideoModel entity)
        {
            var sql = "UPDATE Video SET Name = @Name, Path = @Path, CategoryId = @CategoryId, Status = @Status, IsCorrect = @IsCorrect WHERE Id = @Id;";

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

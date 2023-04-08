using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace VideoService.Models.Models
{
    public static class GenericGetDataClass<TModel> where TModel : class
    {
        /// <summary>
        /// Gets the category data from the specified action path.
        /// </summary>
        /// <param name="actionPath">The action path.</param>
        /// <returns>The category data.</returns>
        public static async Task<TModel> GetCategoryData(string actionPath)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                TModel categories;

                var response = await client.GetAsync(actionPath);

                if (response.IsSuccessStatusCode)
                {
                    categories = await response.Content.ReadAsAsync<TModel>();
                    return categories;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Sends a PUT request to the specified action path with the edited model as the body.
        /// </summary>
        /// <param name="actionPath">The action path to send the request to.</param>
        /// <param name="editedModel">The model to send in the body of the request.</param>
        /// <returns>A boolean indicating whether the request was successful.</returns>
        public static async Task<bool> EditCategoryData(string actionPath, TModel editedModel)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsJsonAsync(actionPath, editedModel);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// This method adds a category data to the database.
        /// </summary>
        /// <param name="actionPath">The action path.</param>
        /// <param name="addedModel">The added model.</param>
        /// <returns>A boolean value indicating whether the data was successfully added.</returns>
        public static async Task<bool> AddCategoryData(string actionPath, TModel addedModel)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(actionPath, addedModel);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Deletes a category from the server using an HTTP DELETE request.
        /// </summary>
        /// <returns>
        /// Returns true if the category was successfully deleted, false otherwise.
        /// </returns>
        public static async Task<bool> DeleteCategory(string actionPath)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync(actionPath);

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }
    }
}

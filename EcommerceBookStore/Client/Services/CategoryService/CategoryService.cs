namespace EcommerceBookStore.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        // List to store categories
        public List<Category> Categories { get; set; } = new List<Category>();

        // Method to retrieve categories from the server
        public async Task GetCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");

            // If the response is not empty and contains data, update the list of categories
            if (response != null && response.Data != null)
                Categories = response.Data;
        }
    }
}

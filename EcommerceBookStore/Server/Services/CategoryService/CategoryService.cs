namespace EcommerceBookStore.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context) 
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            // Retrieve a list of categories from the database asynchronously
            var categories = await _context.Categories.ToListAsync();

            // Create a service response containing the retrieved categories
            return new ServiceResponse<List<Category>> 
            {
                Data = categories
            };
        }
    }
}

namespace EcommerceBookStore.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of featured products from the database.
        /// </summary>
        /// <returns>A service response containing a list of featured products.</returns>
        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                     .Where(p => p.Featured)
                     .Include(p => p.Variants)
                     .ToListAsync()

            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            // Create a response object
            var response = new ServiceResponse<Product>();

            // Search for the product with the given product ID
            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.id == productId);
            if (product == null) 
            {
                // If the product was not found, set success to false and an error message
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                // Set the product data as the response
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            // Create a response object for the list of products
            var response = new ServiceResponse<List<Product>>
            {
                // Fetch and include product variants
                Data = await _context.Products.Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            // Create a response object for the list of products
            var response = new ServiceResponse<List<Product>> {

                // Fetch products by matching the category URL
                Data = await _context.Products
                    .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            // Find products matching the search text
            var products = await FindProductsBySearchText(searchText);

            // Create a list to store search suggestions
            List<string> result = new List<string>();

            foreach (var product in products) 
            {
                // Check if the product title contains the search text
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                // Check if the product description contains search text
                if (product.Description != null)
                {
                    // Remove punctuation from the description
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words) 
                    {
                        // Check if the word contains the search text and hasn't been added to results
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                           && !result.Contains(word))
                        {
                            result.Add(word);
                        }

                    }
                }
            }

            // Create a response with the search suggestions
            return new ServiceResponse<List<string>> { Data = result };
        }

        /// <summary>
        /// Searches for products based on the provided search text and returns a paginated list of matching products.
        /// </summary>
        /// <param name="searchText">The text to search for within product titles and descriptions.</param>
        /// <param name="page">The page number for paginated results.</param>
        /// <returns>A service response containing a paginated list of matching products and pagination information.</returns>
        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
            var products = await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                ||
                                p.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Variants)
                                .Skip((page - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();


            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        /// <summary>
        /// Finds products that match the provided search text in their titles or descriptions.
        /// </summary>
        /// <param name="searchText">The text to search for within product titles and descriptions.</param>
        /// <returns>A list of products that match the search criteria.</returns>
        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                                ||
                                p.Description.ToLower().Contains(searchText.ToLower()))
                                .Include(p => p.Variants)
                                .ToListAsync();
        }
    }
}

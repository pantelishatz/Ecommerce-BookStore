using EcommerceBookStore.Server.Data;
using EcommerceBookStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBookStore.Server.Controllers
{
    /// <summary>
    /// Controller responsible for handling product-related API endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets a list of products.
        /// </summary>
        /// <returns>An ActionResult containing a ServiceResponse with a list of products if successful.</returns>
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();

            return Ok(result);
        }

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>An ActionResult containing a ServiceResponse with the requested product if found.</returns>

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProductAsync(productId);

            return Ok(result);
        }

        /// <summary>
        /// Gets a list of products by a specific category URL.
        /// </summary>
        /// <param name="categoryUrl">The URL of the category to filter products by.</param>
        /// <returns>An ActionResult containing a ServiceResponse with the requested products if found.</returns>

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategory(categoryUrl);

            return Ok(result);
        }

        /// <summary>
        /// Searches for products based on a given search text and optional page number.
        /// </summary>
        /// <param name="searchText">The text to search for in product titles and descriptions.</param>
        /// <param name="page">The page number for paginated results (default is 1).</param>
        /// <returns>An ActionResult containing a ServiceResponse with the matching products if found.</returns>

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page = 1)
        {
            var result = await _productService.SearchProducts(searchText, page);

            return Ok(result);
        }

        /// <summary>
        /// Retrieves search suggestions for a given search text by analyzing product titles and descriptions.
        /// </summary>
        /// <param name="searchText">The text to use for generating search suggestions.</param>
        /// <returns>An ActionResult containing a ServiceResponse with the search suggestions.</returns>

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _productService.GetProductSearchSuggestions(searchText);

            return Ok(result);
        }

        /// <summary>
        /// Retrieves a list of featured products.
        /// </summary>
        /// <returns>An ActionResult containing a ServiceResponse with the list of featured products.</returns>

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
            var result = await _productService.GetFeaturedProducts();

            return Ok(result);
        }


    }
}

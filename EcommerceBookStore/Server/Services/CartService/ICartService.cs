namespace EcommerceBookStore.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponse>>>GetCartProducts(List<CartItem> cartItems);
    }
}

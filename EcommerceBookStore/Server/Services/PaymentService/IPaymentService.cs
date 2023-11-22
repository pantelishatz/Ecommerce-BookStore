using Stripe.Checkout;

namespace EcommerceBookStore.Server.Services.PaymentService
{
    public interface IPaymentService
    {
       Task<Session> CreateCheckoutSession();
    }
}

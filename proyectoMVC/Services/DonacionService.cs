using MercadoPago.Config;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;

namespace proyectoMVC.Services
{
    public class DonacionService
    {
        public IConfiguration configuration;

        public DonacionService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Donar(HttpContext httpContext,string Token)
        {
            MercadoPagoConfig.AccessToken = "TEST-6580994128065851-092711-45a77a4855e986505ad5eecd834d34a2-1103088389";

            var request = new PaymentCreateRequest
            {
                TransactionAmount = 100,
                Token = "ff8080814c11e237014c1ff593b57b4d",
                Installments = 1,
                Payer = new PaymentPayerRequest
                {
                    Type = "customer",
                    Email = "test_payer_12345@testuser.com",
                },
            };

            var client = new PaymentClient();
            Payment payment = await client.CreateAsync(request);
        }
    }
}

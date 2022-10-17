using MercadoPago.Config;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;

namespace proyectoMVC.Services
{

    public class DonarService
    {

        public IConfiguration configuration;

        public DonarService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }




        public async Task<string> CreatePreference(int montoADonar)
        {

            MercadoPagoConfig.AccessToken = "TEST-6580994128065851-092711-45a77a4855e986505ad5eecd834d34a2-1103088389";
            var paymentMethods = new PreferencePaymentMethodsRequest
            {

                ExcludedPaymentTypes = new List<PreferencePaymentTypeRequest>
    {
    new PreferencePaymentTypeRequest
    {
    Id = "ticket",
    },
    },
                Installments = 1,
            };
            var request = new PreferenceRequest
            {
                PaymentMethods = paymentMethods,
                Items = new List<PreferenceItemRequest>
    {
    new PreferenceItemRequest
    {
    Title = "Donación",
    Quantity = 1,
    CurrencyId = "ARS",
    UnitPrice = montoADonar,
    },

    },
            };

            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);
            Console.WriteLine("Preferencia: " + preference.Id);
            return preference.Id;
        }

    }

}
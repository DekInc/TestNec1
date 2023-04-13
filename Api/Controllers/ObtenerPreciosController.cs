using ClientesApiCryptos;
using CoinMarketCapCliente;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TestNec.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class ObtenerPreciosController : ControllerBase
    {
        private readonly ILogger<ObtenerPreciosController> _logger;
        private readonly string ApiKey;
        private readonly string UrlApiv1;
        private readonly string UrlApiv2;

        public ObtenerPreciosController(ILogger<ObtenerPreciosController> logger, IConfiguration config)
        {
            _logger = logger;
            ApiKey = config["ApiCrytops:ApiKey"];
            UrlApiv1 = config["ApiCrytops:UrlApiv1"];
            UrlApiv2 = config["ApiCrytops:UrlApiv2"];
        }

        [HttpGet(Name = "GetObtenerPrecios")]
        public RetValue<IEnumerable<MonedaView>> Get(string? apiKey)
        {
            try
            {
                apiKey = string.IsNullOrEmpty(apiKey) ? ApiKey : apiKey;

                IClienteCryptos conexionApiExtCypto =
                    ClienteApiCryptoFactory.Crear(ClienteApiCryptoFactory.TipoClienteApiCrypto.CoinMarketCap,
                    apiKey,
                    UrlApiv1,
                    UrlApiv2);

                IEnumerable<Moneda> monedas = conexionApiExtCypto.ObtenerMoneda(new List<string>() 
                    { "BTC", "ETH", "BNB", "USDT", "ADA" }, "USD");
                IEnumerable<MonedaView> monedasView1 = (
                    from moneda in monedas
                    orderby moneda.Name
                    select new MonedaView
                    {
                        Id = moneda.Id,
                        Name = moneda.Name,
                        Symbol = moneda.Symbol,
                        Price = moneda.Price,
                        ConvertCurrency = moneda.ConvertCurrency
                    }
                    );

                return new RetValue<IEnumerable<MonedaView>>
                {
                    Value = monedasView1
                };
            }
            catch (Exception e1)
            {
                return new RetValue<IEnumerable<MonedaView>>
                {
                    ErrorMessage = e1.Message
                };
            }
        }
    }
}
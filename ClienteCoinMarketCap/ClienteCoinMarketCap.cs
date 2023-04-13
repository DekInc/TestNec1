using ClientesApiCryptos;
using Models;
using RestSharp.Portable;

namespace CoinMarketCapCliente
{
    public class ClienteCoinMarketCap : IClienteCryptos
    {
        private string LlaveApi;
        private string UrlApiv1;
        private string UrlApiv2;
        private const string ListarApi = "listings/latest";
        private const string ListarUnoApi = "quotes/latest";

        public ClienteCoinMarketCap(string llaveApi, string urlApiv1, string urlApiv2)
        {
            LlaveApi = llaveApi;
            UrlApiv1 = urlApiv1;
            UrlApiv2 = urlApiv2;
        }

        public IEnumerable<Moneda> ObtenerMonedas()
        {
            return ObtenerMonedas(-1, string.Empty);
        }

        public List<Moneda> ObtenerMonedas(int limite, string MonedaAMos)
        {
            var urlParas = new Dictionary<string, string>
            {
                {"start", "1"}
            };

            if (limite > 0)
                urlParas.Add("limit", limite.ToString());
            else
                urlParas.Add("limit", "100");

            var client = ObtenerClientWeb(UrlApiv1, ListarApi, ref MonedaAMos, urlParas);

            var result = client.MakeRequest(Method.GET, MonedaAMos, false, false, new List<string>());
            return result;
        }

        public Moneda ObtenerMoneda(string simbolo)
        {
            return ObtenerMoneda(new List<string> { simbolo }, simbolo).First();
        }

        public Moneda ObtenerMoneda(string simbolo, string monedaAMos)
        {
            return ObtenerMoneda(new List<string> { simbolo }, monedaAMos).First();
        }

        public IEnumerable<Moneda> ObtenerMoneda(IEnumerable<string> simbolos, string monedaAMos)
        {
            var urlParas = new Dictionary<string, string>
            {
                {"symbol", string.Join(",", simbolos.Select(item => item.ToLower()))}
            };

            var client = ObtenerClientWeb(UrlApiv2, ListarUnoApi, ref monedaAMos, urlParas);
            var result = client.MakeRequest(Method.GET, monedaAMos, true, true, simbolos);

            return result;
        }

        private ClienteWebApi ObtenerClientWeb(string baseUrl, string urlPart, ref string monedaAMos, Dictionary<string, string> urlParas)
        {
            if (string.IsNullOrEmpty(monedaAMos))
                monedaAMos = "USD";

            urlParas.Add("convert", monedaAMos);

            UriBuilder uri = new UriBuilder(baseUrl + urlPart);
            var client = new ClienteWebApi(uri, urlParas, LlaveApi);
            return client;
        }
    }
}
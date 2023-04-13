using CoinMarketCapCliente;
using Models;

namespace ClientesApiCryptos
{
    public class ClienteBinance : IClienteCryptos
    {
        public ClienteBinance(string llaveApi, string urlApiv1, string urlApiv2)
        {

        }
        Moneda IClienteCryptos.ObtenerMoneda(string simbolo)
        {
            throw new NotImplementedException();
        }

        Moneda IClienteCryptos.ObtenerMoneda(string simbolo, string monedaAMos)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Moneda> IClienteCryptos.ObtenerMoneda(IEnumerable<string> simbolos, string monedaAMos)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Moneda> IClienteCryptos.ObtenerMonedas()
        {
            throw new NotImplementedException();
        }

        List<Moneda> IClienteCryptos.ObtenerMonedas(int limite, string MonedaAMos)
        {
            throw new NotImplementedException();
        }
    }
}

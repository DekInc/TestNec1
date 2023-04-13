using CoinMarketCapCliente;
using Models;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCapCliente
{
    public interface IClienteCryptos
    {
        IEnumerable<Moneda> ObtenerMonedas();

        List<Moneda> ObtenerMonedas(int limite, string MonedaAMos);

        Moneda ObtenerMoneda(string simbolo);

        Moneda ObtenerMoneda(string simbolo, string monedaAMos);

        IEnumerable<Moneda> ObtenerMoneda(IEnumerable<string> simbolos, string monedaAMos);

        //ClienteWebApi ObtenerClientWeb(string baseUrl, string urlPart, ref string monedaAMos, Dictionary<string, string> urlParas);
    }
}

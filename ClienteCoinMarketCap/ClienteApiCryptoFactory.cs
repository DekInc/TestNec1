

using CoinMarketCapCliente;

namespace ClientesApiCryptos
{
    public static class ClienteApiCryptoFactory
    {
        public enum TipoClienteApiCrypto
        {
            Binance = 1,
            CoinMarketCap = 2
        }

        public static IClienteCryptos Crear(TipoClienteApiCrypto tipo, string llaveApi, string urlApiv1, string urlApiv2)
        {
            switch (tipo)
            {
                case TipoClienteApiCrypto.Binance:
                    return new ClienteBinance(llaveApi, urlApiv1, urlApiv2);
                case TipoClienteApiCrypto.CoinMarketCap:
                    return new ClienteCoinMarketCap(llaveApi, urlApiv1, urlApiv2);
                default:
                    return null;
            }
        }
    }
}

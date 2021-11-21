using StocksApi.Models;
using StocksApi.Interfaces;

namespace StocksApi
{
    public class StocksManager : IStocksManager
    {
        public Stock GetStock(string symbol)
        {
            return new Stock()
            {
                Name = "Microsoft"
            };
        }
    }
}
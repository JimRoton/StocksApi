using System;
using StocksApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StocksApi.Interfaces;

namespace StocksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IStocksManager _stocksManager;
        private readonly ILogger<StocksController> _logger;

        public StocksController(ILogger<StocksController> logger, IStocksManager stocksManager)
        {
            _logger = logger;
            _stocksManager = stocksManager;
        }

        [HttpGet("{symbol}")]
        public IActionResult Get(string symbol)
        {
            try
            {
                Stock stock = _stocksManager.GetStock(symbol);

                return stock != null ? Ok(stock) : NoContent();
            }
            // catch (Exceptions.YahooException ex)
            // {
            //     // log exception
            //     _logger.LogError(ex.Message, ex);

            //     // return
            //     return StatusCode(500, new {StatusCode=500, Title=ex.Message });
            // }
            catch(Exception ex)
            {
                // log exceptions
                _logger.LogError(ex.Message, ex);

                // return 
                return StatusCode(500);
            }
        }
    }
}

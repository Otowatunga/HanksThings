using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanksThings.Models;
using Tunga.Stocks;

namespace HanksThings.Controllers
{
	//[RouteArea("stocks")]
	//[RoutePrefix("chart")]
    public class ChartController : Controller
    {
		// GET: Chart
		//[Route("stochastic/{symbol}")]
		public ActionResult Price(string symbol, DateTime from, DateTime to) {
			StockRetriever.CacheFolder = Server.MapPath("~/Content/StockData");
			var history = StockRetriever.Retrieve(symbol, from, to);
			var chartData = new ChartData() {
				Title = "Closing price - " + symbol,
				Dates = history.Select(d => d.Date).Reverse(),
				Values = history.Select(d => d.Close).Reverse(),
			};
			return PartialView("Chart", chartData);
		}


		public ActionResult Stochastic(string symbol, DateTime from, DateTime to) {
			StockRetriever.CacheFolder = Server.MapPath("~/Content/StockData");
			var history = StockRetriever.Retrieve(symbol, from, to);
			var stochs = Technicals.Stochastic(history, 14, 3, history.Count);
			System.Diagnostics.Debug.Assert(history.Count == stochs.Count);
			var chartData = new ChartData() {
				Title = "Stochastic - " + symbol,
				Dates = history.Select(d => d.Date).Reverse(),
				Values = stochs.Reverse()
			};
			return PartialView("Chart", chartData);
		}
	}
}
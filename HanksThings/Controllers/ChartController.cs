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
		public ActionResult Stochastic(string symbol)
        {
			StockRetriever.CacheFolder = Server.MapPath("~/Content/StockData");
			var history = StockRetriever.Retrieve("GLUU", new DateTime(2015, 1, 1), DateTime.Now);
			var stochs = Technicals.Stochastic(history, 14, 3, history.Count);
			System.Diagnostics.Debug.Assert(history.Count == stochs.Count);
			var chartData = new ChartData() {
				Title = "Stochastic - " + symbol,
				Dates = history.Select(d => d.Date),
				Values = stochs
			};
            return PartialView("Chart", chartData);
        }
    }
}
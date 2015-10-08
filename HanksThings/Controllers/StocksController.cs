using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tunga.Stocks;

namespace HanksThings.Controllers{

	//[RouteArea("stocks")]
	//[Route("{action=Index}")] //default action 
	public class StocksController : Controller    {
		
		// GET: Index
		public ActionResult Index() {
			return View();
		}

		// GET: Details
		//[Route("details/{symbol}")]
		public ActionResult Details(string symbol) {
			StockRetriever.CacheFolder = Server.MapPath("~/Content/StockData");
			ViewBag.History = StockRetriever.Retrieve(symbol, new DateTime(2015, 1, 21), DateTime.Now);
			return View();
		}


	}
}
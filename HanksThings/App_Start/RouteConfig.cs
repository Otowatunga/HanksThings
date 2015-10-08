using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HanksThings {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapMvcAttributeRoutes();

			// default
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{symbol}",
				defaults: new { controller = "Home", action = "Index", symbol = "GLUU" }//, symbol = UrlParameter.Optional }
			);
		}
	}
}

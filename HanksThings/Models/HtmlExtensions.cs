using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HanksThings.Models {
	public static class HtmlExtensions {
		public static string ToJson(this HtmlHelper htmlHelper, object value) {
			return new JavaScriptSerializer().Serialize(value);
		}
	}
}
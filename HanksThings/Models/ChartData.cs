using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace HanksThings.Models {
	public class ChartData {

		public string Title { get; set; }
		public IEnumerable<DateTime> Dates { get; set; }
		public IEnumerable<double> Values { get; set; }
		
		public string ToMorrisChartJson() {
			var chartData = Dates.Zip(Values, (n1, n2) => new { date = n1, value = n2 });
			return new JavaScriptSerializer().Serialize(chartData);
		}

	}
}
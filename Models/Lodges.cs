using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOHotels_A4.Models
{
	public class Lodge
	{
		public string BusinessName { get; set; }
		public string Address { get; set; }
		public string Suite { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string BusinessType { get; set; }
		public string X { get; set; }
		public string Y { get; set; }
		public string Location { get; set; }

	}

	public class Lodges
	{
		///public string total { get; set; }
		public List<Lodge> Data { get; set; }

		///public string limit { get; set; }
		///public string start { get; set; }
	}
}



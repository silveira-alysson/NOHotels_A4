using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using NOHotels_A4.Models;

namespace NOHotels_A4.APIHandlerManager
{
	public class APIHandler
	{
		static string BASE_URL = "https://data.nola.gov/resource/ipcn-rszc.json";
		static string API_KEY = "1d1u7mjmrnoigwmpxjozio5cndbn01du8yavgjpihtfnpv7adx";

		HttpClient httpClient;

		/// <summary>
		///  Constructor to initialize the connection to the data source
		/// </summary>
		public APIHandler()
		{
			httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Add("api_key", API_KEY);
			httpClient.DefaultRequestHeaders.Accept.Add(
				new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}

		/// <summary>
		/// Method to receive data from API end point as a collection of objects
		/// 
		/// JsonConvert parses the JSON string into classes
		/// </summary>
		/// <returns></returns>
		/// 

		public Lodges GetLodges()
		{
			string NEW_ORLEANS_API_PATH = BASE_URL;
			string lodgesData = "";

			Lodges lodges = null;

			httpClient.BaseAddress = new Uri(NEW_ORLEANS_API_PATH);

			try
			{
				HttpResponseMessage response = httpClient.GetAsync(NEW_ORLEANS_API_PATH).GetAwaiter().GetResult();
				if (response.IsSuccessStatusCode)
				{
					lodgesData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				}

				if (!lodgesData.Equals(""))
				{
					// JsonConvert is part of the NewtonSoft.Json Nuget package


					lodges = JsonConvert.DeserializeObject<Lodges>(lodgesData);

				}
			}



			catch (Exception e)
						{
							// This is a useful place to insert a breakpoint and observe the error message
							Console.WriteLine(e.Message);
						}

						return lodges;
		}
	}
}

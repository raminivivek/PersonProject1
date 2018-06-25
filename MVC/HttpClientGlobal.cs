using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVC
{
	public static class HttpClientGlobal
	{
		public static HttpClient httpClient = new HttpClient();

		static HttpClientGlobal()
		{
			httpClient.BaseAddress = new Uri("http://localhost:64683/api/");
			httpClient.DefaultRequestHeaders.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult InduvidualSummary()
		{
			IEnumerable<Person> personlist;
			HttpResponseMessage httpClientresponse = HttpClientGlobal.httpClient.GetAsync("Person").Result;
			personlist = httpClientresponse.Content.ReadAsAsync<IEnumerable<Person>>().Result;
			return View(personlist);
		}
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(WholeClass wholeClass)
		{
			HttpResponseMessage httpClientresponse = HttpClientGlobal.httpClient.PostAsJsonAsync("Person", wholeClass).Result;
			return RedirectToAction("InduvidualSummary");
		}

		public ActionResult InduvidualDetails(int id)
		{
			WholeClass personlist;
			HttpResponseMessage httpClientresponse = HttpClientGlobal.httpClient.GetAsync("Person/" + id).Result;
			personlist = httpClientresponse.Content.ReadAsAsync<WholeClass>().Result;
			return View(personlist);
		}
		public ActionResult Edit(int id)
		{
			WholeClass personlist;
			HttpResponseMessage httpClientresponse = HttpClientGlobal.httpClient.GetAsync("Person/" + id).Result;
			personlist = httpClientresponse.Content.ReadAsAsync<WholeClass>().Result;
			return View(personlist);

		}
		[HttpPost]
		public ActionResult Edit(WholeClass wholeClass)
		{
			HttpResponseMessage httpClientresponse = HttpClientGlobal.httpClient.PutAsJsonAsync("Person/" + wholeClass.Person_IDNO, wholeClass).Result;
			return RedirectToAction("InduvidualSummary");
		}
		public ActionResult Delete(int id)
		{
			
			HttpResponseMessage httpClientresponse = HttpClientGlobal.httpClient.DeleteAsync("Person/" + id).Result;
			
			return RedirectToAction("InduvidualSummary");


		}
	}
}
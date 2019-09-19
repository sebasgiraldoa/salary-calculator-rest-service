using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalaryCalculator.Web.Helper;
using SalaryCalculator.Web.Models;

namespace SalaryCalculator.Web.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Senior .NET Developer Hands On Test";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Sebastian Giraldo.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public JsonResult GetEmployeeInformation(string data)
		{
			Employee employee = new Employee();
			List<Employee> results = new List<Employee>();
			Employee result;
			if (!string.IsNullOrEmpty(data))
			{
				result = Task.Run(async () => { return await Common.Get(int.Parse(data)); }).Result;
				results.Add(result);
			}
			else
			{
				results = Task.Run(async () => { return await Common.GetAll(); }).Result;
			}

			return Json(JsonConvert.SerializeObject(results));
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Web.Helper;
using SalaryCalculator.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

		[HttpGet]
		public async Task<IEnumerable<Employee>> GetEmployeeInformation(string data)
		{
			List<Employee> results = new List<Employee>();
			Employee result;
			if (!string.IsNullOrEmpty(data))
			{
				result = await Common.Get(int.Parse(data));
				results.Add(result);
			}
			else
			{
				results = await Common.GetAll();
			}

			return results;
		}
	}
}

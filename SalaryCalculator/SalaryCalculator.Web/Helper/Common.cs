using Newtonsoft.Json;
using SalaryCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SalaryCalculator.Web.Helper
{

	public static class Common
	{
		public const string UrlGetInternalEmployees = "https://localhost:44364/api/Employees/";

		public static async Task<List<Employee>> GetAll()
		{
			List<Employee> GetEmployeesResponse;
			var client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync(UrlGetInternalEmployees + "GetAll");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			GetEmployeesResponse = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content).ToList();
			return GetEmployeesResponse;
		}

		public static async Task<Employee> Get(int employeeId)
		{
			Employee GetEmployeesResponse;
			var client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync(UrlGetInternalEmployees + "Get/" + employeeId);
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			GetEmployeesResponse = JsonConvert.DeserializeObject<Employee>(content);
			return GetEmployeesResponse;
		}
	}
}

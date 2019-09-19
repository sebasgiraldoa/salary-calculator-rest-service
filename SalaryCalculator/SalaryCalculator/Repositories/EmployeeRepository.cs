using Newtonsoft.Json;
using SalaryCalculator.API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SalaryCalculator.API.Repositories
{
	public class EmployeeRepository: IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeApi>> GetAll()
        {
            IEnumerable<EmployeeApi> GetEmployeesResponse;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            GetEmployeesResponse = JsonConvert.DeserializeObject<IEnumerable<EmployeeApi>>(content);
            return GetEmployeesResponse;
        }       
    }
}

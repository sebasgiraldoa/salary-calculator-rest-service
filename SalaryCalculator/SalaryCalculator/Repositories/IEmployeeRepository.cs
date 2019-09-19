using SalaryCalculator.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryCalculator.API
{
	public interface IEmployeeRepository
    {
       Task<IEnumerable<EmployeeApi>> GetAll();
    }
}

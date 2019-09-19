using SalaryCalculator.API.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryCalculator.API.Core
{
	public interface IEmployeeManager
	{
		Task<IEnumerable<EmployeeDTO>> GetAll();
		Task<EmployeeDTO> Get(int employeeId);
	}
}

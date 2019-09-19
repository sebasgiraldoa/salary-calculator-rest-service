using AutoMapper;
using SalaryCalculator.API.Models;
using SalaryCalculator.API.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCalculator.API.Core
{
	public class EmployeeManager : IEmployeeManager
	{
		private const string HourlyContractType = "HourlySalaryEmployee";
		private const string MonthlyContractType = "MonthlySalaryEmployee";

		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;
		public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<EmployeeDTO>> GetAll()
		{
			return await GetEmployees();
		}
		public async Task<EmployeeDTO> Get(int employeeId)
		{
			var result = new EmployeeDTO();
			var employees = await GetEmployees();
			var employee = employees.Where(t => t.Id == employeeId).FirstOrDefault();
			if (employee != null)
				result = employee;

			return result;
		}

		private async Task<IEnumerable<EmployeeDTO>> GetEmployees()
		{
			var result = new List<EmployeeDTO>();
			var employees = await _employeeRepository.GetAll();

			foreach (var employee in employees)
			{
				if (employee.ContractTypeName == HourlyContractType)
				{
					var hourlyEmployee = _mapper.Map<EmployeeApi, HourlyEmployee>(employee);
					hourlyEmployee.CalculateSalary();
					result.Add(_mapper.Map<HourlyEmployee, EmployeeDTO>(hourlyEmployee));
				}
				else if (employee.ContractTypeName == MonthlyContractType)
				{
					var monthlyEmployee = _mapper.Map<EmployeeApi, MonthlyEmployee>(employee);
					monthlyEmployee.CalculateSalary();
					result.Add(_mapper.Map<MonthlyEmployee, EmployeeDTO>(monthlyEmployee));
				}				
			}

			return result;
		}
	}
}

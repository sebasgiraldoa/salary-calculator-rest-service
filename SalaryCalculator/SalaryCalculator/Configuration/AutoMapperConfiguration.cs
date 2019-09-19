using AutoMapper;
using SalaryCalculator.API.Models;
using SalaryCalculator.API.Models.DTO;
using System.Collections.Generic;

namespace SalaryCalculator.API.Configuration
{
	public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration()
		{
			CreateMap<EmployeeApi, HourlyEmployee>();
			CreateMap<EmployeeApi, MonthlyEmployee>();
			CreateMap<HourlyEmployee, EmployeeDTO>();
			CreateMap<MonthlyEmployee, EmployeeDTO>();
		}
	}
}

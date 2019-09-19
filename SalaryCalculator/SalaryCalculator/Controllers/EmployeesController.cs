using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.API.Core;
using SalaryCalculator.API.Models.DTO;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SalaryCalculator.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeManager _manager;

		public EmployeesController(IEmployeeManager manager)
		{
			_manager = manager;
		}

		[HttpGet]
		[Route("GetAll")]
		//[ApiExplorerSettings(IgnoreApi =true)]
		[Produces("application/json")]
		public async Task<IEnumerable<EmployeeDTO>> GetAll()
		{
			return await _manager.GetAll();
		}

		[HttpGet]
		[Route("Get/{employeeId}")]
		[Produces("application/json")]
		public async Task<EmployeeDTO> Get([FromRoute] int employeeId)
		{
			return await _manager.Get(employeeId);
		}
	}
}

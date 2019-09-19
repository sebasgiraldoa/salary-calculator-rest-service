namespace SalaryCalculator.API.Models
{
	public class HourlyEmployee : Employee
	{
		public override void CalculateSalary()
		{
			if (ContractTypeName == "HourlySalaryEmployee")
			{
				AnnualSalary = 120 * HourlySalary * 12;
			}
		}
	}
}

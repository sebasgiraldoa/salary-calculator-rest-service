namespace SalaryCalculator.API.Models
{
	public class MonthlyEmployee : Employee
	{
		public override void CalculateSalary()
		{
			if (ContractTypeName == "MonthlySalaryEmployee")
			{
				AnnualSalary = MonthlySalary * 12;
			}
		}
	}
}

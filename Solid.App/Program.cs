
//using Solid.App.OCPGood2;

//SalaryCalculator salaryCalculator = new SalaryCalculator();
//Console.WriteLine("Low Salary: " + salaryCalculator.Calculate(1000,SalaryType.Low));
//Console.WriteLine("Middle Salary: "+salaryCalculator.Calculate(1000,SalaryType.Middle));
//Console.WriteLine("High Salary: "+salaryCalculator.Calculate(1000,SalaryType.High));


//Good Method 1 interface kullandık
//Console.WriteLine("Low Salary: " + salaryCalculator.Calculate(1000, new LowSalaryCalculate()));
//Console.WriteLine("Middle Salary: " + salaryCalculator.Calculate(1000, new MiddleSalaryCalculate()));
//Console.WriteLine("High Salary: " + salaryCalculator.Calculate(1000, new HighSalaryCalculate()));



//Good Method 2 Function Delegate kullandık
//Console.WriteLine("Low Salary: " + salaryCalculator.Calculate(1000, new LowSalaryCalculate().Calculate));
//Console.WriteLine("Middle Salary: " + salaryCalculator.Calculate(1000, new MiddleSalaryCalculate().Calculate));
//Console.WriteLine("High Salary: " + salaryCalculator.Calculate(1000, new HighSalaryCalculate().Calculate));
//Console.WriteLine("Custom Salary: " + salaryCalculator.Calculate(1000, x =>
//{
//    return x * 10;
//}));

//using Solid.App.LSPGood;

//BasePhone phone = new IPhone();
//phone.Call();
//((ITakePhoto)phone).TakePhoto();


//phone = new Nokia3310(); 
//phone.Call();

using Solid.App.DIP;
using System.Threading.Channels;

var ProductService = new ProductService(new ProductRepositoryFromSqlServer());
var ProductService2 = new ProductService(new ProductRepositoryFromOracle());

ProductService.TGetAll().ForEach(x=>Console.WriteLine(x));
ProductService2.TGetAll().ForEach(x=>Console.WriteLine(x));
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.OCPGood2
{


    public class LowSalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 2;
        }

    }
    public class MiddleSalaryCalculate 
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 4;
        }

    }
    public class HighSalaryCalculate 
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 6;
        }

    }
    public class ManagerSalaryCalculate 
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 7;
        }
    }
    public class SalaryCalculator
    {
        //Action => void //parametre alır geriye dönmez
        //Predicate  //parametre alır geriye bool döner
        //Function  //herhangi parametre alır herhangi bir parametereyi döner
        public decimal Calculate(decimal salary, Func<decimal,decimal> calculateDelegate)
        {
            return calculateDelegate(salary);
        }
    }


}

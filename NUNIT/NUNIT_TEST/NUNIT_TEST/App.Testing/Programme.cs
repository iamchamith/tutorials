using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Testing
{
    class Programme
    {
        static void Main(string[] args)
        { 
            SlowTest();
            Console.Read();
            Console.WriteLine("unit test end");
        }

        static void SlowTest()
        {
            var obj = new EmployeeControllerUnitTest();
            obj.Select_Returns_EmployeeList();

        }
    }
}

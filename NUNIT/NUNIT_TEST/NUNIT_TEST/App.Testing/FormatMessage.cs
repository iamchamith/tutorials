using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Testing
{
    public class FormatMessage
    {
        public static void Error(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();
            Console.WriteLine("Press any key to continue");
            Console.Read();
        }
    }
}

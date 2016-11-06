using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace App.Sp
{
    public class Programm
    {
        static void Main(string[] args)
        {
            Console.Title = "SP Runner";
            Console.WriteLine("Init Sp executer");
            Console.WriteLine("Droping Sp \n");

            string folderPath = $@"{System.IO.Directory.GetCurrentDirectory()}\Sp\";
            string[] fileEntries = Directory.GetFiles(folderPath).Select(Path.GetFileName).ToArray();

            foreach (var item in fileEntries)
            {
                try
                {
                    string procName = item.ToLower().Replace(".sql", "").Trim();
                    DbAccess.Update(" drop proc " + procName);
                    Console.WriteLine($"proc {procName} has been removed");
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("\n=========== Execute Sp \n");
            foreach (var item in fileEntries)
            {
                try
                {
                    string sp = (System.IO.File.ReadAllText($@"{folderPath}{item}"));
                    DbAccess.Update(sp);
                    Console.WriteLine($"proc {item} has been executed");
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nEnter eny key to exit");
            Console.Read();

        }
    }
}

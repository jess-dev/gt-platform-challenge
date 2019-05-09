using Microsoft.VisualBasic.FileIO;
using PlatformChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = CSVInput.Parse(appSettings.File);
            Console.ReadLine();
        }
    }
}

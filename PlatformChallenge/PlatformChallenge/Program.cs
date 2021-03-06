﻿using Microsoft.VisualBasic.FileIO;
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
            Console.WriteLine("            ╒════════════╕                 ");
            Console.WriteLine("            │  Platform  │                 ");
            Console.WriteLine("            │    Team    │                 ");
            Console.WriteLine("            │  Challenge │                 ");
            Console.WriteLine("            ╘════════════╛                 ");
            Console.WriteLine("                                           ");
            Console.WriteLine("Please press return to start the CSV input.");
            Console.ReadLine();

            // Parse CSV - path for the file is found in appSettings.cs
            var input = CSVInput.Parse(appSettings.File);

            if (input != null)
            {
                // Post each record to Webhook site every 5 seconds - URL can be changed in appSettings.cs
                foreach (ParsedRecord record in input)
                {
                    WebHookInterface.Post(record);

                    // Wait 5 seconds before moving on to the next record
                    System.Threading.Thread.Sleep(5000);
                }
            }

        }
    }
}

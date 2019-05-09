using Microsoft.VisualBasic.FileIO;
using PlatformChallenge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformChallenge
{
    class CSVInput
    {
        public static List<ParsedRecord> Parse(string path)
        {
            // Parse the CSV and output a List<> of parsed records
            using (TextFieldParser parser = new TextFieldParser(appSettings.File))
            {
                List<ParsedRecord> recordsIn = new List<ParsedRecord>();
                bool firstLine = true;

                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    // Checking for the header row to avoid processing it
                    if (!firstLine)
                    {
                        try
                        {
                            // Build the object which we will be posting
                            ParsedRecord record = new ParsedRecord
                            {
                                date_utc = Convert.ToDateTime(fields[1]),
                                resource = fields[2],
                                event_type = fields[3],
                                data = new RecordData
                                {
                                    id = Convert.ToInt32(fields[0])
                                }
                            };

                            // Build a collection of objects to post
                            recordsIn.Add(record);
                        }
                        catch (FormatException)
                        {
                            // Could also log this somewhere, send an email etc
                            Console.WriteLine("Line: {0} - Is not formatted correctly", parser.LineNumber);
                            throw;
                        }
                        
                    }
                    else
                    {
                        firstLine = false;
                    }
                }

                return recordsIn;

            }
        }
    }
}

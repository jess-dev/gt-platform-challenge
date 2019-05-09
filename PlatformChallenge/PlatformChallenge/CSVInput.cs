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

                    // Skip header row
                    if (!firstLine)
                    {
                        // Build the object which we will be posting
                        ParsedRecord record = new ParsedRecord
                        {
                            date_utc = fields[1],
                            resource = fields[2],
                            event_type = fields[3],
                            data = new RecordData
                            {
                                id = fields[0]
                            }
                        };

                        recordsIn.Add(record);

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

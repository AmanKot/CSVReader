using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileReader
{
    public static class DataFetcher
    {
        public static Dictionary<string, int> numberKeyValuePairs = new Dictionary<string, int>();
        
        public static void GetData (string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found at " + filePath);
            }

            using (var reader = new StreamReader(filePath))
            {
                var headerLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

                    if (values.Length >= 2)
                    {
                        numberKeyValuePairs.Add(values[0], int.Parse(values[1]));
                    } 
                }
            }
        }
    }
}

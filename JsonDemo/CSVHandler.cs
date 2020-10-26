using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace CSVIO
{
    public class CSVHandler
    {
        public static void WorkWithCSV()
        {
            string importFilePath = @"C:\Users\saiku\source\repos\JsonDemo\Utility\SampleData.csv";
            string exportFilePath = @"C:\Users\saiku\source\repos\JsonDemo\Utility\ExportData.csv";
            using (var reader = new StreamReader(importFilePath)) 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Reading Data ......\n");

                foreach(AddressData address in records)
                {
                    Console.WriteLine(" " + address.FirstName);
                    Console.WriteLine(" " + address.LastName);
                    Console.WriteLine(" " + address.Address);
                    Console.WriteLine(" " + address.City);
                    Console.WriteLine(" " + address.State);
                    Console.WriteLine(" " + address.Code+"\n");

                }
                Console.WriteLine("Readed Data successFully");

                Console.WriteLine("Writing Data:");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
                Console.WriteLine("Writed Data successfully:");
            }


            



        }
    }
}

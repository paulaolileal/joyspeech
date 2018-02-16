using CsvHelper;
using JoySpeech.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoySpeech.Components {
    public class ReportGenerator {
        public static void Save( Record data) {
            bool header = false;
            if(!File.Exists( Directory.GetCurrentDirectory() + @"/Report.csv" )) {
                header = true;
            }
            using(var writer = new StreamWriter( Directory.GetCurrentDirectory() + @"/Report.csv", append: true )) {
                CsvWriter csvWriter = new CsvWriter( writer);
                if(header == true) {
                    csvWriter.WriteHeader<Record>();
                }
                csvWriter.WriteRecord( data );
                csvWriter.NextRecord();
            }
        }
    }
}

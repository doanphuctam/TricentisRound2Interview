using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jaq {
    public class CsvHandler {
        public IEnumerable<Box> Load(string filepath) {
            using var parser = new TextFieldParser(filepath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            _ = parser.ReadFields();
            while (!parser.EndOfData) {
                var fields = parser.ReadFields();
                var left = int.Parse(fields[0]);
                var top = int.Parse(fields[1]);
                var width = int.Parse(fields[2]);
                var height = int.Parse(fields[3]);
                var rank = float.Parse(fields[4]);
                yield return new Box(left, top, width, height, rank);
            }
        }

        public void Save(string filepath, IEnumerable<Box> boxes) {
            var csv = new StringBuilder();
            foreach (var box in boxes)
                csv.AppendLine($"{box.Left},{box.Top},{box.Right - box.Left},{box.Bottom - box.Top},{box.Rank}");
            File.WriteAllText(filepath, csv.ToString());
        }
    }
}

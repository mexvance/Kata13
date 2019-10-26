using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kata13.Services
{
    public class LineCounter
    {
        public int ReturnTotalLinesOfCode(string fileContents)
        {
            fileContents = RemoveWhiteSpace(fileContents);
            fileContents = RemoveMultilineComments(fileContents);
            fileContents = RemoveSingleLineComments(fileContents);
            return GetNumberOfLines(fileContents);
        }
        public string RemoveWhiteSpace(string fileContents)
        {
            fileContents = Regex.Replace(fileContents.Trim(), @"[^\S\r\n]+", "");
            return fileContents; 
        }

        public string RemoveSingleLineComments(string fileContents)
        {
            var fileContentLines = GetFileLineList(fileContents)
                .Where(line => line.StartsWith("//") == false);
            return CreateStringFromList(fileContentLines);
        }
        private string CreateStringFromList(IEnumerable<string> fileContentLines)
        {
            string fileContentReturn = "";

            foreach (var line in fileContentLines)
            {
                var lineContent = line + "\n";
                if (lineContent.StartsWith("\n") != true)
                    fileContentReturn += lineContent;
            }
            return fileContentReturn;
        }
        public int GetNumberOfLines(string fileContents)
        {
            var list = GetFileLineList(fileContents);
            return list.Count;
        }
        public string RemoveMultilineComments(string fileContents)
        {
            var textWithRemovedMultilines = Regex.Replace(fileContents, @"\/\*(\*(?!\/)|[^*])*\*\/", "");
            var fileContentLines = GetFileLineList(textWithRemovedMultilines);
            
            return CreateStringFromList(fileContentLines);
        }
        private List<string> GetFileLineList(string fileContents)
        {
            var fileContentArray = fileContents.Split("\n");
            List<string> fileContentLines = new List<string>();
            foreach (var line in fileContentArray)
            {
                if (line.Length > 0)
                    fileContentLines.Add(line);
            }
            return fileContentLines;
        }
    }
}

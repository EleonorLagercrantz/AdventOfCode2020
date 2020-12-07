using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class Day6
    {
        public string TaskOne()
        {
            var text = File.ReadAllText("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day6_input.txt");
            var lines = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var groups = new List<string>(lines);
            var totalSumOfYes = 0;
            foreach (string answers in groups)
            {
                string cleaned = answers.Replace("\n", "").Replace("\r", "");
                var count = cleaned.Distinct().Count();

                totalSumOfYes = totalSumOfYes + count; 
            }
            
            
            return totalSumOfYes.ToString();
        }

        public string TaskTwo()
        {
            var text = File.ReadAllText("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day6_input.txt");
            var lines = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var groups = new List<string>(lines);
            var totalSumOfYes = 0;
            char[] alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
            foreach (string answers in groups)
            {
                var parts = answers.Split(' ', '\n', '\r').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                foreach(var letter in alphabet)
                {
                    var resultList = parts.Where(q => letter.ToString().ToCharArray().All(p => q.Contains(p))).ToArray();
                    if(resultList.Length == parts.Count)
                    {
                        totalSumOfYes++;
                    }
                }
            }

            return totalSumOfYes.ToString();
        }
    }
}

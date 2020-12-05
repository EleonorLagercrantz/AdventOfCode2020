using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class Day5
    {
        public string TaskOne()
        {
            var seatIds = getListOfSeatIds();
            return seatIds.Max(x => x).ToString();
        }

        public string TaskTwo()
        {
            var seatIds = getListOfSeatIds().OrderBy(x => x).ToList();
            var max = seatIds.Max(x => x);
            var min = seatIds.Min(x => x);

            var mySeat = Enumerable.Range(min, max + 1)
                 .Except(seatIds)
                 .Min();

            return mySeat.ToString();
        }

        public List<int> getListOfSeatIds()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day5_input.txt");
            var stringList = new List<string>(input);
            var seatIdList = new List<int>();

            foreach (var pass in stringList)
            {
                string rows = pass.Substring(0, 7);
                string columns = pass.Substring(pass.Length - 3);

                var rowArray = Enumerable.Range(0, 128).ToArray();

                foreach (var c in rows)
                { 
                    if (c == 'F')
                    {
                        rowArray = rowArray.Take(rowArray.Length / 2).ToArray();
                    }
                    else if (c == 'B')
                    {
                        rowArray = rowArray.Skip(rowArray.Length / 2).ToArray();
                    }
                }

                var columnArray = Enumerable.Range(0, 8).ToArray();

                foreach (var c in columns)
                {
                    if (c == 'L')
                    {
                        columnArray = columnArray.Take(columnArray.Length / 2).ToArray();
                    }
                    else if (c == 'R')
                    {
                        columnArray = columnArray.Skip(columnArray.Length / 2).ToArray();
                    }
                }

                int seatId = rowArray[0] * 8 + columnArray[0];
                seatIdList.Add(seatId);

            }

            return seatIdList;
        }
    }
}

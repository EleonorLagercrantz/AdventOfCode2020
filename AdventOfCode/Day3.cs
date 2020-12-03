using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class Day3
    {
        public string TaskOne()
        {
            
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day3_input.txt");
            var stringList = new List<string>(input);

            return getNumberOfTrees(stringList, 1, 3).ToString();
        }

        public string TaskTwo()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day3_input.txt");
            var stringList = new List<string>(input);

            long first = getNumberOfTrees(stringList, 1, 1);
            long second = getNumberOfTrees(stringList, 1, 3);
            long third = getNumberOfTrees(stringList, 1, 5);
            long fourth = getNumberOfTrees(stringList, 1, 7);
            long fifth = getNumberOfTrees(stringList, 2, 1);

            var result = first * second * third * fourth * fifth;

            return result.ToString();
        }

        public int getNumberOfTrees(List<string> input, int down, int right)
        {
            int treeCount = 0;
            var row = 0;
            var offsetPos = 0;

            while (row < input.Count - down)
            {
                var rowLength = input[row].Length;
                var rowOffsetDif = rowLength - offsetPos;
                if (rowOffsetDif <= right)
                {
                    offsetPos = 0 - rowOffsetDif;
                }

                char c = input[row + down][offsetPos + right];
                if (c == '#')
                {
                    treeCount++;
                }

                offsetPos = offsetPos + right;
                row = row + down;
            }

            return treeCount;
        }
    }
}

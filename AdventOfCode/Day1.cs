using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day1
    {
        public string TaskOne()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day1_Input.txt");
            var stringList = new List<string>(input);

            List<int> intList = stringList.Select(s => int.Parse(s)).ToList();

            for (int i = 0; i < intList.Count - 1; i++)
            {
                for (int j = i + 1; j < intList.Count; j++)
                {
                    if(intList[i] + intList[j] == 2020)
                    {
                        return (intList[i] * intList[j]).ToString();
                    }
                }
            }

            return "No result";
        }

        public string TaskTwo()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day1_Input.txt");
            var stringList = new List<string>(input);

            List<int> intList = stringList.Select(s => int.Parse(s)).ToList();

            for (int i = 0; i < intList.Count - 1; i++)
            {
                for (int j = i + 1; j < intList.Count; j++)
                {
                    for (int k = j + 1; k < intList.Count; k++)
                    {
                        if (intList[i] + intList[j] + intList[k] == 2020)
                        {
                            return (intList[i] * intList[j] * intList[k]).ToString();
                        }
                    }
                }
            }


            return "No result";
        }
    }
}

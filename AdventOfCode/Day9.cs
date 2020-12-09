using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class Day9
    {
        public string TaskOne()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day9_input.txt");
            var numberList = input.Select(x => Int64.Parse(x)).ToList();
            long invalidNumber = 0;
            var preamble = 25;

            for(int i = preamble; i < numberList.Count; i++)
            {
                var index = i - preamble;
                var newList = numberList.GetRange(index, preamble);
                if(!isNumberValid(numberList[i], newList))
                {
                    invalidNumber = numberList[i];
                    break;
                }
            }

            return invalidNumber.ToString();
        }

        public string TaskTwo()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day9_input.txt");
            var numberList = input.Select(x => Int64.Parse(x)).ToList();
            long invalidNumber = 0;
            var preamble = 25;

            for (int i = preamble; i < numberList.Count; i++)
            {
                var index = i - preamble;
                var newList = numberList.GetRange(index, preamble);
                if (!isNumberValid(numberList[i], newList))
                {
                    invalidNumber = numberList[i];
                    break;
                }
            }

            return getWeakness(invalidNumber, numberList).ToString();
        }

        public bool isNumberValid(long num, List<long> numbers)
        {
            foreach(var n in numbers)
            {
                for(int i = 0; i < numbers.Count; i++)
                {
                    var result = n + numbers[i];
                    if(numbers[i] != n && result == num)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public long getWeakness(long num, List<long> numbers)
        {
            var newRange = new List<long>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != num)
                {
                    var number = numbers[i];
                    for (int j = i + 1; j < numbers.Count; j++)
                    {
                        if (numbers[j] != num)
                        {
                            number = number + numbers[j];
                            if (number == num)
                            {
                                newRange = numbers.Skip(i).Take(j - i + 1).ToList();
                                goto end;
                            }
                        }
                    }
                }
            }
            end:

            var min = newRange.Min(x => x);
            var max = newRange.Max(x => x);

            return min + max;
        }
    }
}

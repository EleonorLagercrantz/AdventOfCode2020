using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class Day8
    {

        public int globalAccumulator = 0;

        public string TaskOne()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day8_input.txt");
            var keyValuePairs = new List<KeyValuePair<string, int>>();
            foreach(var i in input)
            {
                var firstSpaceIndex = i.IndexOf(" ");
                var key = i.Substring(0, firstSpaceIndex);
                var value = int.Parse(i.Substring(firstSpaceIndex + 1).Trim());

                keyValuePairs.Add(new KeyValuePair<string, int>(key, value));
            }

            var accumulator = 0;
            var usedCode = new List<int>();
            var currentCode = 0;

            while(!usedCode.Contains(currentCode))
            {

                if(keyValuePairs[currentCode].Key == "jmp")
                {
                    usedCode.Add(currentCode);
                    currentCode = currentCode + keyValuePairs[currentCode].Value;
                }
                else if(keyValuePairs[currentCode].Key == "acc")
                {
                    usedCode.Add(currentCode);
                    accumulator = accumulator + keyValuePairs[currentCode].Value;
                    currentCode++;
                }
                else
                {
                    usedCode.Add(currentCode);
                    currentCode++;
                }
            }

            return accumulator.ToString();
        }

        public string TaskTwo()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day8_input.txt");
            var keyValuePairs = new List<KeyValuePair<string, int>>();
            foreach (var i in input)
            {
                var firstSpaceIndex = i.IndexOf(" ");
                var key = i.Substring(0, firstSpaceIndex);
                var value = int.Parse(i.Substring(firstSpaceIndex + 1).Trim());

                keyValuePairs.Add(new KeyValuePair<string, int>(key, value));
            }

            var foundValue = false;

            var indexOfJmp = Enumerable.Range(0, keyValuePairs.Count)
             .Where(i => keyValuePairs[i].Key == "jmp")
             .ToList();

            var indexOfNop = Enumerable.Range(0, keyValuePairs.Count)
             .Where(i => keyValuePairs[i].Key == "nop")
             .ToList();

            for (int i = 0; i < indexOfJmp.Count; i++) 
            {
                var index = indexOfJmp[i];
                var newKeyValuePairList = keyValuePairs.ToList();
                var newKeyValuePair = new KeyValuePair<string, int>("nop", newKeyValuePairList[index].Value);
                newKeyValuePairList[index] = newKeyValuePair;

                if (runCodeSequence(newKeyValuePairList))
                {
                    foundValue = true;
                    break;
                }
            } 

            if(!foundValue)
            {
                for (int i = 0; i < indexOfNop.Count; i++)
                {
                    var index = indexOfNop[i];
                    var newKeyValuePairList = keyValuePairs.ToList();
                    var newKeyValuePair = new KeyValuePair<string, int>("jmp", newKeyValuePairList[index].Value);
                    newKeyValuePairList[index] = newKeyValuePair;

                    if (runCodeSequence(newKeyValuePairList))
                    {
                        break;
                    }
                }
            }

            return globalAccumulator.ToString();
        }

        public bool runCodeSequence(List<KeyValuePair<string, int>> keyValuePairs)
        {
            globalAccumulator = 0;
            var usedCode = new List<int>();
            var currentCode = 0;

            while (currentCode < keyValuePairs.Count)
            {
                if (!usedCode.Contains(currentCode))
                {

                    if (keyValuePairs[currentCode].Key == "jmp")
                    {
                        usedCode.Add(currentCode);
                        currentCode = currentCode + keyValuePairs[currentCode].Value;
                    }
                    else if (keyValuePairs[currentCode].Key == "acc")
                    {
                        usedCode.Add(currentCode);
                        globalAccumulator = globalAccumulator + keyValuePairs[currentCode].Value;
                        currentCode++;
                    }
                    else
                    {
                        usedCode.Add(currentCode);
                        currentCode++;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}

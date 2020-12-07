using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class Day7
    {
        public int totalBags = 0;

        public string TaskOne()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day7_input.txt");
            var stringList = new List<string>(input);
            var dic = new Dictionary<string, string[]>();
            var search = "shiny gold";
            var count = 0;

            foreach (var s in stringList)
            {
                var key = s.Substring(0, s.IndexOf("bags")).Trim();
                var value = Array.ConvertAll(s.Substring(s.IndexOf("contain") + "contain".Length).Trim('.').Split(','), p => p.Trim());


                dic.Add(key, value);
            }

            foreach(var k in dic)
            {
                if (k.Value.Any(x => x != "no other bags"))
                {
                    if(findString(search, k.Key, dic))
                    {
                        count++;
                    }
                }
            }

            return count.ToString();
        }

        public bool findString(string search, string key, Dictionary<string, string[]> dic)
        {
            var values = dic.GetValueOrDefault(key);
            foreach(var v in values)
            {
                var firstSpaceIndex = v.IndexOf(" ");
                var bag = v.Substring(firstSpaceIndex + 1).Trim();
                bag = bag.Substring(0, bag.LastIndexOf(" ", bag.Length));

                if (bag == search)
                {
                    return true;
                }

                else if(bag != "other")
                {
                    if (findString(search, bag, dic))
                        return true;
                }
            }

            return false;
        }

        public string TaskTwo()
        {
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day7_input.txt");
            var stringList = new List<string>(input);
            var dic = new Dictionary<string, string[]>();
            var search = "shiny gold";

            foreach (var s in stringList)
            {
                var key = s.Substring(0, s.IndexOf("bags")).Trim();
                var value = Array.ConvertAll(s.Substring(s.IndexOf("contain") + "contain".Length).Trim('.').Split(','), p => p.Trim());


                dic.Add(key, value);
            }

            findTotalNumberOfBags(search, dic, 1);

            return totalBags.ToString();
        }

        public void findTotalNumberOfBags(string key, Dictionary<string, string[]> dic, int qty)
        {
            var values = dic.GetValueOrDefault(key);
            foreach (var v in values)
            {
                var firstSpaceIndex = v.IndexOf(" ");
                var count = v.Substring(0, firstSpaceIndex);
                var bag = v.Substring(firstSpaceIndex + 1).Trim();
                bag = bag.Substring(0, bag.LastIndexOf(" ", bag.Length));

                if (bag != "other")
                {
                    var newQty = qty * int.Parse(count);
                    totalBags = totalBags + newQty;
                    findTotalNumberOfBags(bag, dic, newQty);
                }
            }
        }
    }
}

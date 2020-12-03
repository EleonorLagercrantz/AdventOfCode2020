using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    class Day2
    {
        public string TaskOne()
        {
            int correctCount = 0;
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day2_Input.txt");
            var stringList = new List<string>(input);

            foreach(string passwordInput in stringList)
            {
                string[] passwordSplit = passwordInput.Split(' ');

                int index = passwordSplit[0].IndexOf('-');
                int minNumber = int.Parse(passwordSplit[0].Substring(0, index));
                int maxNumber = int.Parse(passwordSplit[0].Substring(index + 1));
                char character = passwordSplit[1].ToCharArray()[0];
                string password = passwordSplit[2];

                int count = password.Count(f => f == character);
                if (count >= minNumber && count <= maxNumber)
                {
                    correctCount++;
                }
            }


            return correctCount.ToString();
        }

        public string TaskTwo()
        {
            int correctCount = 0;
            var input = File.ReadAllLines("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day2_Input.txt");
            var stringList = new List<string>(input);

            foreach (string passwordInput in stringList)
            {
                string[] passwordSplit = passwordInput.Split(' ');

                int index = passwordSplit[0].IndexOf('-');
                int firstPosition = int.Parse(passwordSplit[0].Substring(0, index)) - 1;
                int secondPosition = int.Parse(passwordSplit[0].Substring(index + 1)) -1;
                char character = passwordSplit[1].ToCharArray()[0];
                string password = passwordSplit[2];

                if (!(password[firstPosition] == character && password[secondPosition] == character) &&
                    (password[firstPosition] == character || password[secondPosition] == character))
                {
                    correctCount++;
                }
            }

            return correctCount.ToString();
        }
    }
}

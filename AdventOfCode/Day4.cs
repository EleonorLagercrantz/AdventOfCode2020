using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day4
    {
        public string TaskOne()
        {
            var validCount = 0;
            var credList = convertInputToCredList();
            foreach (var cred in credList)
            {
                if (!(string.IsNullOrEmpty(cred.byr) || string.IsNullOrEmpty(cred.iyr) || string.IsNullOrEmpty(cred.eyr) ||
                    string.IsNullOrEmpty(cred.hgt) || string.IsNullOrEmpty(cred.hcl) || string.IsNullOrEmpty(cred.ecl) ||
                    string.IsNullOrEmpty(cred.pid)))
                {
                    validCount++;
                }
            }

            return validCount.ToString();
        }

        public string TaskTwo()
        {
            var validCount = 0;
            var credList = convertInputToCredList();
            foreach(var cred in credList)
            {
                if (validateCredentials(cred))
                {
                    validCount++;
                }
            }
            return validCount.ToString();
        }

        public bool validateCredentials(Credentials cred)
        {
            if( validateByr(cred.byr) && validateIyr(cred.iyr) && validateEyr(cred.eyr) && validateHgt(cred.hgt) && validateHcl(cred.hcl)
                && validateEcl(cred.ecl) && validatePid(cred.pid)) 
            {
                return true;
            }
            return false;
        }

        public bool validateByr(string byr)
        {
            if(byr == null || byr.Length > 4 || int.Parse(byr) < 1920 || int.Parse(byr) > 2002)
            {
                return false;
            }
            return true;
        }

        public bool validateIyr(string iyr)
        {
            if(iyr == null || iyr.Length > 4 || int.Parse(iyr) < 2010 || int.Parse(iyr) > 2020)
            {
                return false;
            }
            return true;
        }

        public bool validateEyr(string eyr)
        {
            if (eyr == null || eyr.Length > 4 || int.Parse(eyr) < 2020 || int.Parse(eyr) > 2030)
            {
                return false;
            }
            return true;
        }

        public bool validateHgt(string hgt)
        {
            if (hgt != null)
            {
                var measurement = hgt.Substring(hgt.Length - 2);
                var value = hgt.Substring(0, hgt.Length - 2);
                if (measurement == "cm")
                {
                    if (int.Parse(value) < 150 || int.Parse(value) > 193)
                    {
                        return false;
                    }
                    return true;

                }
                else if (measurement == "in")
                {
                    if (int.Parse(value) < 59 || int.Parse(value) > 76)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool validateHcl(string hcl)
        {
            var regexColorCode = new Regex("^#[a-fA-F0-9]{6}$");

            if (hcl == null || !regexColorCode.IsMatch(hcl.Trim()))
            {
                return false;
            }
            return true;
        }

        public bool validateEcl(string ecl)
        {
            var validColors = new List<string>();
            validColors.Add("amb");
            validColors.Add("blu");
            validColors.Add("brn");
            validColors.Add("gry");
            validColors.Add("grn");
            validColors.Add("hzl");
            validColors.Add("oth");

            if (ecl == null || validColors.Where(x => x.Contains(ecl)).FirstOrDefault() == null)
            {
                return false;
            }
            return true;
        }

        public bool validatePid(string pid)
        {
            if(pid == null || pid.Length != 9 || !pid.All(char.IsDigit))
            {
                return false;
            }
            return true;
        }



        public List<Credentials> convertInputToCredList()
        {
            var text = File.ReadAllText("C:/Users/elagerkr/Documents/Advent Of Code 2020/Day4_input.txt");
            var lines = text.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var credentials = new List<Credentials>();
            foreach (string item in lines)
            {
                var dic = new Dictionary<string, string>();
                var parts = item.Split(' ', '\n', '\r').Where(x => !string.IsNullOrWhiteSpace(x));
                foreach (var part in parts)
                {
                    var deli = part.Split(':');
                    dic.Add(deli[0], deli[1]);
                }

                var cred = new Credentials();

                foreach (var keyValue in dic)
                {
                    switch (keyValue.Key)
                    {
                        case "byr":
                            cred.byr = keyValue.Value;
                            break;
                        case "iyr":
                            cred.iyr = keyValue.Value;
                            break;
                        case "eyr":
                            cred.eyr = keyValue.Value;
                            break;
                        case "hgt":
                            cred.hgt = keyValue.Value;
                            break;
                        case "hcl":
                            cred.hcl = keyValue.Value;
                            break;
                        case "ecl":
                            cred.ecl = keyValue.Value;
                            break;
                        case "pid":
                            cred.pid = keyValue.Value;
                            break;
                        case "cid":
                            cred.cid = keyValue.Value;
                            break;

                    }
                }

                credentials.Add(cred);
            }
            return credentials;
        }
    }

    public class Credentials
    {
        public string byr { get; set; }

        public string iyr { get; set; }

        public string eyr { get; set; }

        public string hgt { get; set; }

        public string hcl { get; set; }

        public string ecl { get; set; }

        public string pid { get; set; }

        public string cid { get; set; }

        public Credentials () { }
    }
}

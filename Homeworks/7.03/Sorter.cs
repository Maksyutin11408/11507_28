using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DotaIterator
{
    internal class Sorter
    {
        public Sorter() { }
        public string[][] StartSort(string stat, string difficulty)
        {
            List<string[]> list = new List<string[]>();
            string[] character;
            using (var iterator = new Iterator("C:\\Dota\\Dota.txt"))
            {
                while (iterator.HasNext())
                {
                    string line = iterator.Next();
                    if ((character = SortByAttributes(stat, difficulty, line)) != null)
                    {
                        list.Add(character);
                    }
                }
            }
            return list.ToArray();
        }
        public string[]? SortByAttributes(string stat, string difficulty, string line)
        {
            string[] characterStats = line.Split('|');
            if (characterStats[2] == stat || stat == "any")
            {
                if(characterStats[1] == difficulty || difficulty == "any")
                {
                    return characterStats;
                }
            }
            return null;
        }
        public string[][]? SortByStats(string stat, string[][] Characters)
        {
            int StatNumber = 0;
            switch (stat)
            {
                case "hp":
                    StatNumber = 3;
                    break;
                case "mana":
                    StatNumber = 4;
                    break;
                case "str":
                    StatNumber = 5;
                    break;
                case "dex":
                    StatNumber = 6;
                    break;
                case "int":
                    StatNumber = 7;
                    break;
            }
            if (StatNumber == 0)
            {
                return null;
            }
            Array.Sort(Characters, (a, b) => b[StatNumber].CompareTo(a[StatNumber]));
            return Characters;
        }
    }
}

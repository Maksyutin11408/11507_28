using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sorter sort = new Sorter();
            Console.WriteLine("Чтобы отсортировать введите через пробел сложность от 1 до 3, главную характеристику str, dex или int");
            Console.WriteLine("и характеристику по которой желаете отсортировать в порядке убывания hp, mana, dex, str или int");
            string? command = Console.ReadLine();
            Console.WriteLine("Name                 Difficulty    Main stat      HP       Mana      Str     Dex     Int");
            if (command != null)
            {
                string[] commandDetails = command.Split(" ");
                string[][] result = sort.SortByStats(commandDetails[2], sort.StartSort(commandDetails[1], commandDetails[0]));
                foreach (string[] character in result)
                {
                    Console.WriteLine(character[0].PadRight(22) + character[1].PadRight(14) + character[2].PadRight(15) +
                        character[3].PadRight(9) + character[4].PadRight(10) + character[5].PadRight(8) + character[6].PadRight(8) + character[7]);
                }
            }
        }
    }
}

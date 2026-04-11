using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Container<string> container1 = new Container<string>();
            Container<int> container2 = new Container<int>();
            container2.Add(1);
            container2.Add(1000);
            container2.Add(-1000);
            container2.Add(16);
            container1.Add("abas");
            container1.Add("a");
            container1.Add("das");
            container1.Add("aleadx");

            Console.WriteLine(container2.GetMax());

            Console.WriteLine(container1.GetMax());

            MyButton button = new MyButton();
            button.Click += button.Message;
            button.OnClick();
            button.OnClick();
            Thread.Sleep(10000);
            button.OnClick();
        }
    }
}

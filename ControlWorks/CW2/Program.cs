using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User user = new User(12, "John");
            Cloner cloner = new Cloner();
            object newobj = cloner.CLone(user);
            foreach (PropertyInfo property in newobj.GetType().GetProperties())
            {
                Console.WriteLine(property.GetValue(newobj));
            }
        }
    }
}

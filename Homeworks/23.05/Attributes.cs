using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionClass.Homework.Utils.Validators.Abstraction
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MyRequired : Attribute
    {
        public MyRequired()
        {
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MyRange : Attribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public MyRange(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}

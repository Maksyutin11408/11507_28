using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    public class Cloner
    {
        public object CLone(object obj)
        {
            Type type = obj.GetType();
            object newObject = Activator.CreateInstance(type);
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead)
                {
                    property.SetValue(newObject, property.GetValue(obj, null));
                }
            }
            return newObject;
        }
    }
    /*/
    мой пример объекта
    /*/
    public class User
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public User()
        {
            ID = 1;
            Name = "default";
        }
        public User(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

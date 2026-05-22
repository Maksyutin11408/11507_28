using ReflectionClass.Homework.Utils.Validators.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ReflectionClass.Homework.Utils.Validators.Implementation;

public class UniversalValidator : IValidator
{
    public bool Validate(object? obj, out List<string> errors)
    {
        errors = new List<string>();
        if (obj == null)
        {
            errors.Add("object is null");
        }
        Type objType = obj.GetType();

        var objProperties = objType.GetProperties();

        foreach (var property in objProperties)
        {
            object? value = property.GetValue(obj);
            if (property.IsDefined(typeof(MyRequired), true))
            {
                if (value == null)
                {
                    errors.Add($"{property.Name} is required ");
                }
            }
            var rangeAttribute = property.GetCustomAttribute<MyRange>();
            if (rangeAttribute != null)
            {
                if (value is int intValue && (intValue > rangeAttribute.Max || intValue < rangeAttribute.Min))
                {
                    errors.Add("value is out of range");
                }
            }
        }
        return errors.Count == 0;
    }
}
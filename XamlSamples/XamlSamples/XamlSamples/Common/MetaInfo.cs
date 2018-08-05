using System;
using System.Collections.Generic;
using XamlSamples.Views;
using XamlSamples.ViewModels;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace XamlSamples.Common
{
    public static class MetaInfo
    {


        public static string GetPropDescription(Type type, string prop)
        {
            PropertyInfo propInfo = type.GetProperty(prop);

            System.ComponentModel.DescriptionAttribute attrib =
                (System.ComponentModel.DescriptionAttribute)propInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false).FirstOrDefault();
            return attrib.Description;
        }

        public static  string[] GetClassDescription(Type type)
        {
            string[] infos = null;
            foreach (var cAttrib in type.CustomAttributes)
            {
                foreach (var constructorArg in cAttrib.ConstructorArguments)
                {
                    var val = constructorArg.Value;
                    if (val is string)
                    {
                        string strn = (string)val;
                        //One ConstructorArg is the relative path to the class file
                        if (!strn.Contains("\\"))
                        {
                            //The class description is tilde separated class Title and Description
                            if (strn.Contains("~"))
                            {
                                infos = strn.Split(new char[] { '~' });
                                break;
                            }
                        }
                    }
                }
            }
            return infos;
        }

        public static string GetStaticProperty(Type type, string prop)
        {
            PropertyInfo propertyInfo = type
                .GetProperty(prop, BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo == null)
                return string.Empty;
            // Use the PropertyInfo to retrieve the value from the type by not passing in an instance
            return (string)propertyInfo.GetValue(null);
        }

        public static List<Type> GetAllTypesInNamespace(string @namespace, Type type)
        {
            //Ref (Re:Refection): https://stackoverflow.com/questions/2742276/how-do-i-check-if-a-type-is-a-subtype-or-the-type-of-an-object
            //Ref (Re:IsSubclassOf): https://stackoverflow.com/questions/2742276/how-do-i-check-if-a-type-is-a-subtype-or-the-type-of-an-object
            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass
                && t.Namespace == @namespace
                && t.IsSubclassOf(type))
                .ToList().OrderBy(cp => cp.Name);

            //types.ForEach(t => System.Diagnostics.Debug.WriteLine(t.Name));

            return new List<Type>(types);
        }
    }
}

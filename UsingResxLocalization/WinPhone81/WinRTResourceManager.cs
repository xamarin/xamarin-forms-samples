using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using Windows.ApplicationModel.Resources;

namespace UsingResxLocalization.WinPhone81
{
    public class WinRTResourceManager : ResourceManager
    {
        ResourceLoader resourceLoader;

        public WinRTResourceManager(string baseName, Assembly assembly)
            : base(baseName, assembly)
        {
            resourceLoader = ResourceLoader.GetForViewIndependentUse(baseName);
        }

        public static void InjectIntoResxApplicationResourceClass(Type type)
        {
            type
                .GetRuntimeFields()
                .First(f => f.FieldType == typeof(ResourceManager))
                .SetValue(null, new WinRTResourceManager(type.FullName, type.GetTypeInfo().Assembly));
        }

        public override string GetString(string name, CultureInfo culture)
        {
            string result = resourceLoader.GetString(name);
            return result;
            //return resourceLoader.GetString(name);
        }
    }
}

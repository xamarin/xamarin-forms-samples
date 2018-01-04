using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace DataBindingDemos
{
    public class NamedColor : IEquatable<NamedColor>, IComparable<NamedColor>
    {
        // Instance members
        private NamedColor()
        {
        }

        public string Name { private set; get; }

        public string FriendlyName { private set; get; }

        public Color Color { private set; get; }

        public string RgbDisplay { private set; get; }

        public bool Equals(NamedColor other)
        {
            return Name.Equals(other.Name);
        }

        public int CompareTo(NamedColor other)
        {
            return Name.CompareTo(other.Name);
        }

        // Static members
        static NamedColor()
        {
            List<NamedColor> all = new List<NamedColor>();
            StringBuilder stringBuilder = new StringBuilder();

            // Loop through the public static fields of the Color structure.
            foreach (FieldInfo fieldInfo in typeof(Color).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic &&
                    fieldInfo.IsStatic &&
                    fieldInfo.FieldType == typeof(Color))
                {
                    // Convert the name to a friendly name.
                    string name = fieldInfo.Name;
                    stringBuilder.Clear();
                    int index = 0;

                    foreach (char ch in name)
                    {
                        if (index != 0 && Char.IsUpper(ch))
                        {
                            stringBuilder.Append(' ');
                        }
                        stringBuilder.Append(ch);
                        index++;
                    }

                    // Instantiate a NamedColor object.
                    Color color = (Color)fieldInfo.GetValue(null);

                    NamedColor namedColor = new NamedColor
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = color,
                        RgbDisplay = String.Format("{0:X2}-{1:X2}-{2:X2}",
                                                   (int)(255 * color.R),
                                                   (int)(255 * color.G),
                                                   (int)(255 * color.B))
                    };

                    // Add it to the collection.
                    all.Add(namedColor);
                }
            }
            all.TrimExcess();
            all.Sort();
            All = all;
        }

        public static IList<NamedColor> All { private set; get; }

        public static NamedColor Find(string name)
        {
            return ((List<NamedColor>)All).Find(nc => nc.Name == name);
        }

        public static string GetNearestColorName(Color color)
        {
            double shortestDistance = 1000;
            NamedColor closestColor = null;

            foreach (NamedColor namedColor in NamedColor.All)
            {
                double distance = Math.Sqrt(Math.Pow(color.R - namedColor.Color.R, 2) +
                                            Math.Pow(color.G - namedColor.Color.G, 2) +
                                            Math.Pow(color.B - namedColor.Color.B, 2));

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestColor = namedColor;
                }
            }
            return closestColor.Name;
        }
    }
}

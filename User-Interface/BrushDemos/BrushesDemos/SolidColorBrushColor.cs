using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace BrushesDemos
{
    public class SolidColorBrushColor : IEquatable<SolidColorBrushColor>, IComparable<SolidColorBrushColor>
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public string Hex { get; private set; }

        public static IList<SolidColorBrushColor> All { get; private set; }

        public bool Equals(SolidColorBrushColor other)
        {
            return Name.Equals(other.Name);
        }

        public int CompareTo(SolidColorBrushColor other)
        {
            return Name.CompareTo(other.Name);
        }

        static SolidColorBrushColor()
        {
            List<SolidColorBrushColor> all = new List<SolidColorBrushColor>();

            // Loop through the public static fields of the Brush class
            foreach (FieldInfo fieldInfo in typeof(Brush).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic &&
                    fieldInfo.IsStatic &&
                    fieldInfo.FieldType == typeof(SolidColorBrush))
                {
                    // Instantiate a SolidColorBrushColor object
                    SolidColorBrush brush = (SolidColorBrush)fieldInfo.GetValue(null);

                    SolidColorBrushColor brushColor = new SolidColorBrushColor
                    {
                        Name = fieldInfo.Name,
                        Color = brush.Color,
                        Hex = brush.Color.ToHex()
                    };

                    all.Add(brushColor);
                }
            }

            all.TrimExcess();
            all.Sort();
            All = all;
        }
    }
}

using System;
using System.Collections.Generic;
using XamlSamples.Views;
using XamlSamples.ViewModels;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace XamlSamples
{
    public class PageDataViewModel
    {
        static int mode = 3;

        public Type Type { private set; get; }
        public string Title { private set; get; }
        public string Description { private set; get; }

        public PageDataViewModel(Type type) //, string title, string description)
        {
            Type = type;
            //Originally, metainfo was parameters in the call to this class
            //Title = title;
            //Description = description

            //Three ways to get it implicitly from the class
            if (mode == 1)
            {
                //[1] Get from dummy properties' Descriptions
                Title = GetPropDescription(type, "PTitle");
                Description = GetPropDescription(type, "PInfo");
            }
            else if (mode == 2)
            {
                //[2] Use static properties
                Title = GetStaticProperty(type, "StatPTitle");
                Description = GetStaticProperty(type, "StatPInfo");
            }
            else
            {
                //[3] Get it from the Class Description Custom attribute
                string[] infos = GetClassDescription(type);
                if (infos != null)
                {
                    Title = infos[0];
                    Description = infos[1];
                }
            }
        }

        private string GetPropDescription(Type type, string prop)
        {
            PropertyInfo propInfo = type.GetProperty(prop);

            System.ComponentModel.DescriptionAttribute attrib =
                (System.ComponentModel.DescriptionAttribute)propInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false).FirstOrDefault();
            return attrib.Description;
        }

        private string[] GetClassDescription(Type type)
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

        private string GetStaticProperty(Type type, string prop)
        {
            PropertyInfo propertyInfo = type
                .GetProperty(prop, BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo == null)
                return string.Empty;
            // Use the PropertyInfo to retrieve the value from the type by not passing in an instance
            return (string)propertyInfo.GetValue(null);
        }

        static PageDataViewModel()
        {
            All = new List<PageDataViewModel>
            {
                // Part 1. Getting Started with XAML
                new PageDataViewModel(typeof(HelloXamlPage)),

                new PageDataViewModel(typeof(XamlPlusCodePage)),

                // Part 2. Essential XAML Syntax
                new PageDataViewModel(typeof(GridDemoPage)),

                new PageDataViewModel(typeof(AbsoluteDemoPage)),

                // Part 3. XAML Markup Extensions
                new PageDataViewModel(typeof(SharedResourcesPage)),

                new PageDataViewModel(typeof(StaticConstantsPage)),

                new PageDataViewModel(typeof(RelativeLayoutPage)),

                // Part 4. Data Binding Basics
                new PageDataViewModel(typeof(SliderBindingsPage)),

                new PageDataViewModel(typeof(SliderTransformsPage)),

                new PageDataViewModel(typeof(ListViewDemoPage)),

                // Part 5. From Data Bindings to MVVM
                new PageDataViewModel(typeof(OneShotDateTimePage)),

                new PageDataViewModel(typeof(ClockPage)),

                new PageDataViewModel(typeof(HslColorScrollPage)),

                new PageDataViewModel(typeof(KeypadPage))
            };
        }

        public static IList<PageDataViewModel> All { private set; get; }
    }
}

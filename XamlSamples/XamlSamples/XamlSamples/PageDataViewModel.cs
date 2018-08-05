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

            //Three ways to get it implicitly from the class
            if (mode == 1)
            {
                //[1] Get from dummy properties' Descriptions
                Title = Common.MetaInfo.GetPropDescription(type, "PTitle");
                Description = Common.MetaInfo.GetPropDescription(type, "PInfo");
            }
            else if (mode == 2)
            {
                //[2] Use static properties
                Title = Common.MetaInfo.GetStaticProperty(type, "StatPTitle");
                Description = Common.MetaInfo.GetStaticProperty(type, "StatPInfo");
            }
            else
            {
                //[3] Get it from the Class Description Custom attribute
                string[] infos = Common.MetaInfo.GetClassDescription(type);
                if (infos != null)
                {
                    Title = infos[0];
                    Description = infos[1];
                }
            }
        }

        static PageDataViewModel()
        {
            List<Type> types = Common.MetaInfo.GetAllTypesInNamespace(
                "XamlSamples.Views", typeof(Xamarin.Forms.ContentPage));

            All = new List<PageDataViewModel>();
            foreach (Type t in types)
            {
                All.Add(new PageDataViewModel(t));
            }
        }

        public static IList<PageDataViewModel> All { private set; get; }
    }
}

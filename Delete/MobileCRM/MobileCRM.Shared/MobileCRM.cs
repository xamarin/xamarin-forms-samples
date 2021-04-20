using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Resources;
using System.IO;
using System.Collections.Generic;
using MobileCRM.Models;
using Xamarin.Forms;
using System.Linq;
using MobileCRM.Services;

namespace MobileCRM
{
    /// <summary>
    /// MobileCRM placeholder.
    /// </summary>
    public static class MobileCRMApp
    {
        static Assembly _reflectionAssembly;
        internal static IDictionary<Type,Type> TypeMap;
        internal static readonly MethodInfo GetDependency;

        static MobileCRMApp()
        {
            TypeMap = new Dictionary<Type, Type> 
            {
                {typeof(Lead), typeof(LeadRepository)},
                {typeof(Contact), typeof(ContactRepository)},
                {typeof(Opportunity), typeof(OpportunityRepository)},
                {typeof(Account), typeof(AccountRepository)},
            };

            GetDependency = typeof(DependencyService)
                .GetRuntimeMethods()
                .Single((method)=>
                    method.Name.Equals("Get"));
        }

        public static void Init(Assembly assembly)
        {
            System.Threading.Interlocked.CompareExchange(ref _reflectionAssembly, assembly, null);
        }

        public static Stream LoadResource(String name)
        {
            return _reflectionAssembly.GetManifestResourceStream(name);
        }
    }
}
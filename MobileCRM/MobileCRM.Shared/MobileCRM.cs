using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Resources;
using System.IO;
using System.Collections.Generic;
using MobileCRM.Models;

namespace MobileCRM
{
    /// <summary>
    /// MobileCRM placeholder.
    /// </summary>
    public static class App
    {
        static Assembly _reflectionAssembly;

        public static void Init(Assembly assembly)
        {
            System.Threading.Interlocked.CompareExchange(ref _reflectionAssembly, assembly, null);
        }

        public static Stream LoadResource(String name)
        {
            return _reflectionAssembly.GetManifestResourceStream(name);
        }

        public static List<POI> PointsOfInterest { get; set; }
    }
}
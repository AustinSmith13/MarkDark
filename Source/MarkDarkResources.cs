using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace MarkDark
{
    public static class MarkDarkResources<T>
    {
        static readonly Dictionary<string, T> resources = new Dictionary<string, T>();

        public static T Load(string arg)
        {
            return default(T);
        }
    }

    public static class MDResources
    {
        static readonly Dictionary<string, string> resources = new Dictionary<string, string>();

        public static string Load(string arg)
        {
            return null;
        }

        public static void Save(string path)
        {

        }
    }
}

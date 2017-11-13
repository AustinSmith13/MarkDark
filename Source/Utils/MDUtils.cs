using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MarkDark
{
    internal static class MDUtils
    {
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            objects.Sort();
            return objects;
        }

        public static UnityEngine.Color ParseColor(string value)
        {
            if (value.StartsWith("#"))
            {
                int argb = Convert.ToInt32(value.Substring(1), 16);
                float a, r, g, b;
                r = (float)((argb & 0xFF000000) >> 24) / 255.0f;
                g = (float)((argb & 0x00FF0000) >> 16) / 255.0f;
                b = (float)((argb & 0x0000FF00) >> 8) / 255.0f;
                a = (float)((argb & 0x000000FF) >> 0) / 255.0f;
                return
                    new UnityEngine.Color(r, g, b, a);

            }

            switch (value)
            {
                case "red":
                    return UnityEngine.Color.red;
                case "black":
                    return UnityEngine.Color.black;
                case "blue":
                    return UnityEngine.Color.blue;
                case "clear":
                    return UnityEngine.Color.clear;
                case "cyan":
                    return UnityEngine.Color.cyan;
                case "gray":
                    return UnityEngine.Color.gray;
                case "green":
                    return UnityEngine.Color.green;
                case "grey":
                    return UnityEngine.Color.grey;
                case "magenta":
                    return UnityEngine.Color.magenta;
                case "white":
                    return UnityEngine.Color.white;
                case "yellow":
                    return UnityEngine.Color.yellow;
            }

            // Unable to parse color
            return UnityEngine.Color.white;
        }

        public static UnityEngine.TextAnchor ParseTextAlignment(string alignment)
        { 
            switch(alignment)
            {
                case "lowercenter":
                    return UnityEngine.TextAnchor.LowerCenter;
                case "lowerleft":
                    return UnityEngine.TextAnchor.LowerLeft;
                case "lowerright":
                    return UnityEngine.TextAnchor.LowerRight;
                case "middlecenter":
                    return UnityEngine.TextAnchor.MiddleCenter;
                case "middleleft":
                    return UnityEngine.TextAnchor.MiddleLeft;
                case "middleright":
                    return UnityEngine.TextAnchor.MiddleRight;
                case "uppercenter":
                    return UnityEngine.TextAnchor.UpperCenter;
                case "upperleft":
                    return UnityEngine.TextAnchor.UpperLeft;
                case "upperright":
                    return UnityEngine.TextAnchor.UpperRight;
                default:
                    return UnityEngine.TextAnchor.UpperRight;
            }
        }

        public static UnityEngine.FontStyle ParseFontStyle(string style)
        {
            switch(style)
            {
                case "bold":
                    return UnityEngine.FontStyle.Bold;
                case "boldanditalic":
                    return UnityEngine.FontStyle.BoldAndItalic;
                case "italic":
                    return UnityEngine.FontStyle.Italic;
                case "normal":
                    return UnityEngine.FontStyle.Normal;
                default:
                    return UnityEngine.FontStyle.Normal;
            }
        }
    }
}

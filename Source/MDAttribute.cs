using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MarkDark
{
    /// <summary>
    /// [DEPRECATED]
    /// </summary>
    public interface IMDDefaultAttribute
    {
        void Apply(GameObject gameObject, string[] args);
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MDAttribute : IComparable<MDAttribute>
    {
        public abstract void Apply(object value, string[] args);

        public int CompareTo(MDAttribute other)
        {
            return 0;
        }
    }
}

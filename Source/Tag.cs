using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MarkDark
{
    public sealed class Tag
    { 
        public readonly string name;
        private readonly System.Type template;

        public Tag(string name, System.Type template)
        {
            this.name = name;
            this.template = template;
        }

        public Element CreateElement()
        {
            return Activator.CreateInstance(template, name) as Element;
        }
    }
}

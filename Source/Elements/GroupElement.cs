using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkDark.Elements
{
    public class GroupElement : Element
    {
        public GroupElement(string tag) : base(tag)
        {
            gameObject.name = "<Group>";
        }
    }
}

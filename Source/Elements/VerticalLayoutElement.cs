using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MarkDark.Elements
{
    public class VerticalLayoutElement : Element
    {
        public VerticalLayoutElement(string tag) : base(tag)
        {
            gameObject.name = "<VerticalLayout>";
            gameObject.AddComponent<VerticalLayoutGroup>();
        }
    }
}

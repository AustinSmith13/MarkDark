using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

namespace MarkDark.Elements
{
    public class PanelElement : Element
    {
        public PanelElement(string tag) : base(tag)
        {
            gameObject.name = "<Panel>";
            gameObject.AddComponent<CanvasRenderer>();
            gameObject.AddComponent<UnityEngine.UI.Extensions.RoundedRectangle>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MarkDark.Elements
{
    public class ButtonElement : Element
    {
        public ButtonElement(string tag) : base(tag)
        {
            gameObject.name = "<Button>";
            gameObject.AddComponent<CanvasRenderer>();
            gameObject.AddComponent<UnityEngine.UI.Extensions.RoundedRectangle>();
            gameObject.AddComponent<Button>();
        }
    }
}

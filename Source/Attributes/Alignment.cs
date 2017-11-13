using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(UnityEngine.UI.Text))]
    public class Alignment : MDAttribute
    {
        public override void Apply(object obj, string[] args)
        {
            Text text = obj as Text;
            switch(args[0])
            {
                case "middle-left":
                    text.alignment = UnityEngine.TextAnchor.MiddleLeft;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MarkDark.Elements
{
    public class TextElement : Element
    {
        private readonly Text text;

        public TextElement(string tag) : base(tag)
        {
            gameObject.name = "<Text>";
            gameObject.AddComponent<CanvasRenderer>();
            (text = gameObject.AddComponent<Text>()).color = Color.black;      // This should be set automaticly
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        }

        public override void Init()
        {
            base.Init();
            text.text = InnerText;
        }
    }
}

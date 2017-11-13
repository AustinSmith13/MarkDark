using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace MarkDark.Elements
{
    public class ToggleElement : Element
    {
        private readonly Toggle toggleField;

        public ToggleElement(string tag) : base(tag)
        {
            gameObject.name = "<Toggle>";
            gameObject.AddComponent<CanvasRenderer>();
            var roundedRectangle = gameObject.AddComponent<RoundedRectangle>();
            var toggle = gameObject.AddComponent<Toggle>();
            var checkmark = new GameObject("<Toggle:Tick>");
            checkmark.AddComponent<CanvasRenderer>();
            var image = checkmark.AddComponent<RoundedRectangle>();
            image.corners = Vector4.one * 30;
            image.rectTransform.sizeDelta = new Vector2(30, 30);
            image.color = Color.black;

            toggle.graphic = image;
            checkmark.transform.SetParent(gameObject.transform);
            roundedRectangle.corners = new Vector4(10, 10, 10, 10);
        }

        public override void Init()
        {
            base.Init();
        }
    }
}
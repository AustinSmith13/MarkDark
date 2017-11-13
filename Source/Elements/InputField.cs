using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MarkDark.Elements
{
    public class InputFieldElement : Element
    {
        private readonly InputField inputField;

        public InputFieldElement(string tag) : base(tag)
        {
            Text placeHolder = null;
            gameObject.name = "<InputField>";
            gameObject.AddComponent<CanvasRenderer>();
            gameObject.AddComponent<UnityEngine.UI.Extensions.RoundedRectangle>();
            inputField = gameObject.AddComponent<InputField>();

            var textGameObject = new GameObject("<InputFieldText>");
            {
                textGameObject.AddComponent<CanvasRenderer>();
                var rectTransform = textGameObject.AddComponent<RectTransform>();
                var text = textGameObject.AddComponent<Text>();
                rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                rectTransform.anchorMax = new UnityEngine.Vector2(1, 1);
                rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                text.color = Color.black;
                text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                textGameObject.transform.SetParent(gameObject.transform);
                inputField.textComponent = text;
            }

            var placeHolderGameObject = new GameObject("<InputFieldPlaceholder>");
            {
                var rectTransform = placeHolderGameObject.AddComponent<RectTransform>();
                rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                rectTransform.anchorMax = new UnityEngine.Vector2(1, 1);
                rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                placeHolderGameObject.AddComponent<CanvasRenderer>();
                placeHolder = placeHolderGameObject.AddComponent<Text>();
                placeHolder.color = Color.gray;
                placeHolder.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                placeHolderGameObject.transform.SetParent(gameObject.transform);
            }

            inputField.placeholder = placeHolder;
        }

        public override void Init()
        {
            base.Init();
        }
    }
}

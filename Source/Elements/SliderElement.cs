using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace MarkDark.Elements
{
    public class SliderElement : Element
    {
        private GameObject background;
        private GameObject fillArea;
        private GameObject handleSlideArea;
        private GameObject fill;
        private GameObject handle;

        public SliderElement(string tag) : base(tag)
        {
            gameObject.name = "<Slider>";
            this.rectTransform.sizeDelta = new Vector3(100, 20);

            background = new GameObject("<Slider:Background>");
            {
                background.transform.SetParent(gameObject.transform);
                var rectTransform = background.AddComponent<RectTransform>();
                background.AddComponent<CanvasRenderer>();
                var rect = background.AddComponent<RoundedRectangle>();
                rectTransform.anchorMin = new UnityEngine.Vector2(0, 0.25f);
                rectTransform.anchorMax = new UnityEngine.Vector2(1, 0.75f);
                rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                rectTransform.sizeDelta = new Vector2(0, 0);
                rect.corners = new Vector4(10, 10, 10, 10);
                rect.sides = 4;
                rect.color = Color.gray;
                background.AddComponent<Outline>().effectDistance = new Vector2(1, 1);
            }

            fillArea = new GameObject("<Slider:FillArea>");
            {
                fillArea.transform.SetParent(gameObject.transform);
                var rectTransform = fillArea.AddComponent<RectTransform>();
                rectTransform.anchorMin = new UnityEngine.Vector2(0, 0.25f);
                rectTransform.anchorMax = new UnityEngine.Vector2(1, 0.75f);
                rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                rectTransform.sizeDelta = new Vector2(0, 0);
            }

            fill = new GameObject("<Slider:FillArea:fill>");
            {
                fill.transform.SetParent(fillArea.transform);
                var rectTransform = fill.AddComponent<RectTransform>();
                rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                rectTransform.anchorMax = new UnityEngine.Vector2(0, 1);
                rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                rectTransform.sizeDelta = new Vector2(10, 0);
                fill.AddComponent<CanvasRenderer>();
                var rect = fill.AddComponent<RoundedRectangle>();
                rect.corners = new Vector4(10, 10, 10, 10);
                rect.sides = 4;
                rect.color = MDUtils.ParseColor("#99FF99FF");
                fill.AddComponent<Outline>().effectDistance = new Vector2(1, 1);
            }

            handleSlideArea = new GameObject("<Slider:HandleSlideArea>");
            {
                handleSlideArea.transform.SetParent(gameObject.transform);
                var rectTransform = handleSlideArea.AddComponent<RectTransform>();
                rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                rectTransform.anchorMax = new UnityEngine.Vector2(1, 1);
                rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                rectTransform.sizeDelta = new Vector2(0, 0);
            }

            handle = new GameObject("<Slider:HandleSlideArea:Handle");
            {
                handle.transform.SetParent(handleSlideArea.transform);
                var rectTransform = handle.AddComponent<RectTransform>();
                rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                rectTransform.anchorMax = new UnityEngine.Vector2(0, 1);
                rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                rectTransform.sizeDelta = new Vector2(20, 0);
                handle.AddComponent<CanvasRenderer>();
                var rect = handle.AddComponent<RoundedRectangle>();
                rect.corners = new Vector4(20, 20, 20, 20);
                rect.sides = 4;
                rect.color = Color.white;
                handle.AddComponent<Outline>().effectDistance = new Vector2(1,1);
            }

            var slider = gameObject.AddComponent<Slider>();
            slider.targetGraphic = handle.GetComponent<RoundedRectangle>();
            slider.fillRect = fill.GetComponent<RectTransform>();
            slider.handleRect = handle.GetComponent<RectTransform>();
        }

        public override void Init()
        {
            base.Init();
        }
    }
}

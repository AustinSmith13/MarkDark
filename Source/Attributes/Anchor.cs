using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(RectTransform))]
    public class Anchor : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            var rectTransform = ((RectTransform)value);

            switch(args[0])
            {
                case "middle-center":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0.5f, 0.5f);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0.5f, 0.5f);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "middle-left":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 0.5f);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0, 0.5f);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "middle-right":
                    rectTransform.anchorMin = new UnityEngine.Vector2(1, 0.5f);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 0.5f);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "top-center":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0.5f, 1);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0.5f, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "bottom-center":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0.5f, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0.5f, 0f);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "top-left":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 1);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "top-right":
                    rectTransform.anchorMin = new UnityEngine.Vector2(1, 1);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "bottom-left":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0, 0);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "bottom-right":
                    rectTransform.anchorMin = new UnityEngine.Vector2(1, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 0);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "middle-stretch":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 0.5f);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 0.5f);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "bottom-stretch":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 0);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "top-stretch":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 1);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "stretch-left":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "stretch-center":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0.5f, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(0.5f, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "stretch-right":
                    rectTransform.anchorMin = new UnityEngine.Vector2(1, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
                case "stretch-stretch":
                    rectTransform.anchorMin = new UnityEngine.Vector2(0, 0);
                    rectTransform.anchorMax = new UnityEngine.Vector2(1, 1);
                    rectTransform.pivot = new UnityEngine.Vector2(0.5f, 0.5f);
                    break;
            }
        }
    }
}
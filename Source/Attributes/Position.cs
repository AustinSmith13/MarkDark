using UnityEngine;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(RectTransform))]
    public class Position : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (args.Length != 2)
                return;

            float x, y;
            float.TryParse(args[0], out x);
            float.TryParse(args[1], out y);

            ((RectTransform)value).anchoredPosition = new Vector2(x, y);
            
        }
    }
}

using UnityEngine;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(RectTransform))]
    public class AnchorMin : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (args != null)
            {
                if (args.Length != 2)
                    return;

                float x, y;
                float.TryParse(args[0], out x);
                float.TryParse(args[1], out y);

                ((RectTransform)value).anchorMin = 
                    new UnityEngine.Vector2(x, y);
            }
        }
    }
}

using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(UnityEngine.UI.Extensions.RoundedRectangle))]
    public class Outline : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            RoundedRectangle image = 
                (RoundedRectangle)value;        // cast value to Image
            if (args == null) return;           // stop if no arguments to parse
            if (args[0].ToLower() == "true")    // Add a unity outline component
                image.gameObject.AddComponent<UnityEngine.UI.Outline>();
            else if (args.Length == 2)
            {
                float x, y;
                float.TryParse(args[0], out x); // Try and get x and y from args
                float.TryParse(args[1], out y);
                var outline = image.gameObject.
                    AddComponent<UnityEngine.UI.Outline>().
                    effectDistance = new UnityEngine.Vector2(x, y);
            }
        }
    }

    [ExpectComponent(typeof(UnityEngine.UI.Outline))]
    public class OutlineColor : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (value == null) return;
            UnityEngine.UI.Outline outline = 
                (UnityEngine.UI.Outline)value;
            outline.effectColor = MDUtils.ParseColor(args[0]);
        }
    }
}
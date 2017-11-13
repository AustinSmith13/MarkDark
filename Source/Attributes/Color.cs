using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(UnityEngine.UI.Extensions.RoundedRectangle))]
    public class Color : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            ((UnityEngine.UI.Extensions.RoundedRectangle)value).color = 
                MDUtils.ParseColor(args[0]);
        }
    }
}

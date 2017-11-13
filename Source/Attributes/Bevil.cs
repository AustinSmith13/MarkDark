using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(UnityEngine.UI.Extensions.RoundedRectangle))]
    public class Bevil : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (args.Length != 4) return;
            float x, y, z, w;
            float.TryParse(args[0], out x);
            float.TryParse(args[1], out y);
            float.TryParse(args[2], out z);
            float.TryParse(args[3], out w);

            ((UnityEngine.UI.Extensions.RoundedRectangle)value).corners =
                new UnityEngine.Vector4(x, y, z, w);
        }
    }
}

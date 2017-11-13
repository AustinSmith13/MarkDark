using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(Text))]
    public class FontColor : MDAttribute
    {
        public override void Apply(object obj, string[] args)
        {
            if (obj == null) return;
            if (args.Length < 1) return;
            var text = (Text)obj;
            text.color = MDUtils.ParseColor(args[0]);
        }
    }
}

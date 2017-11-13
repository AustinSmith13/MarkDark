using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(VerticalLayoutGroup))]
    public class Spacing : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (args.Length != 1)
                return;

            float result = 0f;
            float.TryParse(args[0], out result);
            ((VerticalLayoutGroup)value).spacing = result;
        }
    }
}

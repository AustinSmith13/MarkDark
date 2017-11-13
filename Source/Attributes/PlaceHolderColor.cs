using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(InputField))]
    public class PlaceHolderColor : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (args == null || args.Length == 0) return;
            ((Text)((InputField)value).placeholder).color = MDUtils.ParseColor(args[0]);
        }
    }
}

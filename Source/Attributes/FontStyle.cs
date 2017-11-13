using System;
using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(Text))]
    public class FontStyle : MDAttribute 
    {
        public override void Apply(object value, string[] args)
        {
            if (args.Length != 1) return;
            var text = (Text)value;
            text.fontStyle = MDUtils.ParseFontStyle(args[0].ToLower());
        }
    }

    [ExpectComponent(typeof(Text))]
    public class FontAlignment : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (args.Length != 1) return;
            ((Text)value).alignment = MDUtils.ParseTextAlignment(args[0].ToLower());
        }
    }
}

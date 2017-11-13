using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(Text))]
    public class FontSize : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            int size = 12;                              // default size
            System.Int32.TryParse(args[0], out size);   // try and parse the value
            ((Text)value).fontSize = size;              // Set the font size
        }
    }
}
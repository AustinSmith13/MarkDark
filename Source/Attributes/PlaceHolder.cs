using UnityEngine.UI;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(InputField))]
    public class PlaceHolder : MDAttribute
    {
        public override void Apply(object obj, string[] args)
        {
            if (obj == null) return;
            var inputField = (InputField)obj;
            if (inputField.placeholder == null) return;

            string placeholder = string.Empty;
            foreach(string arg in args)
                placeholder += arg + ", ";

            placeholder = placeholder.Substring(0, placeholder.Length - 2);
            var text = inputField.placeholder as Text;
            text.text = placeholder;
            
        }
    }
}

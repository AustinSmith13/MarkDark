using UnityEngine;

namespace MarkDark.Attributes
{
    [ExpectComponent(typeof(Element))]
    public class Id : MDAttribute
    {
        public override void Apply(object value, string[] args)
        {
            if (args.Length > 0)
                ((Element)value).SetName(args[0]);
        }
    }
}

using UnityEngine;

namespace MarkDark
{
    public class ExpectComponent : System.Attribute
    {
        public readonly System.Type component;

        public ExpectComponent(System.Type component)
        {
            this.component = component;
        }
    }
}

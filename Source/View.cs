using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using MarkDark.Elements;

namespace MarkDark
{
    public sealed class View
    {
        #region Properties

        public Element[] Elements { get { return _elements; } }
        public string Name { get { return name; } }

        #endregion

        private Element[] _elements;
        private readonly string name;

        static View()
        {
            // Registers tags that view can read.
            View.RegisterTag(new Tag("Button", typeof(MarkDark.Elements.ButtonElement)));
            View.RegisterTag(new Tag("Text", typeof(MarkDark.Elements.TextElement)));
            View.RegisterTag(new Tag("Panel", typeof(MarkDark.Elements.PanelElement)));
            View.RegisterTag(new Tag("Group", typeof(MarkDark.Elements.GroupElement)));
            View.RegisterTag(new Tag("InputField", typeof(MarkDark.Elements.InputFieldElement)));
            View.RegisterTag(new Tag("Toggle", typeof(MarkDark.Elements.ToggleElement)));
            View.RegisterTag(new Tag("Slider", typeof(MarkDark.Elements.SliderElement)));
            View.RegisterTag(new Tag("VerticalLayout", typeof(MarkDark.Elements.VerticalLayoutElement)));

            var mdAttributes = MDUtils.GetEnumerableOfType<MDAttribute>();

            Debug.Log(mdAttributes);

            foreach (var mdAttribute in mdAttributes)
            {
                string name = mdAttribute.GetType().Name;
                _mdAttributes.Add(name.ToLower(), mdAttribute);
            }
        }

        public View(Element[] elements, string name)
        {
            this.name = name;
            this._elements = elements;
        }

        public void ParentTo(Transform parent)
        {
            if (_elements == null) return;

            foreach (Element element in _elements)
                if (element.Parent == null)
                {
                    element.gameObject.transform.SetParent(parent);
                    string position = element.GetAttribute("position");                     // Get the elements position argument
                    if (position == string.Empty || position == null) position = "0,0";     // If position is not defined then default its value to (0, 0)
                    GetMDAttribute("position").Apply(                                       // Apply the position modifier to the elements RectTransform
                        element.gameObject.GetComponent<RectTransform>()
                        , position.Split(','));
                }

            if (name != null)
            {
                ViewTemplate vt;

                if (!viewTemplates.TryGetValue(name, out vt))
                    viewTemplates.Add(name, new MarkDark.ViewTemplate(this));
            }
        }

        public Element FindElementById(string id)
        {
            foreach(Element element in _elements)
            {
                if (element.Name == id)
                    return element;
            }

            return null;
        }


        public void Clear()
        {
            foreach(Element element in _elements)
            {
                if (element != null && element.gameObject != null)
                {
                    GameObject.Destroy(element.gameObject);
                    element.attributeArgs.Clear();
                    element.InnerText = string.Empty;
                }
            }
            _elements = null;
        }

        public static MDAttribute GetMDAttribute(string value)
        {
            MDAttribute attr = null;
            _mdAttributes.TryGetValue(value, out attr);
            return attr;
        }

        public static readonly IDictionary<string, Tag> tags = new Dictionary<string, Tag>();
        public static readonly IDictionary<string, ViewTemplate> viewTemplates = new Dictionary<string, ViewTemplate>();
        private static readonly IDictionary<string, MDAttribute> _mdAttributes = new Dictionary<string, MDAttribute>();
        public static void RegisterTag(Tag element) { tags.Add(element.name, element); }
    }
}

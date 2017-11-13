using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace MarkDark
{
    public class Element : IComparable<Element>
    {
        #region Propterties

        public string Name {
            get { return _name; }
            set
            {
                gameObject.name = value;
                _name = value;
            }
        }

        public Element Parent { get { return _parent; } set {
                _parent = value;
                gameObject.transform.SetParent(value.gameObject.transform);
            } }

        public string InnerText { get { return _text; } set { _text = value; } }

        #endregion

        protected Hashtable args;

        static int next_id = 0;
        public readonly string tag;
        public readonly int id;
        public readonly Dictionary<string, string> attributeArgs;
        public readonly Dictionary<string, MDAttribute> attributeMods;
        public readonly GameObject gameObject;
        public readonly RectTransform rectTransform;
        protected Element _parent;
        protected string _text;
        private string _name;
       // public readonly List<Element> children;

        public Element(string tag)
        {
            this.tag = tag;
            this.id = next_id++;
            this.args = new Hashtable();
            this.attributeArgs = new Dictionary<string, string>();
            this.attributeMods = new Dictionary<string, MDAttribute>();
         //   this.children = new List<Element>();
            this.gameObject = new GameObject("<>");
            this.rectTransform = gameObject.AddComponent<RectTransform>();
        }

        public void ModifyAttribute(string attribute, string arg)
        {
            View.GetMDAttribute(attribute).Apply(this, arg.Split(','));
        }

        public virtual void Init()
        {
            rectTransform.anchoredPosition = Vector2.zero;

            foreach (KeyValuePair<string, string> arg in attributeArgs)
            {
                MDAttribute mdAttribute = View.GetMDAttribute(arg.Key.ToLower());
                if (mdAttribute == null) continue;
                var attributes = mdAttribute.GetType().GetCustomAttributes(typeof(ExpectComponent), true);
                if (attributes == null || attributes.Length == 0) continue;
                var attrType = ((ExpectComponent)attributes[0]).component;

                // clean me...
                if (attrType == typeof(UnityEngine.Component)
                    || attrType.BaseType == typeof(UnityEngine.UI.Shadow)
                    || attrType.BaseType == typeof(UnityEngine.UI.MaskableGraphic)
                    || attrType.BaseType == typeof(UnityEngine.Transform)
                    || attrType.BaseType == typeof(UnityEngine.UI.Selectable)
                    || attrType.BaseType.BaseType == typeof(UnityEngine.UI.LayoutGroup))
                    mdAttribute.Apply(gameObject.GetComponent(
                        ((ExpectComponent)attributes[0]).component), arg.Value.Split(','));
                else if (attrType == typeof(Element))
                    mdAttribute.Apply(this, arg.Value.Split(','));
            }
        }

        public string SetName(string newName)
        {
            gameObject.name = newName;
            return (this._name = newName);
        }

        public string GetAttribute(string attribute)
        {
            string value;
            attributeArgs.TryGetValue(attribute, out value);
            return value;
        }

        public int CompareTo(Element other)
        {
            return 0;
        }
    }
}

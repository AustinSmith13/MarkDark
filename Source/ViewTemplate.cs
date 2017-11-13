using System;
using System.Collections.Generic;
using UnityEngine;

namespace MarkDark
{
    public class ViewTemplate
    {
        private readonly ElementTemplate[] elementTemplates;
        private readonly string name;

        public ViewTemplate(View view)
        {
            this.name = view.Name;
            List<ElementTemplate> templates = new List<ElementTemplate>();

            foreach(Element element in view.Elements)
            {
                //Debug.Log(view.Elements.Length);
                IDictionary<string, string> arguments = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> arg in element.attributeArgs)
                {
                    //Debug.Log(arg.Value);
                    arguments.Add(arg.Key, arg.Value);
                }

                ElementTemplate template = new ElementTemplate(
                        element.tag,
                        arguments,
                        element.id,
                        (element.Parent != null) ? (element.Parent.id) : (-1),
                        element.InnerText
                    );
                templates.Add(template);
            }

            elementTemplates = templates.ToArray();
        }

        public View Instantiate()
        {
            List<Element> elements = new List<Element>();
            Dictionary<int, Element> elementCache = new Dictionary<int, Element>();

            foreach(ElementTemplate template in elementTemplates)
            {
                Element element = View.tags[template.tag].CreateElement();

                try
                {
                    if (template.args != null)
                    {
                        foreach (KeyValuePair<string, string> arg in template.args)
                            element.attributeArgs.Add(arg.Key, arg.Value);
                    }

                    element.InnerText = template.text;
                    element.Init();
                }
                catch(Exception e) { Debug.LogException(e); }

                elementCache.Add(template.self, element);
                elements.Add(element);
            }

            for(int i = 0; i < elements.Count; i++)
            {
                Element parent = null;

                if (elementTemplates[i].parent != -1)
                    elementCache.TryGetValue(elementTemplates[i].parent, out parent);

                if(parent != null)
                    elementCache[elementTemplates[i].self].Parent = parent;
            }

            return new MarkDark.View(elements.ToArray(), null);
        }

    }

    public class ElementTemplate
    {
        public string tag;
        public IDictionary<string, string> args;
        public int parent;
        public string text;
        public int self;

        public ElementTemplate(string tag, 
            IDictionary<string, string> valuePair, 
            int self, int parent, string text)
        {
            this.tag = tag;
            this.parent = parent;
            this.text = text;
            this.self = self;
            this.args = valuePair;
        }
    }
    
}

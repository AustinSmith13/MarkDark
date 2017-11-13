using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.IO;

namespace MarkDark
{
    public static class ViewBuilder
    {
        static readonly Dictionary<string, Dictionary<string, string>> descriptor = 
            new Dictionary<string, Dictionary<string, string>>();
        static readonly string dataPath = Application.dataPath;
        static string temp = string.Empty;

        public static View LoadXmlFromFilePath(string filePath)
        {
            string xml = null;

            if (File.Exists(dataPath + "/" + filePath))
                xml = File.ReadAllText(dataPath + "/" + filePath);

            if (xml == null) return null;

            return MDParse(xml, filePath);
        }

        public static View LoadXml(string xml)
        {
            string name = string.Empty;
            return MDParse(xml);
        }


        private static View MDParse(string xml, string filePath = null)
        {
            List<Element> elements;
            Stack<Element> stack;
            XmlDocument xdoc;

            stack = new Stack<Element>();
            elements = new List<Element>();
            xdoc = new XmlDocument();
            xdoc.LoadXml(xml);

            var parentNode = xdoc.DocumentElement;
            var parentAttr = parentNode.Attributes;
            var parentName = parentNode.Name;
            string @namespace = null;
            foreach (XmlAttribute attr in parentAttr)
                if (attr.Name.ToLower() == "namespace")
                    @namespace = attr.Value;

            if (@namespace == null) @namespace = "global";

            foreach (XmlNode node in xdoc.ChildNodes)
                CreateElementFromNode(node, elements, stack, @namespace);

            if (filePath != null)
            {
                Dictionary<string, string> repo = null;
                if (!descriptor.TryGetValue(@namespace, out repo))
                {
                    repo = new Dictionary<string, string>();
                    descriptor.Add(@namespace, repo);
                }

                string value = null;
                if(!repo.TryGetValue(parentName, out value))
                    repo.Add(parentName, filePath);
            }

            return new View(elements.ToArray(), (parentName == string.Empty) ? null : parentName);
        }

        #region CreateElements

        private static void CreateElementFromNode(XmlNode node, IList<Element> elements,
            Stack<Element> stack, string @namespace)
        {
            Tag tag;
            View.tags.TryGetValue(node.Name, out tag);
            Element element = null;
            Dictionary<string, string> repo = null;
            string resource = null;

            if (stack == null) return;

            if (tag != null)
            {
                element = tag.CreateElement();
                if (element == null) return;

                var attributes = node.Attributes;
                for (int i = 0; i < attributes.Count; i++)
                    element.attributeArgs.Add(string.Join("",attributes[i].Name.Split('-')),
                        attributes[i].Value);

                element.InnerText = node.InnerText;
                elements.Add(element);

                if (stack.Count != 0)
                    element.Parent = stack.Peek();

                element.Init();
            }
           /* else if(elements.Count != 0 && descriptor.TryGetValue(@namespace, out repo) &&                [Temporarly disabled] - Infinit loop when two views reference eachother
                repo.TryGetValue(node.Name, out resource))
            {
                View view = ViewBuilder.LoadXmlFromFilePath(resource);
                foreach (Element e in view.Elements)
                {
                    if (stack.Count > 0)
                        if (e.Parent == null)
                            e.Parent = stack.Peek();
                    elements.Add(e);
                }
            }*/
            else
                if(elements.Count == 0)
                    CreateElementsFromNodesChildren(node, elements, stack, @namespace);
            

            if (element != null)
            {
                stack.Push(element);
                CreateElementsFromNodesChildren(node, elements, stack, @namespace);
            }
        }

        private static void CreateElementsFromNodesChildren(XmlNode parent, IList<Element> elements,
            Stack<Element> stack, string @namespace)
        {
            foreach (XmlNode node in parent.ChildNodes)
            {
                CreateElementFromNode(node, elements, stack, @namespace);
            }

            if(stack.Count > 0)
                stack.Pop();
        }

        #endregion
    }
}

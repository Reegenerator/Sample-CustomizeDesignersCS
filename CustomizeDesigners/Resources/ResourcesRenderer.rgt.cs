namespace CustomizeDesigners.Resources
{
    using System;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public partial class ResourcesRenderer
    {
        private static CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");

        /// <summary>
        /// Transforms the .NET name of a type into a C# type. E.g. System.String -> string
        /// </summary>
        private static string LangType(string type)
        {
            return codeProvider.GetTypeOutput(new System.CodeDom.CodeTypeReference(type));
        }

        /// <summary>
        /// The root element as deserialized from the resources file.
        /// </summary>
        private root _root;

        public override void PreRender()
        {
            base.PreRender();

            // Do not use the factory because it loads the xml file with validation and it contains the schema as well.
            // this._root = rootFactory.Create<root>(base.ProjectItem);

            // use classic serialization with no validation.
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(root));
            using (XmlReader reader = XmlReader.Create(base.ProjectItem.FullPath))
            {
                this._root = (root)xmlSerializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Renders all resources defined within the resource file.
        /// </summary>
        private void RenderAll()
        {
            if (this._root.Items == null)
                return; // no resources defined
            foreach (object o in this._root.Items)
            {
                rootData rd = o as rootData;
                if (rd == null)
                    continue; // ' not interested in what is not data
                // the value might contain a value, or a path to a resource file and the full name of a type, ';' separated
                string[] values = rd.value.Split(';');
                if (values.Length == 1)
                {
                    RenderString(rd); // it is a value, just render it as a property
                    continue;
                }
                // the first item is the path to the resource file. Check that the file exists.
                string resFilePath = Path.Combine(base.ProjectItem.Directory, values[0]);
                if (!File.Exists(resFilePath))
                    throw new ApplicationException(string.Format("Cannot find resource file {0}", resFilePath));
                // the second item is the type. Let's load it up.
                Type type = Type.GetType(values[1], true);
                if (type == typeof(string))
                {
                    // if the type is a string, then the resource is a text file. We need to load it
                    // and add its content to the renderered property comments
                    string content;
                    using (StreamReader reader = new StreamReader(resFilePath))
                    {
                        content = reader.ReadToEnd();
                    }
                    RenderTextFileResource(rd, content);
                    continue;
                }
                // this is a binary file
                if (type == typeof(MemoryStream))
                {
                    RenderBinaryFileResource(rd);
                    continue;
                }
                // and this is the case for all other resources.
                RenderResource(rd, LangType(type.FullName));
            }
        }
    }
}
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MyHomeUnity
{
    public static class Bootstrapper
    {
        private static readonly ClassFactory _classFactory;

        static Bootstrapper()
        {
            _classFactory = new ClassFactory();
        }

        public static void LoadModules(string moduleDefinitionFile)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);

            string moduleDefinitionFilePath = Path.Combine(directoryName, moduleDefinitionFile);

            XmlDocument document = new XmlDocument();

            document.Load(moduleDefinitionFilePath);

            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(document.NameTable);
            namespaceManager.AddNamespace("home", "MyHomeUnity");

            XmlNodeList nodeList = document.SelectNodes("/home:ModuleCatalog/home:ModuleInfo", namespaceManager);

            if (nodeList == null)
            {
                return;
            }

            ClassFactoryRegister classFactoryRegister = new ClassFactoryRegister(_classFactory);

            foreach (XmlNode node in nodeList)
            {
                string moduleType = node.Attributes?["ModuleType"]?.Value ?? string.Empty;
                string @ref = node.Attributes?["Ref"]?.Value ?? string.Empty;

                string refPath = Path.Combine(directoryName, @ref);

                var assembly = Assembly.LoadFile(refPath);
                var type = assembly.GetType(moduleType);

                IModuleInit moduleInit = (IModuleInit)Activator.CreateInstance(type);

                moduleInit.ClassFactoriesRegistration(classFactoryRegister);
            }
        }

        public static IClassFactory Factory => _classFactory;
    }
}
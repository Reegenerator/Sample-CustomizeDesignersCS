using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomizeDesigners
{
    class DatasetGeneratorWrapper
    {
        static public string GenTableAdapters(System.IO.Stream xmlStream )
        {

            var assm=Assembly.Load("System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            var designSourceType = assm.GetType("System.Data.Design.DesignDataSource");
            var designSource = Activator.CreateInstance(designSourceType);
            var readXmlSchemaMethod = designSourceType.GetMethod("ReadXmlSchema");
            readXmlSchemaMethod.Invoke(designSource, null);

            var dataSourceGeneratorType = assm.GetType("System.Data.Design.TypedDataSourceCodeGenerator");
            var dataSourceGenerator = Activator.CreateInstance(dataSourceGeneratorType);
            var createDataSourceDeclarationFunc = dataSourceGeneratorType.GetMethod("CreateDataSourceDeclaration",
                BindingFlags.Instance | BindingFlags.NonPublic);
          
            var res = (string)createDataSourceDeclarationFunc.Invoke(dataSourceGenerator, new object[] { designSource });
            return res;

        }
    }
}

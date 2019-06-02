using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace LoggerExtensions.Attributes.LoggerExtensions.Attributes.Fody
{
    public partial class ModuleWeaver
    {
        public MethodReference LogMethodReference;

        public void FindReferences()
        {
            var logger = FindType("MethodInputLogger");
            LogMethodReference = ModuleDefinition.ImportReference(logger.Methods.First(x => x.Name == "WriteLog"));
        }
    }
}

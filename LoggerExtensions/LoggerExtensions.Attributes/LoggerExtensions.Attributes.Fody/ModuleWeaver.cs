using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Fody;
using LoggerExtensions.Attributes.Helpers;
using Mono.Cecil;

namespace LoggerExtensions.Attributes.LoggerExtensions.Attributes.Fody
{
    public partial class ModuleWeaver : BaseModuleWeaver
    {

        public ModuleWeaver()
        {
        }

        public override void Execute()
        {
            FindReferences();
            var types = GetTypesToProcess();
            ProcessAssembly(types);
        }

        public override IEnumerable<string> GetAssembliesForScanning()
        {
            yield return "LoggerExtensions.Attributes";
        }

        List<TypeDefinition> GetTypesToProcess()
        {
            var allTypes = new List<TypeDefinition>(ModuleDefinition.GetTypes());
            
            return allTypes;
        }

        void ProcessAssembly(List<TypeDefinition> types)
        {
            foreach (var type in types)
            {
                if (type.IsInterface)
                {
                    continue;
                }

                foreach (var method in type.MethodsWithBody().Where(x => x.HasLogInputAttribute()))
                {
                    ProcessLogInput(method);
                }

                foreach (var property in type.ConcreteProperties().Where(x => x.HasLogInputAttribute()))
                {
                    ProcessLogInput(property);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace LoggerExtensions.Attributes.Helpers
{
    static class Extensions
    {
        public static IEnumerable<MethodDefinition> MethodsWithBody(this TypeDefinition type)
        {
            return type.Methods.Where(x => x.Body != null);
        }

        public static IEnumerable<PropertyDefinition> ConcreteProperties(this TypeDefinition type)
        {
            return type.Properties.Where(x => (x.GetMethod == null || !x.GetMethod.IsAbstract) && (x.SetMethod == null || !x.SetMethod.IsAbstract));
        }

        public static bool HasLogInputAttribute(this ICustomAttributeProvider value)
        {
            return value.CustomAttributes.Any(a => a.AttributeType.FullName == typeof(LogInputAttribute).FullName);
        }
        
        public static bool IsGeneratedCode(this ICustomAttributeProvider value)
        {
            return value.CustomAttributes.Any(a => a.AttributeType.Name == "CompilerGeneratedAttribute" || a.AttributeType.Name == "GeneratedCodeAttribute");
        }

        public static void Prepend(this Collection<Instruction> collection, ICollection<Instruction> instructions)
        {
            var index = 0;
            foreach (var instruction in instructions)
            {
                collection.Insert(index, instruction);
                index++;
            }
        }
    }
}

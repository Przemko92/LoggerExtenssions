using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using LoggerExtensions.Attributes.Helpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Mono.Collections.Generic;

namespace LoggerExtensions.Attributes.LoggerExtensions.Attributes.Fody
{
    public partial class ModuleWeaver
    {
        public void ProcessLogInput(MethodDefinition method)
        {
            try
            {
                if (method.IsGeneratedCode())
                {
                    return;
                }
                InnerProcessLogInput(method);
            }
            catch (Exception exception)
            {
                throw new Exception($"An error occurred processing method '{method.FullName}'.", exception);
            }
        }

        public void ProcessLogInput(PropertyDefinition property)
        {
            try
            {
                if (property.IsGeneratedCode())
                {
                    return;
                }
                InnerProcessLogInput(property.SetMethod);
            }
            catch (Exception exception)
            {
                throw new Exception($"An error occurred processing method '{property.FullName}'.", exception);
            }
        }
        
        private void InnerProcessLogInput(MethodDefinition method)
        {
            var body = method.Body;

            body.SimplifyMacros();

            var myInstructions = new List<Instruction>();

            LogInput(myInstructions, method);

            body.Instructions.Prepend(myInstructions);

            body.InitLocals = true;
            body.OptimizeMacros();
        }
    }
}

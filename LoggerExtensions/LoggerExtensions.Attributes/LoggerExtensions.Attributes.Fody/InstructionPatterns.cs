using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoggerExtensions.Attributes.Helpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace LoggerExtensions.Attributes.LoggerExtensions.Attributes.Fody
{
    public partial class ModuleWeaver
    {
        private const int MAX_ARGS = 10;

        private void LogInput(List<Instruction> instructions, MethodDefinition method)
        {
            instructions.Add(Instruction.Create(OpCodes.Ldstr, method.Name));
            instructions.Add(Instruction.Create(OpCodes.Ldc_I4, method.Parameters.Count));
            instructions.Add(Instruction.Create(OpCodes.Ldstr, method.DeclaringType.Name));

            FillParametersNames(instructions, method.Parameters);
            FillParametersTypes(instructions, method.Parameters);
            FillParametersValues(instructions, method.Parameters);

            instructions.Add(Instruction.Create(OpCodes.Call, LogMethodReference));
        }

        private void FillParametersTypes(List<Instruction> instructions, Collection<ParameterDefinition> parameters)
        {
            foreach (var parameter in parameters)
            {
                instructions.Add(Instruction.Create(OpCodes.Ldstr, parameter.ParameterType.Name));
            }

            FillNulls(instructions, parameters.Count);
        }

        private void FillParametersValues(List<Instruction> instructions, Collection<ParameterDefinition> parameters)
        {
            foreach (var parameter in parameters)
            {
                LoadArgumentOntoStack(instructions, parameter);
            }

            FillNulls(instructions, parameters.Count);
        }

        private void FillParametersNames(List<Instruction> instructions, Collection<ParameterDefinition> parameters)
        {
            foreach (var parameter in parameters)
            {
                instructions.Add(Instruction.Create(OpCodes.Ldstr, parameter.Name));
            }

            FillNulls(instructions, parameters.Count);
        }

        private void FillNulls(List<Instruction> instructions, int parametersCount)
        {
            for (int i = 0; i < MAX_ARGS - parametersCount; i++)
            {
                instructions.Add(Instruction.Create(OpCodes.Ldnull));
            }
        }

        public static void LoadArgumentOntoStack(List<Instruction> instructions, ParameterDefinition parameter)
        {
            // Load the argument onto the stack
            instructions.Add(Instruction.Create(OpCodes.Ldarg, parameter));

            var parameterType = parameter.ParameterType;
            var elementType = parameterType.GetElementType();

            if (parameterType.IsByReference)
            {

                // Loads an object reference onto the stack
                instructions.Add(Instruction.Create(OpCodes.Ldobj, elementType));
                // Box the type to an object
                instructions.Add(Instruction.Create(OpCodes.Box, elementType));
                // Loads an object reference onto the stack
                //instructions.Add(Instruction.Create(OpCodes.Ldind_Ref));
                return;
            }

            // Box the type to an object
            instructions.Add(Instruction.Create(OpCodes.Box, parameterType));
        }
    }
}

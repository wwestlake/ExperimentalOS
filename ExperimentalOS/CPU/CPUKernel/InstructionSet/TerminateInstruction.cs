using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    public class TerminateInstruction : Instruction
    {

        /// <summary>
        /// Construciton a Terminate Instruciton
        /// </summary>
        internal TerminateInstruction() : this(string.Empty) {  }

        /// <summary>
        /// Constructs a Terminate instruction
        /// </summary>
        /// <param name="comment">Comment</param>
        internal TerminateInstruction(string comment) : base(InstructionCodes.Terminate, comment) { this.Size = 1; }


        protected override Instruction Assemble(IInstructionFactory factory, string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m = CreateMatch(line, @"\s*;(?<comment>[\s\S]*)");
            if (line.StartsWith(Code.ToString().ToLower()))
            {
                return NewInstruction(factory, m.Groups["comment"].Value);
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        protected override string DisAssemble()
        {
            return string.Format("{0}  ; Terminate Program", Code);
        }

        protected override int Emit(byte[] buffer, int offset)
        {
            buffer[offset] = Convert.ToByte(Code);
            return 1;
        }

        protected override Instruction CreateFromBytes(IInstructionFactory factory, byte[] buffer, int offset)
        {
            if (buffer[offset] == Convert.ToByte(Code)) return NewInstruction(factory, string.Empty);
            throw new ApplicationException("Byte stream does not contain NOP at designated offset.");
        }

        protected Instruction NewInstruction(IInstructionFactory factory, string comment)
        {
            return factory.Terminate(comment);
        }

    }
}

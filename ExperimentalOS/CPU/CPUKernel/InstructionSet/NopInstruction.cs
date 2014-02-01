using System;
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{

    /// <summary>
    /// Represents No Operation instruction
    /// </summary>
    internal class NopInstruction : Instruction
    {

        /// <summary>
        /// Construciton a Nop Instruciton
        /// </summary>
        internal NopInstruction() : this(string.Empty) {  }

        /// <summary>
        /// Constructs a NOP instruction
        /// </summary>
        /// <param name="comment">Comment</param>
        internal NopInstruction(string comment) : base(InstructionCodes.NOP, comment) { this.Size = 1; }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="inst">The NopInstruction to copy</param>
        internal NopInstruction(NopInstruction inst) : this(string.Empty)
        {
        }

        /// <summary>
        /// Assembly a Nop Instruction
        /// </summary>
        /// <param name="assemblyLine">Assembly line representing a NOP</param>
        /// <returns>The instruction</returns>
        protected override Instruction Assemble(string assemblyLine)
        {
            Match m;
            string pattern = InstructionCodes.Move.ToString().ToLower() + @"\s*;(?<comment>[\s\S]*)";
            string line = assemblyLine.Trim().ToLower();
            if (assemblyLine.Trim().ToLower().StartsWith(InstructionCodes.NOP.ToString().ToLower()))
            {
                m = Regex.Match(line, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                return new NopInstruction(m.Groups["comment"].Value);
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        /// <summary>
        /// Generates Assembly code for a Nop instruction
        /// </summary>
        /// <returns></returns>
        protected override string DisAssemble()
        {
            return string.Format("{0}  ; No operation", Code);
        }

        /// <summary>
        /// Emit a NOP instuction code into the buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        protected override int Emit(byte[] buffer, int offset)
        {
            buffer[offset] = Convert.ToByte(Code);
            return 1;
        }


        /// <summary>
        /// Creates an NopInstruction from the bytes in the buffer
        /// </summary>
        /// <param name="buffer">Bytes that hold the instruction</param>
        /// <param name="offset">Position in the buffer to start reading</param>
        /// <returns>The Instruction created</returns>
        /// <exception>Application Exception if bytes are incorrect</exception>
        protected override Instruction CreateFromBytes(byte[] buffer, int offset)
        {
            if (buffer[offset] == Convert.ToByte(InstructionCodes.NOP)) return this;
            throw new ApplicationException("Byte stream does not contain NOP at designated offset.");
        }
    }
}

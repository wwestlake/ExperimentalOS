/*
    ExperimentalOS Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
    
    source code: https://github.com/wwestlake/ExperimentalOS.git 
  
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Represents a single atomic CPU instruction.
    /// </summary>
    public abstract class Instruction
    {
        
        /// <summary>
        /// Constructs an initial instruction which may require further initialization
        /// by a derived class
        /// </summary>
        /// <param name="code">The instruction code for this instruction</param>
        internal Instruction(InstructionCodes code) : this(code, string.Empty)
        {
        }

        /// <summary>
        /// Constructs an Instruction from InstructionCode and Comment
        /// </summary>
        /// <param name="code">The InstructionCode</param>
        /// <param name="comment">The Comment</param>
        internal Instruction(InstructionCodes code, string comment)
        {
            this.Code = code;
            this.Comment = comment;
        }

        /// <summary>
        /// Internally set by the CPUKernal for execution of the instruction
        /// </summary>
        internal ExecuteInstruction Execute { get; set; }


        internal string SymbolicLocation { get; set; }

        internal long Address { get; set; }

        /// <summary>
        /// Returns the instruction code for this instruction
        /// </summary>
        public InstructionCodes Code { get; set; }

        /// <summary>
        /// Creates an instruction from an assembly line
        /// </summary>
        /// <param name="assemblyLine">The assembly line to use</param>
        /// <returns>An instruction object</returns>
        public Instruction CreateInstruction(string assemblyLine)
        {
            return Assemble(assemblyLine);
        }

        /// <summary>
        /// Reads bytes from a buffer to produce an Instruction
        /// </summary>
        /// <param name="buffer">The buffer to read from</param>
        /// <param name="offset">The offset into the buffer to start reading at</param>
        /// <returns>An Instruction</returns>
        public Instruction Read(byte[] buffer, int offset)
        {
            return CreateFromBytes(buffer, offset);
        }


        /// <summary>
        /// Writes the instruction to the buffer starting at offset
        /// </summary>
        /// <param name="buffer">The buffer to write to</param>
        /// <param name="offset">The offset in the buffer to write at</param>
        /// <returns>The number of bytes written</returns>
        public int Write(byte[] buffer, int offset)
        {
            return Emit(buffer, offset);
        }

        /// <summary>
        /// When implemented assembles a string into this op code
        /// </summary>
        /// <param name="assemblyLine">The line of assembly to create the instruction from</param>
        /// <returns>An Instruction object</returns>
        /// <exception>Throws an ApplicationExceptiion if the string is not valid for this instruction</exception>
        protected abstract Instruction Assemble(string assemblyLine);

        /// <summary>
        /// When implemented produces a string representation of the instructiuon as assembly language
        /// </summary>
        /// <returns>The assembly language code as a string</returns>
        protected abstract string DisAssemble();

        /// <summary>
        /// When implemented Writes the op codes into buffer
        /// </summary>
        /// <param name="buffer">The buffer to write to</param>
        /// <param name="offset">The offiset within the buffer to write to</param>
        /// <returns>The number of bytes written</returns>
        protected abstract int Emit(byte[] buffer, int offset);

        /// <summary>
        /// Creates an instruction from the bytes in the buffer
        /// </summary>
        /// <param name="buffer">Bytes that hold the instruction</param>
        /// <param name="offset">Position in the buffer to start reading</param>
        /// <returns>The Instruction created</returns>
        /// <exception>Application Exception if bytes are incorrect</exception>
        protected abstract Instruction CreateFromBytes(byte[] buffer, int offset);

        /// <summary>
        /// Converts this to a disassembled string
        /// </summary>
        /// <returns>The assembly language equivilant</returns>
        public override string ToString()
        {
            return DisAssemble();
        }

        /// <summary>
        /// Any comment from the assembly file or from construction
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Returns the actual size in bytes that this instruction requires for storage
        /// in memory.  This size includes the data.
        /// </summary>
        public int Size { get; internal set; }

    }


}

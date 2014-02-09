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
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Class representing a Teminatate Instruction
    /// </summary>
    [Serializable]
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

        /// <summary>
        /// Assembles a Terminate Instruction
        /// </summary>
        /// <param name="factory">The instruction factory</param>
        /// <param name="assemblyLine">The line of assembly code</param>
        /// <returns>Terminate Instruction</returns>
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

        /// <summary>
        /// Disassemble an instruction to assembly code
        /// </summary>
        /// <returns>The assembly code</returns>
        protected override string DisAssemble()
        {
            return string.Format("{0}  ; Terminate Program", Code);
        }

        /// <summary>
        /// Create a new instruction from the factory
        /// </summary>
        /// <param name="factory">The factory to use</param>
        /// <param name="comment">Any comments for the instruction</param>
        /// <returns>Terminate Instruction</returns>
        protected Instruction NewInstruction(IInstructionFactory factory, string comment)
        {
            return factory.Terminate(comment);
        }

    }
}

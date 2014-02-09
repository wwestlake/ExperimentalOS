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
    /// Represents No Operation instruction
    /// </summary>
    [Serializable]
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
        /// <param name="factory">The instruction factory for this kernel</param>
        /// <returns>The instruction</returns>
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
        /// Generates Assembly code for a Nop instruction
        /// </summary>
        /// <returns></returns>
        protected override string DisAssemble()
        {
            return string.Format("{0}  ; No operation", Code);
        }


        protected Instruction NewInstruction(IInstructionFactory factory, string comment)
        {
            return factory.Nop();
        }

    }
}

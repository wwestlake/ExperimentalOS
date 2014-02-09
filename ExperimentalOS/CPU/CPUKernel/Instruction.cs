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

using System;
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Represents a single atomic CPU instruction.
    /// </summary>
    [Serializable]
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
        /// <param name="factory">The instruction factory for this kernel</param>
        /// <returns>An instruction object</returns>
        public Instruction CreateInstruction(IInstructionFactory factory, string assemblyLine)
        {
            return Assemble(factory, assemblyLine);
        }




        /// <summary>
        /// When implemented assembles a string into this op code
        /// </summary>
        /// <param name="assemblyLine">The line of assembly to create the instruction from</param>
        /// <param name="factory">the instruction factory for this kernel</param>
        /// <returns>An Instruction object</returns>
        /// <exception>Throws an ApplicationExceptiion if the string is not valid for this instruction</exception>
        protected abstract Instruction Assemble(IInstructionFactory factory, string assemblyLine);

        /// <summary>
        /// When implemented produces a string representation of the instructiuon as assembly language
        /// </summary>
        /// <returns>The assembly language code as a string</returns>
        protected abstract string DisAssemble();
       

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

        internal Match CreateMatch(string line, string pattern)
        {
            string matchPattern = Code.ToString().ToLower() + " " + pattern;
            return Regex.Match(line, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// Cleans up the source line
        /// 
        /// TODO: Add symbol lookup here and replace with addresses.????
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal string PreProcess(string line)
        {
            return line.ToLower().Trim();
        }

    }


}

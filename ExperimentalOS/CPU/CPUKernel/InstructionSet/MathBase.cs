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
    /// Adds data from register 1 to register 2
    /// Add r1, r2
    /// </summary>
    [Serializable]
    internal abstract class MathBase : Instruction
    {
        internal int r1, r2, r3;

        internal MathBase(InstructionCodes code) : base(code) { }

        /// <summary>
        /// Constructs a AddInstruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="code">The instruction code</param>
        internal MathBase(InstructionCodes code, int r1, int r2, int r3)
            : this(code, r1, r2, r3, string.Empty)
        {
        }

        /// <summary>
        /// Constructs a AddInstruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">Comment</param>
        /// <param name="code">The instruction code</param>
        internal MathBase(InstructionCodes code, int r1, int r2, int r3, string comment)
            : base(code, comment)
        {
            this.r1 = r1;
            this.r2 = r2;
            this.r3 = r3;
            this.Size = 3;
        }

        /// <summary>
        /// Copies a AddInstruction to this new object
        /// </summary>
        /// <param name="inst">The instruction to copy</param>
        internal MathBase(MathBase inst)
            : this(inst.Code, inst.r1, inst.r2, inst.r3, inst.Comment)
        {
        }

        /// <summary>
        /// When implemented assembles a string into this op code
        /// </summary>
        /// <param name="assemblyLine"></param>
        /// <param name="factory">The instruction factory for this kernel</param>
        /// <returns></returns>
        /// <exception>Throws an ApplicationExceptiion if the string is not valid for this instruction</exception>
        protected override Instruction Assemble(IInstructionFactory factory, string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*r(?<r2>\d+),\s*r(?<r2>\d+)\s*[;]*(?<comment>[\s\S]*)");
            if (line.StartsWith(Code.ToString().ToLower()))
            {
                return NewInstruction(factory, int.Parse(m.Groups["r1"].Value), int.Parse(m.Groups["r2"].Value), int.Parse(m.Groups["r2"].Value), m.Groups["comment"] != null ? m.Groups["comment"].Value : string.Empty);
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        /// <summary>
        /// When implemented produces a string representation of the instructiuon as assembly language
        /// </summary>
        /// <returns>The assembly language code as a string</returns>
        protected override string DisAssemble()
        {
            if (!string.IsNullOrEmpty(Comment)) return string.Format("{0} r{1}, r{2}, r{3}  ;{4}", Code, this.r1, this.r2, this.r3, this.Comment);
            return string.Format("{0} r{1}, r{2}", Code, this.r1, this.r2);
        }


        protected abstract Instruction NewInstruction(IInstructionFactory factory, int r1, int r2, int r3, string comment);
    }
}

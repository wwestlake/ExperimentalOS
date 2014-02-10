using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
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
using System.Text;
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Represents a single atomic Push instruction.
    /// </summary>
    [Serializable]
    internal class IncInstruction : Instruction
    {
        internal int r1;

        /// <summary>
        /// Constructs a Inc instruction
        /// </summary>
        /// <param name="r1">register</param>
        /// <param name="comment">comments</param>
        internal IncInstruction(int r1, string comment)
            : base(InstructionCodes.Inc, comment)
        {
            this.r1 = r1;
            Size = 2;
        }

        /// <summary>
        /// Constructs a Inc instruction
        /// </summary>
        /// <param name="r1">register</param>
        internal IncInstruction(int r1) : this(r1, string.Empty) { }

        protected override Instruction Assemble(IInstructionFactory factory, string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m = CreateMatch(line, @"\s+r(?<r1>\d+)\s*[;]*(?<comment>[\s\S]*)");
            if (line.StartsWith(Code.ToString().ToLower()))
            {
                if (m.Success)
                {
                    return NewInstruction(factory, int.Parse(m.Groups["r1"].Value), m.Groups["comment"] != null ? m.Groups["comment"].Value : string.Empty);
                }
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);

        }


        /// <summary>
        /// Converts instruction to assembly language representation
        /// </summary>
        /// <returns>String assembly language representation</returns>
        protected override string DisAssemble()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} r{1}", Code, r1);
            return builder.ToString();
        }


        protected Instruction NewInstruction(IInstructionFactory factory, int r1, string comment)
        {
            return factory.Inc(r1, comment);
        }


    }
}

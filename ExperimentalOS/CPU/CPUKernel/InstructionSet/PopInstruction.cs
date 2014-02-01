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
    internal class PopInstruction : Instruction
    {
        private int r1;

        /// <summary>
        /// Constructs a Pop instruction
        /// </summary>
        /// <param name="r1">register</param>
        /// <param name="comment">comments</param>
        internal PopInstruction(int r1, string comment)
            : base(InstructionCodes.Pop, comment)
        {
            this.r1 = r1;
        }

        /// <summary>
        /// Constructs a Pop instruction
        /// </summary>
        /// <param name="r1">register</param>
        internal PopInstruction(int r1) : base(InstructionCodes.Pop, string.Empty) { }

        protected override Instruction Assemble(string assemblyLine)
        {
            Match m;
            string pattern1 = InstructionCodes.Pop.ToString().ToLower() + @"\s+r(?<r1>\d+)\s*[;]*(?<comment>[\s\S]*)";
            string line = assemblyLine.Trim().ToLower();
            if (line.StartsWith(InstructionCodes.Pop.ToString().ToLower()))
            {
                m = Regex.Match(line, pattern1, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                if (m.Success)
                {
                    return new PopInstruction(int.Parse(m.Groups["r1"].Value), m.Groups["comment"] != null ? m.Groups["comment"].Value : string.Empty);
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

        /// <summary>
        /// Emits byte code representation of Push instruction
        /// </summary>
        /// <param name="buffer">buffer to write to</param>
        /// <param name="offset">offset in buffer</param>
        /// <returns>count of bytes written</returns>
        protected override int Emit(byte[] buffer, int offset)
        {
            int index = offset;
            buffer[index++] = (byte)Code;
            buffer[index++] = (byte)r1;
            return 2;
        }


        /// <summary>
        /// Creates a push instruction from byte code
        /// </summary>
        /// <param name="buffer">buffer where bytes are stored</param>
        /// <param name="offset">offset into buffer</param>
        /// <returns>An Instruciton</returns>
        protected override Instruction CreateFromBytes(byte[] buffer, int offset)
        {
            int index = offset;
            InstructionCodes code = (InstructionCodes)buffer[index++];
            int r1 = (int)buffer[index++];
            return new PopInstruction(r1);
        }
    }
}

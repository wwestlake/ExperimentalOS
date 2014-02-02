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
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Moves data from register 1 to register 2
    /// Move r1, r2
    /// </summary>
    internal class MoveInstruction : Instruction
    {
        internal int r1, r2;

        internal MoveInstruction() : base(InstructionCodes.Move) { }

        /// <summary>
        /// Constructs a MoveInstruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        internal MoveInstruction(int r1, int r2) : this(r1, r2, string.Empty)
        {
        }

        /// <summary>
        /// Constructs a MoveInstruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="comment">Comment</param>
        internal MoveInstruction(int r1, int r2, string comment)
            : base(InstructionCodes.Move, comment)
        {
            this.r1 = r1;
            this.r2 = r2;
            this.Size = 3;
        }

        /// <summary>
        /// Copies a MoveInstruction to this new object
        /// </summary>
        /// <param name="inst">The instruction to copy</param>
        internal MoveInstruction(MoveInstruction inst) : this(inst.r1, inst.r2, inst.Comment)
        {
        }

        /// <summary>
        /// When implemented assembles a string into this op code
        /// </summary>
        /// <param name="assemblyLine"></param>
        /// <returns></returns>
        /// <exception>Throws an ApplicationExceptiion if the string is not valid for this instruction</exception>
        protected override Instruction Assemble(string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*r(?<r2>\d+)\s*[;]*(?<comment>[\s\S]*)");
            if (line.StartsWith(Code.ToString().ToLower()))
            {
                return new MoveInstruction(int.Parse(m.Groups["r1"].Value), int.Parse(m.Groups["r2"].Value), m.Groups["comment"] != null ? m.Groups["comment"].Value : string.Empty);
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        /// <summary>
        /// When implemented produces a string representation of the instructiuon as assembly language
        /// </summary>
        /// <returns>The assembly language code as a string</returns>
        protected override string DisAssemble()
        {
            if  (!string.IsNullOrEmpty(Comment)) return string.Format("{0} r{1}, r{2}  ;{3}", Code, this.r1, this.r2, this.Comment);
            return string.Format("{0} r{1}, r{2}", Code, this.r1, this.r2);
        }

        /// <summary>
        /// When implemented Writes the op codes into buffer
        /// </summary>
        /// <param name="buffer">The buffer to write to</param>
        /// <param name="offset">The offiset within the buffer to write to</param>
        /// <returns>The number of bytes written</returns>
        protected override int Emit(byte[] buffer, int offset)
        {
            int index = offset;
            buffer[index++] = Convert.ToByte(Code);
            buffer[index++] = Convert.ToByte(r1);
            buffer[index++] = Convert.ToByte(r2);
            return 3;
         }

        /// <summary>
        /// Creates an MoveInstruction from the bytes in the buffer
        /// </summary>
        /// <param name="buffer">Bytes that hold the instruction</param>
        /// <param name="offset">Position in the buffer to start reading</param>
        /// <returns>The Instruction created</returns>
        /// <exception>Application Exception if bytes are incorrect</exception>
        protected override Instruction CreateFromBytes(byte[] buffer, int offset)
        {
            int index = offset;
            InstructionCodes code = (InstructionCodes)buffer[index++];
            if (code != InstructionCodes.Move) throw new InvalidOperationException(string.Format("Expected Move Instruction but encountered: {0} instruction", code));
            int r1 = (int)buffer[index++];
            int r2 = (int)buffer[index++];
            return new MoveInstruction(r1, r2);
        }
    }
}

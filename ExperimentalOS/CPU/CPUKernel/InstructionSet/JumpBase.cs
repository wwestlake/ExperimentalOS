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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    internal abstract class JumpBase : Instruction
    {
        internal int r1;
        internal uint address;

        internal JumpBase(InstructionCodes code, int r1, uint address, string comment)
            : base(code, comment)
        {
            this.r1 = r1;
            this.address = address;
            if (address != (uint)Symbols.NullAddress)
            {
                this.Size = 4 + sizeof(uint);
            }
            else if (address != (uint)Symbols.NullAddress)
            {
                this.Size = 3 + sizeof(uint);
            }
            else if (address == (uint)Symbols.NullAddress)
            {
                this.Size = 3 + sizeof(int);
            }
        }

        internal JumpBase(InstructionCodes code, int r1, uint address) : this(code, r1, address, string.Empty) { }

        /// <summary>
        /// When implemented assembles a string into this op code
        /// </summary>
        /// <param name="assemblyLine">The line of assembly to create the instruction from</param>
        /// <returns>An Instruction object</returns>
        /// <exception>Throws an ApplicationExceptiion if the string is not valid for this instruction</exception>
        protected override Instruction Assemble(IInstructionFactory factory, string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m1 = CreateMatch(line,  @"\s+r(?<r1>\d+)\s*,\s*\$(?<address>\d+)\s*[;]*(?<comment>[\s\S]*)");
            Match m2 = CreateMatch(line,  @"\s+r(?<r1>\d+)\s*[;]*(?<comment>[\s\S]*)");
            Match m3 = CreateMatch(line,  @"\s+\$(?<address>\d+)\s*[;]*(?<comment>[\s\S]*)");
            if (line.StartsWith(Code.ToString().ToLower()))
            {
                if (m1.Success)
                {
                    return NewInstruction(factory, int.Parse(m1.Groups["r1"].Value), uint.Parse(m1.Groups["address"].Value), m1.Groups["comment"] != null ? m1.Groups["comment"].Value : string.Empty);
                }
                if (m2.Success)
                {
                    return NewInstruction(factory, int.Parse(m2.Groups["r1"].Value), (uint)Symbols.NullAddress, m2.Groups["comment"] != null ? m2.Groups["comment"].Value : string.Empty);
                }
                if (m3.Success)
                {
                    return NewInstruction(factory, int.Parse(m3.Groups["r1"].Value), uint.Parse(m3.Groups["address"].Value), m3.Groups["comment"] != null ? m3.Groups["comment"].Value : string.Empty);
                }
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        


        /// <summary>
        /// When implemented produces a string representation of the instructiuon as assembly language
        /// </summary>
        /// <returns>The assembly language code as a string</returns>
        protected override string DisAssemble()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}", Code);
            if (r1 != Symbols.NullRegister && address != Symbols.NullAddress)
            {
                builder.AppendFormat(" r{0}, ${1}", r1, address);
            }
            else if (r1 != Symbols.NullRegister)
            {
                builder.AppendFormat("r{0}", r1);
            }
            else if (address != Symbols.NullAddress)
            {
                builder.AppendFormat("${0}", address);
            }
            if (!string.IsNullOrEmpty(Comment))
            {
                builder.AppendFormat(" ;{0}", Comment);
            }
            return builder.ToString();
        }

        /// <summary>
        /// When implemented Writes the op codes into buffer
        /// </summary>
        /// <param name="buffer">The buffer to write to</param>
        /// <param name="offset">The offiset within the buffer to write to</param>
        /// <returns>The number of bytes written</returns>
        protected override int Emit(byte[] buffer, int offset)
        {
            AddressingMode extInstCode = 0;
            byte[] addressBytes = BitConverter.GetBytes(address);
            if (r1 != Symbols.NullRegister && address != Symbols.NullAddress)
            {
                extInstCode = AddressingMode.IndexedInderect;
            }
            else if (address != (uint)Symbols.NullAddress)
            {
                extInstCode = AddressingMode.Direct;
            }
            int index = offset;
            buffer[index++] = (byte)Code;
            buffer[index++] = (byte)extInstCode;
            buffer[index++] = (byte)r1;
            switch (extInstCode)
            {
                case AddressingMode.Direct:
                    for (int i = 0; i < addressBytes.Length; i++) buffer[index++] = addressBytes[i];
                    break;
                case AddressingMode.IndexedInderect:
                    buffer[index++] = (byte)r1;
                    for (int i = 0; i < addressBytes.Length; i++) buffer[index++] = addressBytes[i];
                    break;
            }
            return index;
        }

        /// <summary>
        /// Creates an instruction from the bytes in the buffer
        /// </summary>
        /// <param name="buffer">Bytes that hold the instruction</param>
        /// <param name="offset">Position in the buffer to start reading</param>
        /// <returns>The Instruction created</returns>
        /// <exception>Application Exception if bytes are incorrect</exception>
        protected override Instruction CreateFromBytes(IInstructionFactory factory, byte[] buffer, int offset)
        {
            AddressingMode extInstCode = 0;
            int index = offset;
            InstructionCodes code = (InstructionCodes)buffer[index++];
            int r1 = Symbols.NullRegister;
            uint address = (uint)Symbols.NullAddress;
            if (code != Code) throw new InvalidOperationException(string.Format("Expected {0} Instruction but encountered: {1} instruction", Code, code));
            extInstCode = (AddressingMode)buffer[index++];
            r1 = (int)buffer[index++];
            switch (extInstCode)
            {
                case AddressingMode.Direct:
                    address = BitConverter.ToUInt32(buffer, index++);
                    break;
                case AddressingMode.IndexedInderect:
                    r1 = (int)buffer[index++];
                    address = BitConverter.ToUInt32(buffer, index++);
                    break;
            }
            return NewInstruction(factory, r1, address, string.Empty);
        }

        protected abstract Instruction NewInstruction(IInstructionFactory factory, int r1, uint address, string comment);
    }
}

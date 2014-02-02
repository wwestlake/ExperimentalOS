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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    internal abstract class LoadStoreBase : Instruction
    {
        internal int r1, r2;
        internal uint address;
        internal int value;

        internal LoadStoreBase(InstructionCodes code, int r1, int r2, int value, uint address, string comment)
            : base(code, comment)
        {
            this.r1 = r1;
            this.r2 = r2;
            this.address = address;
            this.value = value;
            if (r2 != Symbols.NullRegister && address != (uint)Symbols.NullAddress)
            {
                this.Size = 4 + sizeof(uint);
            }
            else if (r2 != Symbols.NullRegister)
            {
                this.Size = 3 + sizeof(uint);
            }
            else if (address != (uint)Symbols.NullAddress)
            {
                this.Size = 3 + sizeof(uint);
            }
            else if (r2 == Symbols.NullRegister && address == (uint)Symbols.NullAddress)
            {
                this.Size = 3 + sizeof(int);
            }
        }

        internal LoadStoreBase(InstructionCodes code, int r1, int r2, int value, uint address) : this(code, r1, r2, value, address, string.Empty) { }

        /// <summary>
        /// When implemented assembles a string into this op code
        /// </summary>
        /// <param name="assemblyLine">The line of assembly to create the instruction from</param>
        /// <returns>An Instruction object</returns>
        /// <exception>Throws an ApplicationExceptiion if the string is not valid for this instruction</exception>
        protected override Instruction Assemble(string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m1 = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*r(?<r2>\d+),\s*\$(?<address>\d+)\s*[;]*(?<comment>[\s\S]*)");
            Match m2 = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*r(?<r2>\d+)\s*[;]*(?<comment>[\s\S]*)");
            Match m3 = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*\$(?<address>\d+)\s*[;]*(?<comment>[\s\S]*)");
            Match m4 = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*(?<value>[\+\-]*\d+)\s*[;]*(?<comment>[\s\S]*)");
            if (line.StartsWith(Code.ToString().ToLower()))
            {
                if (m1.Success)
                {
                    return NewInstruction(int.Parse(m1.Groups["r1"].Value), int.Parse(m1.Groups["r2"].Value), 0, uint.Parse(m1.Groups["address"].Value), m1.Groups["comment"] != null ? m1.Groups["comment"].Value : string.Empty);
                }
                if (m2.Success)
                {
                    return NewInstruction(int.Parse(m2.Groups["r1"].Value), int.Parse(m2.Groups["r2"].Value), 0, (uint)Symbols.NullAddress, m2.Groups["comment"] != null ? m2.Groups["comment"].Value : string.Empty);
                }
                if (m3.Success)
                {
                    return NewInstruction(int.Parse(m3.Groups["r1"].Value), Symbols.NullRegister, 0, uint.Parse(m3.Groups["address"].Value), m3.Groups["comment"] != null ? m3.Groups["comment"].Value : string.Empty);
                }
                if (m4.Success)
                {
                    return NewInstruction(int.Parse(m4.Groups["r1"].Value), Symbols.NullRegister, int.Parse(m4.Groups["value"].Value), (uint)Symbols.NullAddress, m4.Groups["comment"] != null ? m4.Groups["comment"].Value : string.Empty);
                }
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        protected abstract Instruction NewInstruction(int r1, int r2, int value, uint address, string comment);


        /// <summary>
        /// When implemented produces a string representation of the instructiuon as assembly language
        /// </summary>
        /// <returns>The assembly language code as a string</returns>
        protected override string DisAssemble()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} r{1}", Code, r1);
            if (r2 != Symbols.NullRegister && address != (ulong)Symbols.NullAddress)
            {
                builder.AppendFormat(", r{0}, ${1}", r2, address);
            }
            else if (r2 != Symbols.NullRegister)
            {
                builder.AppendFormat(", r{0}", r2);
            }
            else if (address != (ulong)Symbols.NullAddress)
            {
                builder.AppendFormat(", ${0}", address);
            }
            else if (r2 == Symbols.NullRegister && address == (ulong)Symbols.NullAddress)
            {
                builder.AppendFormat(", {0}", value);
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
            byte[] valueBytes = BitConverter.GetBytes(value);
            if (r2 != Symbols.NullRegister && address != (uint)Symbols.NullAddress)
            {
                extInstCode = AddressingMode.IndexedInderect;
            }
            else if (r2 != Symbols.NullRegister)
            {
                extInstCode = AddressingMode.Indirect;
            }
            else if (address != (uint)Symbols.NullAddress)
            {
                extInstCode = AddressingMode.Direct;
            }
            else if (r2 == Symbols.NullRegister && address == (uint)Symbols.NullAddress)
            {
                extInstCode = AddressingMode.Imediate;
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
                case AddressingMode.Indirect:
                    buffer[index++] = (byte)r2;
                    break;
                case AddressingMode.IndexedInderect:
                    buffer[index++] = (byte)r2;
                    for (int i = 0; i < addressBytes.Length; i++) buffer[index++] = addressBytes[i];
                    break;
                case AddressingMode.Imediate:
                    for (int i = 0; i < valueBytes.Length; i++) buffer[index++] = valueBytes[i];
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
        protected override Instruction CreateFromBytes(byte[] buffer, int offset)
        {
            AddressingMode extInstCode = 0;
            int index = offset;
            InstructionCodes code = (InstructionCodes)buffer[index++];
            int r1 = Symbols.NullRegister;
            int r2 = Symbols.NullRegister;
            uint address = (uint)Symbols.NullAddress;
            int value = 0;
            if (code != Code) throw new InvalidOperationException(string.Format("Expected {0} Instruction but encountered: {1} instruction", Code, code));
            extInstCode = (AddressingMode)buffer[index++];
            r1 = (int)buffer[index++];
            switch (extInstCode)
            {
                case AddressingMode.Direct:
                    address = BitConverter.ToUInt32(buffer, index++);
                    break;
                case AddressingMode.Indirect:
                    r2 = (int)buffer[index++];
                    break;
                case AddressingMode.IndexedInderect:
                    r2 = (int)buffer[index++];
                    address = BitConverter.ToUInt32(buffer, index++);
                    break;
                case AddressingMode.Imediate:
                    value = BitConverter.ToInt32(buffer, index);
                    break;
            }
            return NewInstruction(r1, r2, value, address, string.Empty);
        }


    }
}

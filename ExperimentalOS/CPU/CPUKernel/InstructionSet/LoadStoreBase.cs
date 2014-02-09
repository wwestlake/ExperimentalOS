﻿/*
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
    [Serializable]
    internal abstract class LoadStoreBase : Instruction
    {
        internal int r1, r2;
        internal uint address;
        internal int value;

        /// <summary>
        /// Base class for Load and Store instructions handles all parsing in a consistent manner
        /// </summary>
        /// <param name="code">The specific code for this instruction</param>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">An imediate value</param>
        /// <param name="address">An address</param>
        /// <param name="comment">A comment</param>
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
        /// <param name="factory">the instruction factory for this kernel</param>
        /// <returns>An Instruction object</returns>
        /// <exception>Throws an ApplicationExceptiion if the string is not valid for this instruction</exception>
        protected override Instruction Assemble(IInstructionFactory factory, string assemblyLine)
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
                    return NewInstruction(factory, int.Parse(m1.Groups["r1"].Value), int.Parse(m1.Groups["r2"].Value), 0, uint.Parse(m1.Groups["address"].Value), m1.Groups["comment"] != null ? m1.Groups["comment"].Value : string.Empty);
                }
                if (m2.Success)
                {
                    return NewInstruction(factory, int.Parse(m2.Groups["r1"].Value), int.Parse(m2.Groups["r2"].Value), 0, (uint)Symbols.NullAddress, m2.Groups["comment"] != null ? m2.Groups["comment"].Value : string.Empty);
                }
                if (m3.Success)
                {
                    return NewInstruction(factory, int.Parse(m3.Groups["r1"].Value), Symbols.NullRegister, 0, uint.Parse(m3.Groups["address"].Value), m3.Groups["comment"] != null ? m3.Groups["comment"].Value : string.Empty);
                }
                if (m4.Success)
                {
                    return NewInstruction(factory, int.Parse(m4.Groups["r1"].Value), Symbols.NullRegister, int.Parse(m4.Groups["value"].Value), (uint)Symbols.NullAddress, m4.Groups["comment"] != null ? m4.Groups["comment"].Value : string.Empty);
                }
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        protected abstract Instruction NewInstruction(IInstructionFactory factory, int r1, int r2, int value, uint address, string comment);


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



    }
}

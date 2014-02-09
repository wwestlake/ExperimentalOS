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
using System.Text;
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    [Serializable]
    internal class OutInstruction : Instruction
    {
        internal int r1;
        internal int port;

        internal OutInstruction(int r1, int port, string comment) : base(InstructionCodes.Out, comment)
        {
            this.r1 = r1;
            this.port = port;
            this.Size = 2 + sizeof(int);
        }

        internal OutInstruction(int r1, int port) : this(r1, port, string.Empty) {}

        protected override Instruction Assemble(IInstructionFactory factory, string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*\$(?<port>\d+)\s*[;]*(?<comment>[\s\S]*)");
            if (line.StartsWith(InstructionCodes.Out.ToString().ToLower()))
            {
                if (m.Success)
                {
                    return NewInstruction(factory, int.Parse(m.Groups["r1"].Value), int.Parse(m.Groups["port"].Value), m.Groups["comment"] != null ? m.Groups["comment"].Value : string.Empty);
                }
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        protected override string DisAssemble()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} r{1}, ${2}", Code, r1, port);
            return builder.ToString();
        }


        protected Instruction NewInstruction(IInstructionFactory factory, int r1, int port, string comment)
        {
            return factory.Out(r1, port, comment);
        }
    }
}

using LagDaemon.ExperimentalOS.Assembler.Interfaces;
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
using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.Assembler
{
    internal abstract class Assembler : IAssembler
    {
        protected AssemblerFileReader reader;
        protected int currentLine = 1;

        internal Assembler(AssemblerFileReader reader, CPUKernel kernel)
        {
            this.reader = reader;
            this.Kernel = kernel;
        }

        public IEnumerable<Instruction> Program
        {
            get
            {
                foreach (string line in reader.Lines)
                {
                    this.currentLine++;
                    AssemblerLineDescription? desc = ParseLine(line);
                    if (null == desc) continue;
                    yield return Assemble(desc.Value);
                }
            }
        }

        internal CPUKernel Kernel { get; private set; }

        protected abstract Instruction Assemble(AssemblerLineDescription line);

        protected InstructionCodes GetInstructionCode(string codeString)
        {
            try
            {
                InstructionCodes code = (InstructionCodes)Enum.Parse(typeof(InstructionCodes), codeString);
                if (Enum.IsDefined(typeof(InstructionCodes), code))
                    return code;
                throw new ParseException("Instruction Code {0} not define.", codeString);
            } 
            catch (ArgumentException)
            {
                throw new ParseException("Instruction Code {0} at line {1} not define.", codeString, currentLine);
            }
        }



        protected AssemblerLineDescription? ParseLine(string line)
        {
            AssemblerLineDescription result = new AssemblerLineDescription();
            string[] split = line.Split(new char[] { ';' });
            if (split.Length == 0) return null;
            if (split.Length == 2) result.comment = split[1].Trim();
            string inst = split[0].Trim();
            string expression = @"(?<lable>[\w_]+:)?(?<opcode>\w+)\s+(?<params>[\w\s,]*);?(?<comment>[\s.]*)";
            Match match = Regex.Match(inst, expression);
            if (match.Success)
            {
                result.lable = match.Groups["lable"].Value;
                result.opcode = match.Groups["opcode"].Value;
                result.paramters = match.Groups["params"].Value;
                result.comment = match.Groups["comment"].Value;
                return result;
            }
            return null;
        }


        protected struct AssemblerLineDescription
        {
            public string lable;
            public string opcode;
            public string paramters;
            public string comment;
        }


    }
}

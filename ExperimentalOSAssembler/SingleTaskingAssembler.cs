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
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;

namespace LagDaemon.ExperimentalOS.Assembler
{
    internal class SingleTaskingAssembler : Assembler 
    {
        internal SingleTaskingAssembler(AssemblerFileReader reader, CPUKernel kernel) : base(reader, kernel) { }

        /// <summary>
        /// Analyze each line of code and determine if it is an instruction code line, 
        /// a symbol declaration, or has a symbol embeded in it.
        /// </summary>
        /// <param name="line">A line of assembly code</param>
        /// <returns>An instruction object</returns>
        protected override CPU.CPUKernel.Instruction Assemble(AssemblerLineDescription line)
        {
            IInstructionFactory factory = CPUKernelFactory.Factory.Mode(CPUModes.SingleTasking).InstrucitnoFactory;
            Console.WriteLine("{0} {1} {2} {3}",line.lable, line.opcode, line.paramters, line.comment);
            InstructionCodes code = GetInstructionCode(line.opcode);
            Console.WriteLine(code);
            return factory.FromCode(code).CreateInstruction(factory, string.Format("{0} {1}", line.opcode, line.paramters));
        }



    }
}

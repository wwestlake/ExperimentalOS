using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
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
using Hardware = LagDaemon.ExperimentalOS.CPU.CPUHardware;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Represents the microcode side of the CPU for execution of instruction codes
    /// and handles CPU level memory management and task switching.
    /// </summary>
    public abstract class CPUKernel
    {

        /// <summary>
        /// Constructs a CPUKernel
        /// </summary>
        internal CPUKernel() { }

        internal void Nop(Instruction inst)
        {
            // no operation
        }

        internal void Load(Instruction inst)
        {
        }

        internal void Move(Instruction inst)
        {
            MoveInstruction move = inst as MoveInstruction;
            Processor.Registers[move.r1] = Processor.Registers[move.r2];
        }

        internal void Pop(Instruction inst)
        {
        }

        internal void Push(Instruction inst)
        {
        }

        internal void In(Instruction inst)
        {

        }

        internal void Out(Instruction inst)
        {

        }

        internal Hardware.CPU Processor { get; set; }
    }
}

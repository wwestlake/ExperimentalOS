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
using LagDaemon.ExperimentalOS.OS.Utilities;
using System.Collections.Generic;


namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    /// <summary>
    /// Emulates a CPU with task switching, memory management, registers and instruction codes.
    /// </summary>
    internal abstract class CPU
    {

        /// <summary>
        /// Constructis a CPU
        /// </summary>
        /// <param name="cpuKernel">The Kernel for this CPU</param>
        internal CPU(CPUKernel.CPUKernel cpuKernel)
        {
            this.CpuKernel = cpuKernel;
            this.CpuKernel.Processor = this;
            this.RegisterCount = Settings.NumberOfRegisters;
            this.Registers = new int[Settings.NumberOfRegisters];
            this.InstructionQueue = new Queue<Instruction>();
        }

        /// <summary>
        /// Count of available registers
        /// </summary>
        internal int RegisterCount { get; private set; }

        /// <summary>
        /// Array of actual registers in this CPU
        /// </summary>
        internal int[] Registers { get; private set; }

        /// <summary>
        /// The instruction queue loaded in the order of executing instructions.
        /// </summary>
        internal Queue<Instruction> InstructionQueue { get; private set; }

        /// <summary>
        /// The CPUKernel for this CPU
        /// </summary>
        internal CPUKernel.CPUKernel CpuKernel { get; private set; }

        /// <summary>
        /// A math operation that results in zero sets this flag true
        /// Flag will remain in this state until another math operation
        /// changes it
        /// </summary>
        internal bool ZeroFlag { get; set; }

        /// <summary>
        /// Holds the result of the last Compare instruction
        /// This flag will remain in this state until another compare
        /// statement or a ClearCompare instruction is encountered.
        /// </summary>
        internal ComparisonFlags ComparisonFlag { get; set; }


        /// <summary>
        /// The current operational mode of the processor
        /// </summary>
        internal ProcessorModes ProcessorMode { get; set; }

        /// <summary>
        /// The currently executing instruction
        /// </summary>
        internal Instruction CurrentInstruction { get; set; }

        /// <summary>
        /// Controls all external devices and creates input output ports
        /// </summary>
        internal DeviceController Devices { get; set; }

        /// <summary>
        /// The main memory of the system
        /// </summary>
        internal MemoryController Memory { get; set; }

        internal abstract void ProcessorStart();
    }
}

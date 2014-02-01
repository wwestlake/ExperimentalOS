/*
    ExperimentalOS Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
  
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

namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    /// <summary>
    /// Emulates a CPU with task switching, memory management, registers and instruction codes.
    /// </summary>
    public abstract class CPU
    {
        /// <summary>
        /// Shared between CPU threads to allow caching of instructions from OS level memory to CPU memory
        /// </summary>
        private uint[] _cache;

        /// <summary>
        /// The registers for this CPU
        /// </summary>
        private uint[] _registers;

        /// <summary>
        /// Holds the CPU level kernel
        /// </summary>
        private uint[] _cpuMemory;


        private CPUKernel.CPUKernel _cpuKernel;

        /// <summary>
        /// Constructis a CPU
        /// </summary>
        /// <param name="cpuKernel">The Kernel for this CPU</param>
        public CPU(CPUKernel.CPUKernel cpuKernel)
        {
            this._cpuKernel = cpuKernel;
        }

    }
}

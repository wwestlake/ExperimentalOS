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
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Addressing modes supported by instructions that use addresses.
    /// </summary>
    public enum AddressingMode { 

        /// <summary>
        /// Direct addressing is where an address appears in memory imediately following the instruction code
        /// </summary>
        Direct = 1, 

        /// <summary>
        /// Indirect addressing is where a register contains the address to use
        /// </summary>
        Indirect = 2, 

        /// <summary>
        /// Indexed addressing is where an address appears imediately following the instruction code and a register 
        /// indexes to some point beyond that address.
        /// </summary>
        /// 
        Indexed = 3,

        /// <summary>
        /// This is where two registers are used to compute the final address, one contains the address the other indexes into
        /// memory.
        /// </summary>
        IndexedInderect = 4,

        /// <summary>
        /// Imediate takes an operand imediately following the op code
        /// </summary>
        Imediate = 5

    }
}

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
    /// <summary>
    /// Stores data from a register to a memory
    /// Store value, $address   ; imediate
    /// Store r1, $address      ; direct addressing
    /// Store r1, r2            ; indirect addressing
    /// Store r1, r2, address   ; indexed indirect addressing  
    /// </summary>
    internal class StoreInstruction : LoadStoreBase
    {

        /// <summary>
        /// Create a store instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        internal StoreInstruction(int r1, int r2, int value, uint address, string comment)
            : base(InstructionCodes.Store, r1, r2, value, address, comment) {}

        internal StoreInstruction(int r1, int r2, int value, uint address)
            : base(InstructionCodes.Store, r1, r2, value, address) {}


        protected override Instruction NewInstruction(int r1, int r2, int value, uint address, string comment)
        {
            return new StoreInstruction(r1, r2, value, address, comment);
        }
    }
}

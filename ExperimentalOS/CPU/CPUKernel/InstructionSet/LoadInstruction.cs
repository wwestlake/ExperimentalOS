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
    /// <summary>
    /// Loads data from memory to a register
    /// Load r1, value          ; imediate
    /// Load r1, $address       ; direct addressing
    /// Load r1, r2            ; indirect addressing
    /// Load r1, r2, address   ; indexed indirect addressing  
    /// </summary>
    internal class LoadInstruction : LoadStoreBase
    {

        /// <summary>
        /// Create a load instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        internal LoadInstruction(int r1, int r2, int value, uint address, string comment)
            : base(InstructionCodes.Load, r1,r2, value, address, comment) {}

        internal LoadInstruction(int r1, int r2, int value, uint address)
            : base(InstructionCodes.Load,r1, r2, value, address) {}

        protected override Instruction NewInstruction(IInstructionFactory factory, int r1, int r2, int value, uint address, string comment)
        {
            return factory.Load(r1, r2, value, address, comment);
        }
    }
}

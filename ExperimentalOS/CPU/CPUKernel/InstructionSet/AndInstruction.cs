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
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Ands data from register 1 to register 2
    /// And r1, r2
    /// </summary>
    [Serializable]
    internal class AndInstruction : MathBase
    {

        internal AndInstruction() : base(InstructionCodes.And) { }

        internal AndInstruction(int r1, int r2, int r3)
            : this(r1, r2, r3, string.Empty) { }

        internal AndInstruction(int r1, int r2, int r3, string comment)
            : base(InstructionCodes.And, r1, r2, r3, comment) { }

        internal AndInstruction(AndInstruction inst)
            : this(inst.r1, inst.r2, inst.r3, inst.Comment) { }

        protected override Instruction NewInstruction(IInstructionFactory factory, int r1, int r2, int r3, string comment)
        {
            return factory.And(r1, r2, r3, comment);
        }
    }
}
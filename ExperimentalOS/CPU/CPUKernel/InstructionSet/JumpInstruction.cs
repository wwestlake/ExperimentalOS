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

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    [Serializable]
    internal class JumpInstruction : JumpBase
    {
        internal JumpInstruction(int r1, uint address, string comment) : base(InstructionCodes.Jump, r1, address, comment) { }

        internal JumpInstruction(int r1, uint address) : base(InstructionCodes.Jump, r1, address) { }

        protected override Instruction NewInstruction(IInstructionFactory factory, int r1, uint address, string comment)
        {
            return factory.Jump(r1, address, comment);
        }
    }
}

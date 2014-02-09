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

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    internal class SingleTaskCPUKernel : CPUKernel
    {
        private IList<Instruction> program;

        internal SingleTaskCPUKernel(IList<Instruction> program)
        {
            this.program = program;
        }


        internal override void Fetch()
        {
            try
            {
                Processor.CurrentInstruction = program[Processor.IP++];
            }
            catch (ArgumentOutOfRangeException)
            {
                Processor.ProcessorMode = ProcessorModes.Stopped;
            }
        }
    }
}

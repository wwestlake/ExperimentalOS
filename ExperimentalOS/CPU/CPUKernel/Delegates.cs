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

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Used to connect an instruction to the CPU Kernal code that executes the instruction
    /// </summary>
    /// <param name="instruction">The instruction being executed</param>
    public delegate void ExecuteInstruction(Instruction instruction);

    /// <summary>
    /// Represents a Task execution thread
    /// </summary>
    /// <param name="taskId"></param>
    public delegate void TaskCallBackFunction(Guid taskId);

}

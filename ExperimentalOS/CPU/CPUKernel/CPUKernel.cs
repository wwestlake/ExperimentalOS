using LagDaemon.ExperimentalOS.CPU.CPUHardware;
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using System;
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
    public class CPUKernel
    {

        /// <summary>
        /// Constructs a CPUKernel
        /// </summary>
        internal CPUKernel() { }

        internal void Nop(Instruction inst) { throw new NotImplementedException(); }
        internal void Load(Instruction inst) { throw new NotImplementedException(); }
        internal void Move(Instruction inst) { throw new NotImplementedException(); }
        internal void Pop(Instruction inst) { throw new NotImplementedException(); }
        internal void Push(Instruction inst) { throw new NotImplementedException(); }

        internal void In(Instruction inst) 
        {
            InInstruction inInst = inst as InInstruction;
            if (null == inInst) throw new CPUKernelException("Expected InInstruction but got: {0}", inst.GetType().FullName);
            IOPort port = Processor.Devices.Ports[ inInst.port ];
            Processor.Registers[inInst.r1] = port.Read();
        }
        
        internal void Out(Instruction inst) 
        {
            OutInstruction outInst = inst as OutInstruction;
            if (null == outInst) throw new CPUKernelException("Expected OutInstruction but got: {0}", inst.GetType().FullName);
            IOPort port = Processor.Devices.Ports[outInst.port];
            port.Write((byte)Processor.Registers[outInst.r1]);
        }

        internal void Jump(Instruction inst) { throw new NotImplementedException(); }
        internal void Call(Instruction inst) { throw new NotImplementedException(); }
        internal void Return(Instruction inst) { throw new NotImplementedException(); }
        internal void Add(Instruction inst) { throw new NotImplementedException(); }
        internal void Sub(Instruction inst) { throw new NotImplementedException(); }
        internal void Mul(Instruction inst) { throw new NotImplementedException(); }
        internal void Div(Instruction inst) { throw new NotImplementedException(); }
        internal void Inc(Instruction inst) { throw new NotImplementedException(); }
        internal void Dec(Instruction inst) { throw new NotImplementedException(); }
        internal void Compare(Instruction inst) { throw new NotImplementedException(); }
        internal void ClearCompare(Instruction inst) { throw new NotImplementedException(); }
        internal void JE(Instruction inst) { throw new NotImplementedException(); }
        internal void JNE(Instruction inst) { throw new NotImplementedException(); }
        internal void JGT(Instruction inst) { throw new NotImplementedException(); }
        internal void JLT(Instruction inst) { throw new NotImplementedException(); }
        internal void JZ(Instruction inst) { throw new NotImplementedException(); }
        internal void JNZ(Instruction inst) { throw new NotImplementedException(); }
        internal void Lock(Instruction inst) { throw new NotImplementedException(); }
        internal void Unlock(Instruction inst) { throw new NotImplementedException(); }
        internal void Sleep(Instruction inst) { throw new NotImplementedException(); }
        internal void SetPriority(Instruction inst) { throw new NotImplementedException(); }
        internal void AllocateMemory(Instruction inst) { throw new NotImplementedException(); }
        internal void FreeMemory(Instruction inst) { throw new NotImplementedException(); }
        internal void WaitOnEvent(Instruction inst) { throw new NotImplementedException(); }
        internal void FireEvent(Instruction inst) { throw new NotImplementedException(); }
        internal void MemoryClear(Instruction inst) { throw new NotImplementedException(); }
        internal void Terminate(Instruction inst) { throw new NotImplementedException(); }
        internal void BeginAtomicBlock(Instruction inst) { throw new NotImplementedException(); }
        internal void EndAtomicBlock(Instruction inst) { throw new NotImplementedException(); }
        internal void EnterMultitaskingMode(Instruction inst) { throw new NotImplementedException(); }


        internal Hardware.CPU Processor { get; set; }
    }
}

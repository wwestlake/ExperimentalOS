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
using LagDaemon.ExperimentalOS.CPU.CPUHardware;
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using System;
using Hardware = LagDaemon.ExperimentalOS.CPU.CPUHardware;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Represents the microcode side of the CPU for execution of instruction codes
    /// and handles CPU level memory management and task switching.
    /// </summary>
    public abstract class CPUKernel
    {

        /// <summary>
        /// Constructs a CPUKernel
        /// </summary>
        internal CPUKernel() 
        { 
        
        }

        internal T CastInstruction<T>(Instruction inst) where T: Instruction
        {
            T result = inst as T;
            if (null == inst) throw new CPUKernelException("Expected {0} but got: {1}", typeof(T).FullName, inst.GetType().FullName);
            return result;
        }

        internal void Nop(Instruction inst) 
        { 
            // nop 
        }

        internal void Load(Instruction inst) { throw new NotImplementedException(); }
        internal void Store(Instruction inst) { throw new NotImplementedException(); }
        internal void Move(Instruction inst) { throw new NotImplementedException(); }
        internal void Pop(Instruction inst) { throw new NotImplementedException(); }
        internal void Push(Instruction inst) { throw new NotImplementedException(); }

        internal void In(Instruction inst) 
        {
            InInstruction inInst = CastInstruction<InInstruction>(inst);
            IOPort port = Processor.Devices.Ports[ inInst.port ];
            Processor.Registers[inInst.r1] = port.Read();
        }
        
        internal void Out(Instruction inst) 
        {
            OutInstruction outInst = CastInstruction<OutInstruction>(inst);
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
        internal void Terminate(Instruction inst)
        {
            Processor.ProcessorMode = ProcessorModes.Stopped;
        }
        internal void BeginAtomicBlock(Instruction inst) { throw new NotImplementedException(); }
        internal void EndAtomicBlock(Instruction inst) { throw new NotImplementedException(); }
        internal void EnterMultitaskingMode(Instruction inst) { throw new NotImplementedException(); }

        internal Instruction Connect(Instruction inst)
        {
            switch (inst.Code)
            {
                case InstructionCodes.Add:
                    inst.Execute = Add;
                    break;
                case InstructionCodes.AllocateMemory:
                    inst.Execute = AllocateMemory;
                    break;
                case InstructionCodes.BeginAtomicBlock:
                    inst.Execute = BeginAtomicBlock;
                    break;
                case InstructionCodes.Call:
                    inst.Execute = Call;
                    break;
                case InstructionCodes.ClearCompare:
                    inst.Execute = ClearCompare;
                    break;
                case InstructionCodes.Compare:
                    inst.Execute = Compare;
                    break;
                case InstructionCodes.Dec:
                    inst.Execute = Dec;
                    break;
                case InstructionCodes.Div:
                    inst.Execute = Div;
                    break;
                case InstructionCodes.EndAtomicBlock:
                    inst.Execute = EndAtomicBlock;
                    break;
                case InstructionCodes.EnterMultitaskingMode:
                    inst.Execute = EnterMultitaskingMode;
                    break;
                case InstructionCodes.FireEvent:
                    inst.Execute = FireEvent;
                    break;
                case InstructionCodes.FreeMemory:
                    inst.Execute = FreeMemory;
                    break;
                case InstructionCodes.In:
                    inst.Execute = In;
                    break;
                case InstructionCodes.Inc:
                    inst.Execute = Inc;
                    break;
                case InstructionCodes.JE:
                    inst.Execute = JE;
                    break;
                case InstructionCodes.JGT:
                    inst.Execute = JGT;
                    break;
                case InstructionCodes.JLT:
                    inst.Execute = JLT;
                    break;
                case InstructionCodes.JNE:
                    inst.Execute = JNE;
                    break;
                case InstructionCodes.JNZ:
                    inst.Execute = JNZ;
                    break;
                case InstructionCodes.Jump:
                    inst.Execute = Jump;
                    break;
                case InstructionCodes.JZ:
                    inst.Execute = JZ;
                    break;
                case InstructionCodes.Load:
                    inst.Execute = Load;
                    break;
                case InstructionCodes.Lock:
                    inst.Execute = Lock;
                    break;
                case InstructionCodes.MemoryClear:
                    inst.Execute = MemoryClear;
                    break;
                case InstructionCodes.Move:
                    inst.Execute = Move;
                    break;
                case InstructionCodes.Mul:
                    inst.Execute = Mul;
                    break;
                case InstructionCodes.NOP:
                    inst.Execute = Nop;
                    break;
                case InstructionCodes.Out:
                    inst.Execute = Out;
                    break;
                case InstructionCodes.Pop:
                    inst.Execute = Pop;
                    break;
                case InstructionCodes.Push:
                    inst.Execute = Push;
                    break;
                case InstructionCodes.Return:
                    inst.Execute = Return;
                    break;
                case InstructionCodes.SetPriority:
                    inst.Execute = SetPriority;
                    break;
                case InstructionCodes.Sleep:
                    inst.Execute = Sleep;
                    break;
                case InstructionCodes.Store:
                    inst.Execute = Store;
                    break;
                case InstructionCodes.Sub:
                    inst.Execute = Sub;
                    break;
                case InstructionCodes.Terminate:
                    inst.Execute = Terminate;
                    break;
                case InstructionCodes.Unlock:
                    inst.Execute = Unlock;
                    break;
                case InstructionCodes.WaitOnEvent:
                    inst.Execute = WaitOnEvent;
                    break;

            }
            return inst;

        }


        internal Hardware.CPU Processor { get; set; }

        internal abstract void Fetch();

    }
}

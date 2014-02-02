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

using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    internal class ByteCodeLoader
    {
        private CPUKernel kernel;

        internal ByteCodeLoader(CPUKernel kernel) 
        {
            this.kernel = kernel;
        }

        internal IEnumerable<Instruction> ReadByteCode(byte[] buffer, int offset, int count)
        {
            int index = offset;
            Instruction result = null;
            while (index < count)
            {
                InstructionCodes code = (InstructionCodes)buffer[index];
                switch (code)
                {
                    case InstructionCodes.Add:
                        break;
                    case InstructionCodes.AllocateMemory:
                        break;
                    case InstructionCodes.BeginAtomicBlock:
                        break;
                    case InstructionCodes.Call:
                        break;
                    case InstructionCodes.Compare:
                        break;
                    case InstructionCodes.Dec:
                        break;
                    case InstructionCodes.Div:
                        break;
                    case InstructionCodes.EndAtomicBlock:
                        break;
                    case InstructionCodes.FireEvent:
                        break;
                    case InstructionCodes.FreeMemory:
                        break;
                    case InstructionCodes.In:
                        result = InstructionFactory.In(0, 0).Read(buffer, index);
                        result.Execute = kernel.In;
                        break;
                    case InstructionCodes.Inc:
                        break;
                    case InstructionCodes.JE:
                        break;
                    case InstructionCodes.JGT:
                        break;
                    case InstructionCodes.JLT:
                        break;
                    case InstructionCodes.JNE:
                        break;
                    case InstructionCodes.Jump:
                        result = InstructionFactory.Jump(0, 0).Read(buffer, index);
                        result.Execute = kernel.Jump;
                        break;
                    case InstructionCodes.Load:
                        result = InstructionFactory.Load(0, 0, 0, 0).Read(buffer, index);
                        result.Execute = kernel.Load;
                        break;
                    case InstructionCodes.Lock:
                        break;
                    case InstructionCodes.MemoryClear:
                        break;
                    case InstructionCodes.Move:
                        result = InstructionFactory.Move(0, 0).Read(buffer, index);
                        result.Execute = kernel.Move;
                        break;
                    case InstructionCodes.Mul:
                        break;
                    case InstructionCodes.NOP:
                        result = InstructionFactory.Nop().Read(buffer, index);
                        result.Execute = kernel.Nop;
                        break;
                    case InstructionCodes.Out:
                        result = InstructionFactory.Out(0, 0).Read(buffer, index);
                        result.Execute = kernel.Out;
                        break;
                    case InstructionCodes.Pop:
                        result = InstructionFactory.Pop(0).Read(buffer, index);
                        result.Execute = kernel.Pop;
                        break;
                    case InstructionCodes.Push:
                        result = InstructionFactory.Push(0).Read(buffer, index);
                        result.Execute = kernel.Push;
                        break;
                    case InstructionCodes.Return:
                        break;
                    case InstructionCodes.SetPriority:
                        break;
                    case InstructionCodes.Sleep:
                        break;
                    case InstructionCodes.Store:
                        break;
                    case InstructionCodes.Sub:
                        break;
                    case InstructionCodes.Terminate:
                        break;
                    case InstructionCodes.Unlock:
                        break;
                    case InstructionCodes.WaitOnEvent:
                        break;
                }
                index += result.Size;
                result.Address = index;
                yield return result;
            }
        }

    }
}

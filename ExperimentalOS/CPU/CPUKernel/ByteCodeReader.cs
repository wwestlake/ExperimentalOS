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
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    internal class ByteCodeReader
    {
        private CPUKernel kernel;
        private IInstructionFactory factory;

        internal ByteCodeReader(CPUKernel kernel) 
        {
            this.kernel = kernel;
            factory = new InstructionFactory(kernel);
        }

        internal IEnumerable<Instruction> Read(byte[] buffer, int offset, int count)
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
                        result = factory.Call(0, 0).Read(factory, buffer, index);
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
                        result = factory.In(0, 0).Read(factory, buffer, index);
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
                        result = factory.Jump(0, 0).Read(factory, buffer, index);
                        break;
                    case InstructionCodes.Load:
                        result = factory.Load(0, 0, 0, 0).Read(factory, buffer, index);
                        break;
                    case InstructionCodes.Lock:
                        break;
                    case InstructionCodes.MemoryClear:
                        break;
                    case InstructionCodes.Move:
                        result = factory.Move(0, 0).Read(factory, buffer, index);
                        break;
                    case InstructionCodes.Mul:
                        break;
                    case InstructionCodes.NOP:
                        result = factory.Nop().Read(factory, buffer, index);
                        break;
                    case InstructionCodes.Out:
                        result = factory.Out(0, 0).Read(factory, buffer, index);
                        break;
                    case InstructionCodes.Pop:
                        result = factory.Pop(0).Read(factory, buffer, index);
                        break;
                    case InstructionCodes.Push:
                        result = factory.Push(0).Read(factory, buffer, index);
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
                        result = factory.Terminate().Read(factory, buffer, index);
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

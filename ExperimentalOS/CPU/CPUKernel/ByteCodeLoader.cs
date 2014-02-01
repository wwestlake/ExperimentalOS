/*
    ExperimentalOS Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
  
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
        internal ByteCodeLoader() { }

        internal IEnumerable<Instruction> ReadByteCode(byte[] buffer, int offset, int count)
        {
            int index = offset;
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
                        break;
                    case InstructionCodes.Load:
                        Instruction load = InstructionFactory.Load(0, 0, 0, 0).Read(buffer, index);
                        index += load.Size;
                        yield return load;
                        break;
                    case InstructionCodes.Lock:
                        break;
                    case InstructionCodes.MemoryClear:
                        break;
                    case InstructionCodes.Move:
                        Instruction mov = InstructionFactory.Move(0, 0).Read(buffer, index);
                        index += mov.Size;
                        yield return mov;
                        break;
                    case InstructionCodes.Mul:
                        break;
                    case InstructionCodes.NOP:
                        Instruction nop = InstructionFactory.Nop().Read(buffer, index);
                        index += nop.Size;
                        yield return nop;
                        break;
                    case InstructionCodes.Out:
                        break;
                    case InstructionCodes.Pop:
                        break;
                    case InstructionCodes.Push:
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

            }
        }

    }
}

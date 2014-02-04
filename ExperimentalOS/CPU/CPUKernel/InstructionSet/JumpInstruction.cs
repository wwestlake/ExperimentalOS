using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
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

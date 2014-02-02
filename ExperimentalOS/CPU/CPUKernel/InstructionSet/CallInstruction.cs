using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    internal class CallInstruction : JumpBase
    {

        internal CallInstruction(int r1, uint address, string comment) : base(InstructionCodes.Call, r1, address, comment) { }

        internal CallInstruction(int r1, uint address) : base(InstructionCodes.Call, r1, address) { }



        protected override Instruction NewInstruction(int r1, uint address, string comment)
        {
            return new CallInstruction(r1, address, comment);
        }
    }
}

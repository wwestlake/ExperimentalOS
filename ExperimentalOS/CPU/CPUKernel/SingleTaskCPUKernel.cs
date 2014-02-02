using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    internal class SingleTaskCPUKernel : CPUKernel
    {
        private IList<Instruction> program;

        internal SingleTaskCPUKernel(IList<Instruction> program)
        {
            this.program = program;
        }

        internal SingleTaskCPUKernel(byte[] objectCode)
        {
            IList<Instruction> program = new List<Instruction>();
            ByteCodeReader reader = new ByteCodeReader(this);
            foreach (Instruction inst in reader.Read(objectCode, 0, objectCode.Length))
            {
                program.Add(inst);
            }
            this.program = program;
        }

        internal override void Fetch()
        {
            try
            {
                Processor.CurrentInstruction = program[Processor.IP++];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Processor.ProcessorMode = ProcessorModes.Stopped;
            }
        }
    }
}

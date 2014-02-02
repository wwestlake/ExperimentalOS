using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using System;

namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    internal class SingleTaskCPU : CPU
    {

        internal SingleTaskCPU(HardwareConfiguration config, CPUKernel.CPUKernel kernel) : base(config, kernel) { }


        public override void Start()
        {
            ProcessorMode = ProcessorModes.SingleTasking;
            while (ProcessorMode != ProcessorModes.Stopped)
            {
                CpuKernel.Fetch();
                ProcessInstruction();
            }
        }

        internal override void ProcessInstruction()
        {
            CurrentInstruction.Execute(CurrentInstruction);
            Console.WriteLine(CurrentInstruction);
        }
    }
}

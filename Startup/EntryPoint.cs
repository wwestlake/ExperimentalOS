using LagDaemon.ExperimentalOS.CPU.CPUHardware;
using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace LagDaemon.ExperimentalOS.Startup
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            IList<Instruction> program = new List<Instruction>();

            // boot loader will go here
            string assyProgram = @"
                NOP
                Load r33, 435 ; load some data
                Move r25, r33
                Terminate
            ";


            byte[] buffer = new byte[512];


            IStartable cpu = CPUFactory.Factory(new HardwareConfiguration(128)).CreateSingleTaskCPU(buffer);

            cpu.Start();

            Console.ReadKey();
        }
    }
}

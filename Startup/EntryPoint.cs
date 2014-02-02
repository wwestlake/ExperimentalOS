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
            program.Add(InstructionFactory.Nop());
            program.Add(InstructionFactory.Nop());
            program.Add(InstructionFactory.Nop());
            program.Add(InstructionFactory.Nop());
            program.Add(InstructionFactory.Nop());
            program.Add(InstructionFactory.Terminate());

            byte[] buffer = new byte[512];

            ByteCodeWriter writer = new ByteCodeWriter();
            writer.Write(buffer, 0, program);


            IStartable cpu = CPUFactory.Factory(new HardwareConfiguration(128)).CreateSingleTaskCPU(buffer);

            cpu.Start();

            Console.ReadKey();
        }
    }
}

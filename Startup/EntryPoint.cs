using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using System;
using System.Collections.Generic;


namespace LagDaemon.ExperimentalOS.Startup
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            string asmIn = "In r21, $44 ; this is an In instruction";
            Instruction InInstruction = InstructionFactory.In(0, 0).CreateInstruction(asmIn);

            Console.ReadKey();

        }
    }
}

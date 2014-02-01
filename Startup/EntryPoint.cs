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
            byte[] buffer = new byte[10];
            Instruction StoreInstruction = InstructionFactory.Store(0, 0, 0, 0);
            StoreInstruction.Write(buffer, 0);
            Instruction newStoreInst = StoreInstruction.Read(buffer, 0);
            if (StoreInstruction.Code != newStoreInst.Code)
            {
                Console.WriteLine("{0}  {1}", StoreInstruction.Code, newStoreInst.Code);
            }

            Console.ReadKey();

        }
    }
}

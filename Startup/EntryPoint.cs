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
            Console.WriteLine("sizeof(int) = {0}", sizeof(int));
            Console.WriteLine("sizeof(ulong) = {0}", sizeof(ulong));

            byte[] buffer = new byte[40];
            Instruction inst = InstructionFactory.Load(23, 44, 0, 17782, "This is a comment");
            Instruction nop = InstructionFactory.Nop();
            Instruction move = InstructionFactory.Move(1, 2);

            Console.WriteLine("{0} -- {1}", nop, nop.Size);
            Console.WriteLine("{0} -- {1}", move, move.Size);

            Console.WriteLine("{0} -- {1}", inst, inst.Size);

            Instruction another = inst.CreateInstruction("Load r21, -12988765   ; with a comment");

            Console.WriteLine("{0} -- {1}", another, another.Size);

            another.Write(buffer, 0);

            Instruction yetAnother = another.Read(buffer, 0);

            Console.WriteLine("{0} -- {1}", yetAnother, yetAnother.Size);

            List<Instruction> list = new List<Instruction>();
            list.Add(inst);
            list.Add(nop);
            list.Add(move);
            list.Add(another);
            list.Add(yetAnother);

            int offset = 0;
            foreach (Instruction ins in list)
            {
                ins.Write(buffer, offset);
                offset += ins.Size;
            }

            foreach (byte b in buffer)
            {
                Console.WriteLine("{0}", b);
            }


            Console.ReadKey();

        }
    }
}

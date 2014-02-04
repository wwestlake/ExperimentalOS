using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    internal class OutInstruction : Instruction
    {
        internal int r1;
        internal int port;

        internal OutInstruction(int r1, int port, string comment) : base(InstructionCodes.Out, comment)
        {
            this.r1 = r1;
            this.port = port;
            this.Size = 2 + sizeof(int);
        }

        internal OutInstruction(int r1, int port) : this(r1, port, string.Empty) {}

        protected override Instruction Assemble(IInstructionFactory factory, string assemblyLine)
        {
            string line = PreProcess(assemblyLine);
            Match m = CreateMatch(line, @"\s+r(?<r1>\d+)\s*,\s*\$(?<port>\d+)\s*[;]*(?<comment>[\s\S]*)");
            if (line.StartsWith(InstructionCodes.Out.ToString().ToLower()))
            {
                if (m.Success)
                {
                    return NewInstruction(factory, int.Parse(m.Groups["r1"].Value), int.Parse(m.Groups["port"].Value), m.Groups["comment"] != null ? m.Groups["comment"].Value : string.Empty);
                }
            }
            throw new InstructionParseException("Incorrect op code for this class: {0}, {1}", this.GetType().FullName, assemblyLine);
        }

        protected override string DisAssemble()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} r{1}, ${2}", Code, r1, port);
            return builder.ToString();
        }

        protected override int Emit(byte[] buffer, int offset)
        {
            byte[] portBytes = BitConverter.GetBytes(port);
            int index = offset;
            buffer[index++] = (byte)Code;
            buffer[index++] = (byte)r1;
            for (int i = 0; i < portBytes.Length; i++)
                buffer[index++] = portBytes[i];
            return 2;
        }

        protected override Instruction CreateFromBytes(IInstructionFactory factory, byte[] buffer, int offset)
        {
            int index = offset;
            InstructionCodes code = (InstructionCodes)buffer[index++];
            int r1 = (int)buffer[index++];
            int port = BitConverter.ToInt32(buffer, index);
            return NewInstruction(factory, r1, port, string.Empty);
        }

        protected Instruction NewInstruction(IInstructionFactory factory, int r1, int port, string comment)
        {
            return factory.Out(r1, port, comment);
        }
    }
}

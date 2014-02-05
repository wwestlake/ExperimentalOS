using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.Assembler
{
    internal abstract class Assembler
    {
        protected AssemblerFileReader reader;

        internal Assembler(AssemblerFileReader reader, CPUKernel kernel)
        {
            this.reader = reader;
            this.Kernel = kernel;
        }

        internal IEnumerable<Instruction> Program
        {
            get
            {
                foreach (string line in reader.Lines)
                {
                    yield return Assemble(line);
                }
            }
        }

        internal CPUKernel Kernel { get; private set; }

        protected abstract Instruction Assemble(string line);

    }
}

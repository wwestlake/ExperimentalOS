using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    public class CPUKernelFactory : ICPUKernelFactory
    {
        private static ICPUKernelFactory factory = null;
        private CPUModes mode;

        private CPUKernelFactory() 
        {
            this.mode = CPUModes.SingleTasking;
        }

        public ICPUKernelFactory Mode(CPUModes mode)
        {
            this.mode = mode;
            return this;
        }

        public CPUKernel CreateKernel(IList<Instruction> program)
        {
            switch (this.mode)
            {
                case CPUModes.MultiTasking: return null; break;
                case CPUModes.SingleTasking: return new SingleTaskCPUKernel(program);
            }
            return null;
        }

        public IInstructionFactory InstrucitnoFactory
        {
            get
            {
                return new InstructionFactory(KernelFactory.CreateKernel(null));
            }
        }

        public static ICPUKernelFactory KernelFactory  
        {
            get
            {
                if (null == factory) factory = new CPUKernelFactory();
                return factory;
            }
        }



    }
}

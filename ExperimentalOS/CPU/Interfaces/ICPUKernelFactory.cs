using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LagDaemon.ExperimentalOS.CPU.Interfaces
{
    public interface ICPUKernelFactory
    {
        ICPUKernelFactory Mode(CPUModes mode);
        CPUKernel.CPUKernel CreateKernel(IList<Instruction> program);
        IInstructionFactory InstrucitnoFactory { get; }
    }
}

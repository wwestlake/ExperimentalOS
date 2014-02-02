using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    /// <summary>
    /// Constructs various CPU configruations
    /// </summary>
    public class CPUFactory
    {

        internal CPUFactory(HardwareConfiguration config)
        {
            this.Configuration = config;
        }

        internal HardwareConfiguration Configuration { get; set; }

        /// <summary>
        /// Constructs a single task CPU and returns an IStartable interface
        /// </summary>
        /// <returns>IStartable</returns>
        public IStartable CreateSingleTaskCPU(IList<Instruction> program)
        {
            return new SingleTaskCPU(Configuration, new SingleTaskCPUKernel(program)) as IStartable;
        }

        public IStartable CreateSingleTaskCPU(byte[] objectCode)
        {
            return new SingleTaskCPU(Configuration, new SingleTaskCPUKernel(objectCode));
        }

        
        public static CPUFactory Factory(HardwareConfiguration config)
        {
            return new CPUFactory(config);
        }

    }
}

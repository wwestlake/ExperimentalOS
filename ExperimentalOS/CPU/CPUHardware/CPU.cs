
namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    /// <summary>
    /// Emulates a CPU with task switching, memory management, registers and instruction codes.
    /// </summary>
    public abstract class CPU
    {
        /// <summary>
        /// Shared between CPU threads to allow caching of instructions from OS level memory to CPU memory
        /// </summary>
        private uint[] _cache;

        /// <summary>
        /// The registers for this CPU
        /// </summary>
        private uint[] _registers;

        /// <summary>
        /// Holds the CPU level kernel
        /// </summary>
        private uint[] _cpuMemory;


        private CPUKernel.CPUKernel _cpuKernel;

        /// <summary>
        /// Constructis a CPU
        /// </summary>
        /// <param name="cpuKernel">The Kernel for this CPU</param>
        public CPU(CPUKernel.CPUKernel cpuKernel)
        {
            this._cpuKernel = cpuKernel;
        }

    }
}

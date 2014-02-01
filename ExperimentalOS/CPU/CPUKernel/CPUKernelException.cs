using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// A CPUKernel Exception is thrown in the CPU Kernel code when ever a condition is encountered
    /// that will prevent the correct operation of the CPU Kernel.  In some cases they may be caught and recovered.
    /// </summary>
    public class CPUKernelException : ApplicationException
    {
        /// <summary>
        /// Create a CPUKernelException from a string message
        /// </summary>
        /// <param name="message">The Message</param>
        public CPUKernelException(string message) : base(message) { }

        /// <summary>
        /// Create a CPUKernelMessage from a format string and arguments
        /// </summary>
        /// <param name="format">Format String</param>
        /// <param name="args">Arguments</param>
        public CPUKernelException(string format, params object[] args) : base(string.Format(format, args)) { }
    }
}

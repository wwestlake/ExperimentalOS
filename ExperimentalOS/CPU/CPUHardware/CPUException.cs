using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    /// <summary>
    /// Thrown by the CPU when an error occurs
    /// </summary>
    public class CPUException : ApplicationException
    {
        /// <summary>
        /// Constuct a CPUException with message
        /// </summary>
        /// <param name="message">The Message</param>
        public CPUException(string message) : base(message) { }

        /// <summary>
        /// Construct a CPUException with format and arguments
        /// </summary>
        /// <param name="format">Format string</param>
        /// <param name="args">Argmuments</param>
        public CPUException(string format, params object[] args) : this(string.Format(format, args)) { }
    }
}

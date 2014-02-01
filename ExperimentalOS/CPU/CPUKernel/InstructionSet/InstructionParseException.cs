using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// This exception is thrown whenever the assembly routines run into an error in the 
    /// format of the instructions
    /// </summary>
    public class InstructionParseException : ApplicationException
    {
        /// <summary>
        /// Constructs an InstructionParseException from a string
        /// </summary>
        /// <param name="message">The error message</param>
        public InstructionParseException(string message) : base(message) { }

        /// <summary>
        /// Constructs an InstructionParseException from a format string and array of arguments
        /// </summary>
        /// <param name="format">The format string</param>
        /// <param name="args">The arguments</param>
        public InstructionParseException(string format, params object[] args) : base(string.Format(format, args)) {}
    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Special symbols used to control instruction code operations
    /// </summary>
    public static class Symbols
    {
        /// <summary>
        /// Designates an address that is not valid.  This is for absolute addresses only, a relative address of -1 is computed against
        /// an absolute address to obtain another absolute address.
        /// </summary>
        public static int NullAddress { get { return 0; } }

        /// <summary>
        /// Designates that no register is specified.  In some instances this may result in the CPUKernel or OSKernal selecting an unused register.
        /// </summary>
        public static int NullRegister { get { return -1; } }
       
    }
}

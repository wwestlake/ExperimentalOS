using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Addressing modes supported by instructions that use addresses.
    /// </summary>
    public enum AddressingMode { 

        /// <summary>
        /// Direct addressing is where an address appears in memory imediately following the instruction code
        /// </summary>
        Direct = 1, 

        /// <summary>
        /// Indirect addressing is where a register contains the address to use
        /// </summary>
        Indirect = 2, 

        /// <summary>
        /// Indexed addressing is where an address appears imediately following the instruction code and a register 
        /// indexes to some point beyond that address.
        /// </summary>
        /// 
        Indexed = 3,

        /// <summary>
        /// This is where two registers are used to compute the final address, one contains the address the other indexes into
        /// memory.
        /// </summary>
        IndexedInderect = 4,

        /// <summary>
        /// Imediate takes an operand imediately following the op code
        /// </summary>
        Imediate = 5

    }
}

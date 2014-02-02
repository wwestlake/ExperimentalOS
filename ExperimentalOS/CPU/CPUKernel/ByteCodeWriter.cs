using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Writes out raw byte code
    /// </summary>
    public class ByteCodeWriter
    {

        /// <summary>
        /// Constructs a ByteCodeReader
        /// </summary>
        public ByteCodeWriter() { }


        /// <summary>
        /// Write the byte code to the buffer
        /// </summary>
        /// <param name="buffer">Buffer to write to</param>
        /// <param name="offset">Index into buffer to start writing</param>
        /// <param name="program">The program to write</param>
        /// <returns>count of bytes written</returns>
        public int Write(byte[] buffer, int offset, IEnumerable<Instruction> program)
        {
            int index = 0;
            foreach (Instruction inst in program)
                index += inst.Write(buffer, index);
            return index;
        }
    }
}

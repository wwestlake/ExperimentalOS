/*
    ExperimentalOS Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
    
    source code: https://github.com/wwestlake/ExperimentalOS.git 
  
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System.Collections.Generic;

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

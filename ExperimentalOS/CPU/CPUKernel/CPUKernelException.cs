/*
    ExperimentalOS Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
  
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

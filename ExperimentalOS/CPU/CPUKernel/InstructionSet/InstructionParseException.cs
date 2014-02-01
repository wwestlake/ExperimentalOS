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

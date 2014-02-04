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

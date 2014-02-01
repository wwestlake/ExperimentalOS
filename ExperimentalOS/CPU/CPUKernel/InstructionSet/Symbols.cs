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

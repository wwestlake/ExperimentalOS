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
using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System.Collections.Generic;

namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    /// <summary>
    /// Constructs various CPU configruations
    /// </summary>
    public class CPUFactory
    {

        internal CPUFactory(HardwareConfiguration config)
        {
            this.Configuration = config;
        }

        internal HardwareConfiguration Configuration { get; set; }

        /// <summary>
        /// Constructs a single task CPU and returns an IStartable interface
        /// </summary>
        /// <returns>IStartable</returns>
        public IStartable CreateSingleTaskCPU(IList<Instruction> program)
        {
            return new SingleTaskCPU(Configuration, new SingleTaskCPUKernel(program)) as IStartable;
        }


        /// <summary>
        /// Produces a CPU factory
        /// </summary>
        /// <param name="config">The configuaration of this CPU</param>
        /// <returns>A CPUFactory</returns>
        public static CPUFactory Factory(HardwareConfiguration config)
        {
            return new CPUFactory(config);
        }

    }
}

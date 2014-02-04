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

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Comparison flags for CPU
    /// </summary>
    public enum ComparisonFlags { 
        /// <summary>
        /// Flag has no meaning, will cause a ProcessorException on any conditional jump instruction
        /// </summary>
        Cleared,
 
        /// <summary>
        /// Last compare was a less than condition
        /// </summary>
        LessThan,
 
        /// <summary>
        /// Last compare was a greater than condition
        /// </summary>
        GreateThan,
 
        /// <summary>
        /// Last compare was an equal condition
        /// </summary>
        Equal 
    }

    /// <summary>
    /// Processor modes
    /// </summary>
    public enum ProcessorModes { 

        /// <summary>
        /// CPU is not runnint
        /// </summary>
        Stopped,
 
        /// <summary>
        /// CPU is operating in SingleTasking mode
        /// </summary>
        SingleTasking, 

        /// <summary>
        /// CPU is operating in multitasking mode
        /// </summary>
        MultiTasking,
 
        /// <summary>
        /// CPU is in an exception state trying to recover if possible before entering stopped state
        /// </summary>
        Exception 
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

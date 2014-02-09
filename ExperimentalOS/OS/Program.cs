using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.OS
{
    /// <summary>
    /// Represents an executable program with meta data describing the program
    /// </summary>
    [Serializable]
    public class Program
    {
        /// <summary>
        /// Constructs a program
        /// </summary>
        /// <param name="name">The name of the program</param>
        public Program(string name) { this.Name = name; }

        /// <summary>
        /// Gets or Sets the program Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets or Sets the program Mode
        /// </summary>
        public CPUModes Mode { get; internal set; }

        /// <summary>
        /// Gets or sets the Code for this program
        /// </summary>
        public IList<Instruction> Code { get; internal set; }

        /// <summary>
        /// Gets or sets the Symbols for this program
        /// </summary>
        public SymbolTable Symbols { get; internal set; }

        /// <summary>
        /// Gets or sets the Symbol Cache for this program
        /// </summary>
        public SymbolCache SymbolCache { get; internal set; }

        /// <summary>
        /// Gets or sets the Author of this program
        /// </summary>
        public string Author { get; internal set; }

        /// <summary>
        /// Gets or sets the Copyright for this program
        /// </summary>
        public string Copyright { get; internal set; }

        /// <summary>
        /// Gets or sets the Version of this program
        /// </summary>
        public Version Version { get; internal set; }
    }
}

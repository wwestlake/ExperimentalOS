using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using LagDaemon.ExperimentalOS.OS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// A SymbolTable is a look up table and cross reference for Symbols that have been assigned an address.
    /// </summary>
    public class SymbolTable
    {

        private Dictionary<uint, string> symbolsByAddress = new Dictionary<uint, string>();
        private Dictionary<string, uint> addressBySymbol = new Dictionary<string, uint>();

        /// <summary>
        /// Constructs a SymbolTable for the specified scope
        /// </summary>
        /// <param name="scope">The Scope of this SymbolTable</param>
        public SymbolTable(string scope) 
        {
            this.Scope = scope;
        }


        private void Add(string symbol, uint address)
        {
            if (symbol.Length > Settings.MaximumSymbolLength) throw new CPUKernelException("Symbol length exceeds maximum of {0} bytes: {1}", Settings.MaximumSymbolLength, symbol);
            if (!symbolsByAddress.ContainsKey(address)) symbolsByAddress.Add(address, symbol);
            if (!addressBySymbol.ContainsKey(symbol)) addressBySymbol.Add(symbol, address);
        }
        

        /// <summary>
        /// Produces the Symbol for the specified address (reverse lookup)
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>The Symbol</returns>
        public string this[uint address]
        {
            get
            {
                if (symbolsByAddress.ContainsKey(address))
                {
                    return symbolsByAddress[address];
                }
                return string.Empty;
            }

            set
            {
                Add(value, address); 
            }
        }

        /// <summary>
        /// Produces an address for a given symbol
        /// </summary>
        /// <param name="symbol">The Symbol</param>
        /// <returns>The address</returns>
        public uint this[string symbol]
        {
            get
            {
                if (addressBySymbol.ContainsKey(symbol))
                {
                    return addressBySymbol[symbol];
                }
                return (uint)Symbols.NullAddress;
            }
            set
            {
                Add(symbol, value);
            }
        }

        /// <summary>
        /// The Scope of this SymbolTable
        /// </summary>
        public string Scope { get; set; }

    }
}

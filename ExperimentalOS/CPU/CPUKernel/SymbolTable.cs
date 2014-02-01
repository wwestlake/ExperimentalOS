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

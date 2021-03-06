﻿/*
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

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// The SymbolCache is used to store symbols found and the location where an address
    /// needs to be place, but prior to the symbol being defined.  Once the symbol is defined the
    /// SymbolCache is checked to find all location where the address needs to be placed.
    /// </summary>
    public class SymbolCache
    {

        
        private Dictionary<string, List<uint>> symbolCache = new Dictionary<string, List<uint>>();

        /// <summary>
        /// Construct a SymbolCache for the specified scope
        /// </summary>
        /// <param name="scope">The scope of this SymbolCacne</param>
        public SymbolCache(string scope)
        {
            this.Scope = scope;
        }

        /// <summary>
        /// Adds a Symbol and address to the Cache creating the list of addresses 
        /// if this this the first time the symbol is added. 
        /// </summary>
        /// <param name="symbol">The symbol to add and address for</param>
        /// <param name="address">The address where the symbol resides</param>
        public void Add(string symbol, uint address)
        {
            if (! symbolCache.ContainsKey(symbol))
            {
                symbolCache.Add(symbol, new List<uint>());
            }
            symbolCache[symbol].Add(address);
        }


        /// <summary>
        /// Produces and Emumeration of all addresses in this scope that are 
        /// associated with the supplied symbol
        /// </summary>
        /// <param name="symbol">The symbol for this scope</param>
        /// <returns>An enumeration of all addresses for this symbol</returns>
        public IEnumerable<uint> this[string symbol]
        {
            get
            {
                if (!symbolCache.ContainsKey(symbol)) throw new CPUKernelException("Symbol not found in SymbolCache: {0} for Scope {1}", symbol, Scope);
                foreach (uint address in symbolCache[symbol])
                {
                    yield return address;
                }
            }
        }

        /// <summary>
        /// The Scope of this SymbolCache
        /// </summary>
        public string Scope { get; set; }
    }
}

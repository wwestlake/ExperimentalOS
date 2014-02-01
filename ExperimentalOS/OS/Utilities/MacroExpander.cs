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
using System.Text.RegularExpressions;

namespace LagDaemon.ExperimentalOS.OS.Utilities
{
    /// <summary>
    /// Expands Macros used in Assembly Files
    /// <remarks>This routine is experimental and may not be implemented in release</remarks>
    /// </summary>
    public class MacroExpander
    {
        private MacroSubstitutor substituter;

        /// <summary>
        /// Parses and expands a macro that had a definition of the for define MyMacro(args) = now is the {0} for all good {1} to come to the aid of their {2}
        /// such that MyMacro(time, men, country) expands to "now is the time for all good men to come to the aid of their country
        /// </summary>
        public MacroExpander()
        {
            this.substituter = new MacroSubstitutor();
        }


        /// <summary>
        /// Add a Macro to the expander
        /// </summary>
        /// <param name="macro">The Macro to add</param>
        public void AddMacro(string macro)
        {
            
            string[] halves = macro.Split('=');
            if (halves.Length != 2) throw new ApplicationException(string.Format("Invalid Macro Definition: {0}", macro));
            string left = halves[0];
            string right = halves[1];

            left = left.Trim();
            if (left.StartsWith("define"))
            {
                string[] leftSide = left.Split(new char[] {' '}, 1);  // 
                left = leftSide[1];
            }

            right = right.Trim();

        }

    }
}

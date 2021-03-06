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

namespace LagDaemon.ExperimentalOS.OS.Utilities
{
    /// <summary>
    /// Helper class for accessing the configuration settings
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Get the setting for Maximum Symbol Length
        /// </summary>
        public static int MaximumSymbolLength
        {
            get
            {
                return int.Parse(System.Configuration.ConfigurationManager.AppSettings["MAX_SYMBOL_LENGTH"]);
            }
        }

        public static int NumberOfRegisters
        {
            get
            {
                return int.Parse(System.Configuration.ConfigurationManager.AppSettings["REGISTERS"]);
            }
        }

    }
}

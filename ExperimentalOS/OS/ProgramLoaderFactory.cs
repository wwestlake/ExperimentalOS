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

using LagDaemon.ExperimentalOS.OS.Interfaces;
using System;
using System.Collections.Generic;

namespace LagDaemon.ExperimentalOS.OS
{
    /// <summary>
    /// Produces a program loader singleton
    /// </summary>
    public static class ProgramLoaderFactory
    {
        private static IProgramLoader loader = null;


        /// <summary>
        /// Gets the ProgramLoader singleton
        /// </summary>
        public static IProgramLoader Loader
        {
            get
            {
                if (null == loader) loader = new ProgramLoader();
                return loader;
            }
        }
    }
}

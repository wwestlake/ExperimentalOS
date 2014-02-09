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
using System.IO;

namespace LagDaemon.ExperimentalOS.OS.Interfaces
{
    /// <summary>
    /// Represents a program loader
    /// </summary>
    public interface IProgramLoader
    {
        /// <summary>
        /// Load a program from a stream using the serialization mode
        /// </summary>
        /// <param name="stream">The stream to load from</param>
        /// <returns>A program from the stream</returns>
        Program LoadProgram(FileStream stream);

        /// <summary>
        /// Saves a program to the stream using the specified serialization mode
        /// </summary>
        /// <param name="program">The program to save</param>
        /// <param name="stream">The stream to save to</param>
        void SaveProgram(Program program, FileStream stream);

        /// <summary>
        /// The serialization mode to use
        /// </summary>
        /// <param name="mode">The serialization mode</param>
        /// <returns>IProgramLoader interface</returns>
        IProgramLoader Mode(SerializationModes mode);

    }
}

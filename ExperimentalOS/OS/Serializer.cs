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
using System.IO;

namespace LagDaemon.ExperimentalOS.OS
{
    /// <summary>
    /// Abstract class representing a Serializert
    /// </summary>
    public abstract class Serializer : ISerializer
    {
        /// <summary>
        /// The serialization stream
        /// </summary>
        protected Stream stream;

        /// <summary>
        /// Constructs a serializer for this stream
        /// </summary>
        /// <param name="stream">The stream to serialize</param>
        public Serializer(Stream stream) { }

        /// <summary>
        /// Serialize to the stream based on serialization mode
        /// </summary>
        /// <typeparam name="T">The type of object ot serialize</typeparam>
        /// <param name="obj">The object to serialize</param>
        public abstract void Serialize<T>(T obj);

        /// <summary>
        /// Deserialize from the stream
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize</typeparam>
        /// <returns>The desierialized object</returns>
        public abstract T Deserialize<T>();
    }
}

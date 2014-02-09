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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace LagDaemon.ExperimentalOS.OS
{
    /// <summary>
    /// Class representing a Soap Serializer
    /// </summary>
    public class SoapSerializer : Serializer
    {
        /// <summary>
        /// Constructs a SoapSerializer
        /// </summary>
        /// <param name="stream">The stream to serialize</param>
        public SoapSerializer(Stream stream) : base(stream) { }


        /// <summary>
        /// Serialize an object to the stream
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="obj">The object to serialize</param>
        public override void Serialize<T>(T obj)
        {
            IFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, obj);
        }


        /// <summary>
        /// Deserialize an object from the stream
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize</typeparam>
        /// <returns>The deserialized object</returns>
        public override T Deserialize<T>()
        {
            IFormatter formatter = new SoapFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }
}

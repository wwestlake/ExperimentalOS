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
using LagDaemon.ExperimentalOS.Assembler.Interfaces;
using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using System;
using System.IO;

namespace LagDaemon.ExperimentalOS.Assembler
{
    public class AssemblerFactory : IAssemblerFactory
    {
        private static AssemblerFactory factory = null;

        private CPUModes mode = CPUModes.SingleTasking;

        private AssemblerFactory() { }

        /// <summary>
        /// Set the mode of this factory to any of the CPUModes available
        /// </summary>
        /// <param name="mode">The CPU Mode</param>
        /// <returns>this factory with the mode set</returns>
        public IAssemblerFactory Mode(CPU.CPUKernel.CPUModes mode)
        {
            this.mode = mode;
            return this;
        }

        /// <summary>
        /// Create an assembler based on the type of CPU and Kernel that the code will
        /// execute on.
        /// </summary>
        /// <param name="program">A program as a string</param>
        /// <returns>An IAssembler interface on the appropriate assembler implementation</returns>
        public IAssembler CreateAssembler(string program)
        {
            switch (mode)
            {
                case CPUModes.SingleTasking:
                    return new SingleTaskingAssembler(new AssemblerFileReader(program), CPUKernelFactory.Factory.Mode(mode).CreateKernel(null));

                case CPUModes.MultiTasking:
                    break;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create an assembler from a file
        /// </summary>
        /// <param name="file">the FileStream containing the code</param>
        /// <returns></returns>
        public IAssembler CreateAssembler(FileStream file)
        {
            AssemblerFileReader reader = new AssemblerFileReader(file);
            return CreateAssembler(reader.ToString());
        }

        public static IAssemblerFactory Factory
        {
            get
            {
                if (null == factory) factory = new AssemblerFactory();
                return factory;
            }
        }

    }
}

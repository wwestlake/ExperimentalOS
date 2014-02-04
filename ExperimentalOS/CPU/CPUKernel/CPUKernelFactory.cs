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
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System.Collections.Generic;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    public class CPUKernelFactory : ICPUKernelFactory
    {
        private static ICPUKernelFactory factory = null;
        private CPUModes mode;

        private CPUKernelFactory() 
        {
            this.mode = CPUModes.SingleTasking;
        }

        public ICPUKernelFactory Mode(CPUModes mode)
        {
            this.mode = mode;
            return this;
        }

        public CPUKernel CreateKernel(IList<Instruction> program)
        {
            switch (this.mode)
            {
                case CPUModes.MultiTasking: return null; break;
                case CPUModes.SingleTasking: return new SingleTaskCPUKernel(program);
            }
            return null;
        }

        public IInstructionFactory InstrucitnoFactory
        {
            get
            {
                return new InstructionFactory(KernelFactory.CreateKernel(null));
            }
        }

        public static ICPUKernelFactory KernelFactory  
        {
            get
            {
                if (null == factory) factory = new CPUKernelFactory();
                return factory;
            }
        }



    }
}

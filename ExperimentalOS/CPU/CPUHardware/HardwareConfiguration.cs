using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    public class HardwareConfiguration
    {
        public HardwareConfiguration(int registers)
        {
            this.Registers = registers;
        }

        public int Registers { get; internal set; }

    }
}

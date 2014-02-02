using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.CPU.CPUHardware
{
    internal abstract class IOPort
    {
        internal IOPort() { }

        internal abstract byte Read();

        internal abstract void Write(byte b);

    }
}

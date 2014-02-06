using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LagDaemon.ExperimentalOS.Assembler
{
    public class ParseException : ApplicationException
    {
        public ParseException(string message) : base(message) { }

        public ParseException(string format, params object[] args) : this(string.Format(format, args)) { }
    }
}

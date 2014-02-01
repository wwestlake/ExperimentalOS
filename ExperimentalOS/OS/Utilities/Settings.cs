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
    }
}

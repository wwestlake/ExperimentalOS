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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.ExperimentalOS.Assembler
{
    public class AssemblerFileReader
    {
        string contents;
        List<string> programLines = new List<string>();

        public AssemblerFileReader(FileStream file)
        {
            TextReader reader = new StreamReader(file);
            contents = reader.ReadToEnd();
            Init();
        }

        public AssemblerFileReader(string contents)
        {
            this.contents = contents;
            Init();
        }

        private void Init()
        {
            string[] lines = contents.Split(new char[] { '\n' });
            foreach (string line in lines)
            {
                string l = line.Trim();
                if (l.Length > 0)
                    programLines.Add(l);
            }
        }





        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string line in programLines) { builder.Append(line); builder.Append("\n"); }
            return builder.ToString();
        }



    }
}

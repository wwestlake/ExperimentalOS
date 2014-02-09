﻿/*
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
using LagDaemon.ExperimentalOS.Assembler;
using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using System;
using System.Collections.Generic;
using System.IO;


namespace LagDaemon.ExperimentalOS.Startup
{
    class EntryPoint
    {
        static FileStream file;
        static AssemblerFileReader fileReader;

        static void Main(string[] args)
        {
            file = new FileStream("TestFile.asm", FileMode.Open, FileAccess.Read);
            foreach (Instruction inst in AssemblerFactory.Factory.Mode(CPUModes.SingleTasking).CreateAssembler(file).Program)
            {
            }

            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
        }
    }
}

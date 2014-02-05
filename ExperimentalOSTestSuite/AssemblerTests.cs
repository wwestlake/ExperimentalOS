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
using NUnit.Framework;
using LagDaemon.ExperimentalOS.Assembler;
using System.Collections.Generic;

namespace ExperimentalOSTestSuite
{
    [TestFixture(Category = "Assembler Tests",
    Description = "Test the operation of the assembler")]
    public class AssemblerTests
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void AssemblerFileReaderLoadsFile()
        {
            AssemblerFileReader fileReader;
            fileReader = new AssemblerFileReader("TestFile.asm");
            int i = 0;
            foreach (string line in fileReader.Lines) i++;
            Assert.That(i > 0);
        }


    }
}

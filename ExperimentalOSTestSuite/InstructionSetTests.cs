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
using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;
using LagDaemon.ExperimentalOS.CPU.Interfaces;

namespace ExperimentalOSTestSuite
{
    [TestFixture(Category="Kernel Tests", 
        Description="Basic Instruction Object Tests not executing instructions in CPUKernel")]
    public class InstructionSetTests
    {
        IInstructionFactory instFactory;

        [SetUp]
        public void SetUp()
        {
            instFactory = CPUKernelFactory.Factory.Mode(CPUModes.SingleTasking).InstrucitnoFactory;
        }


        // Nop Tests

        [Test]
        public void NopInstructionIsCreated()
        {
            Instruction nopInstruction = instFactory.Nop();
            Assert.AreEqual(nopInstruction.Code, InstructionCodes.NOP);
        }

        [Test]
        public void NopInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "NOP ; this is a NOP instruction";
            Instruction nopInstruction = instFactory.Nop().CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(nopInstruction.Code, InstructionCodes.NOP);
            string asmOut = nopInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("NOP"));
            Assert.IsTrue(asmOut.StartsWith("NOP"));
        }

 
        // Move Tests

        [Test]
        public void MoveInstructionIsCreated()
        {
            Instruction MoveInstruction = instFactory.Move(0, 0);
            Assert.AreEqual(MoveInstruction.Code, InstructionCodes.Move);
        }

        [Test]
        public void MoveInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Move r21, r22 ; this is a Move instruction";
            Instruction MoveInstruction = instFactory.Move(1, 2).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(MoveInstruction.Code, InstructionCodes.Move);
            string asmOut = MoveInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Move r21, r22"));
            Assert.IsTrue(asmOut.StartsWith("Move r21, r22"));
        }


        // Load Tests

        [Test]
        public void LoadInstructionIsCreated()
        {
            Instruction LoadInstruction = instFactory.Load(0, 0, 0, 0);
            Assert.AreEqual(LoadInstruction.Code, InstructionCodes.Load);
        }

        [Test]
        public void LoadInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Load r21, r22, $943567 ; this is a Load instruction";
            Instruction LoadInstruction = instFactory.Load(0, 0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(LoadInstruction.Code, InstructionCodes.Load);
            string asmOut = LoadInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Load r21, r22, $943567"));
            Assert.IsTrue(asmOut.StartsWith("Load r21, r22, $943567"));
        }


        // Store Tests

        [Test]
        public void StoreInstructionIsCreated()
        {
            Instruction StoreInstruction = instFactory.Store(0, 0, 0, 0);
            Assert.AreEqual(StoreInstruction.Code, InstructionCodes.Store);
        }

        [Test]
        public void StoreInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Store r21, r22, $943567 ; this is a Store instruction";
            Instruction StoreInstruction = instFactory.Store(0, 0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(StoreInstruction.Code, InstructionCodes.Store);
            string asmOut = StoreInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Store r21, r22, $943567"));
            Assert.IsTrue(asmOut.StartsWith("Store r21, r22, $943567"));
        }


        // Push Tests

        [Test]
        public void PushInstructionIsCreated()
        {
            Instruction PushInstruction = instFactory.Push(0);
            Assert.AreEqual(PushInstruction.Code, InstructionCodes.Push);
        }

        [Test]
        public void PushInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Push r21 ; this is a Push instruction";
            Instruction PushInstruction = instFactory.Push(0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(PushInstruction.Code, InstructionCodes.Push);
            string asmOut = PushInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Push r21"));
            Assert.IsTrue(asmOut.StartsWith("Push r21"));
        }


        // Pop Tests

        [Test]
        public void PopInstructionIsCreated()
        {
            Instruction PopInstruction = instFactory.Pop(0);
            Assert.AreEqual(PopInstruction.Code, InstructionCodes.Pop);
        }

        [Test]
        public void PopInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Pop r21 ; this is a Pop instruction";
            Instruction PopInstruction = instFactory.Pop(0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(PopInstruction.Code, InstructionCodes.Pop);
            string asmOut = PopInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Pop r21"));
            Assert.IsTrue(asmOut.StartsWith("Pop r21"));
        }



        // In Tests

        [Test]
        public void InInstructionIsCreated()
        {
            Instruction InInstruction = instFactory.In(0, 0);
            Assert.AreEqual(InInstruction.Code, InstructionCodes.In);
        }

        [Test]
        public void InInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "In r21, $44 ; this is an In instruction";
            Instruction InInstruction = instFactory.In(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(InInstruction.Code, InstructionCodes.In);
            string asmOut = InInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("In r21, $44"));
            Assert.IsTrue(asmOut.StartsWith("In r21, $44"));
        }


        // Out Tests

        [Test]
        public void OutInstructionIsCreated()
        {
            Instruction OutInstruction = instFactory.Out(0, 0);
            Assert.AreEqual(OutInstruction.Code, InstructionCodes.Out);
        }

        [Test]
        public void OutInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Out r21, $44 ; this is an Out instruction";
            Instruction OutInstruction = instFactory.Out(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(OutInstruction.Code, InstructionCodes.Out);
            string asmOut = OutInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Out r21, $44"));
            Assert.IsTrue(asmOut.StartsWith("Out r21, $44"));
        }


        // Jump Tests

        [Test]
        public void JumpInstructionIsCreated()
        {
            Instruction JumpInstruction = instFactory.Jump(0, 0);
            Assert.AreEqual(JumpInstruction.Code, InstructionCodes.Jump);
        }

        [Test]
        public void JumpInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Jump r21, $44 ; this is an Out instruction";
            Instruction JumpInstruction = instFactory.Jump(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(JumpInstruction.Code, InstructionCodes.Jump);
            string asmOut = JumpInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Jump r21, $44"));
            Assert.IsTrue(asmOut.StartsWith("Jump r21, $44"));
        }


        // Call Tests

        [Test]
        public void CallInstructionIsCreated()
        {
            Instruction CallInstruction = instFactory.Call(0, 0);
            Assert.AreEqual(CallInstruction.Code, InstructionCodes.Call);
        }

        [Test]
        public void CallInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Call r21, $44 ; this is a Call instruction";
            Instruction CallInstruction = instFactory.Call(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(CallInstruction.Code, InstructionCodes.Call);
            string asmOut = CallInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Call r21, $44"));
            Assert.IsTrue(asmOut.StartsWith("Call r21, $44"));
        }


        // Terminate Tests

        [Test]
        public void TerminateInstructionIsCreated()
        {
            Instruction TerminateInstruction = instFactory.Terminate();
            Assert.AreEqual(TerminateInstruction.Code, InstructionCodes.Terminate);
        }

        [Test]
        public void TerminateInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Terminate ; this is a Terminate instruction";
            Instruction TerminateInstruction = instFactory.Terminate().CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(TerminateInstruction.Code, InstructionCodes.Terminate);
            string asmOut = TerminateInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Terminate"));
            Assert.IsTrue(asmOut.StartsWith("Terminate"));
        }

        // Add Tests

        [Test]
        public void AddInstructionIsCreated()
        {
            Instruction AddInstruction = instFactory.Add(0,0,0);
            Assert.AreEqual(AddInstruction.Code, InstructionCodes.Add);
        }

        [Test]
        public void AddInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Add r1, r2, r3 ; this is a Add instruction";
            Instruction AddInstruction = instFactory.Add(0,0,0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(AddInstruction.Code, InstructionCodes.Add);
            string asmOut = AddInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Add"));
            Assert.IsTrue(asmOut.StartsWith("Add"));
        }

        // Sub Tests

        [Test]
        public void SubInstructionIsCreated()
        {
            Instruction SubInstruction = instFactory.Sub(0, 0, 0);
            Assert.AreEqual(SubInstruction.Code, InstructionCodes.Sub);
        }

        [Test]
        public void SubInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Sub r1, r2, r3 ; this is a Sub instruction";
            Instruction SubInstruction = instFactory.Sub(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(SubInstruction.Code, InstructionCodes.Sub);
            string asmOut = SubInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Sub"));
            Assert.IsTrue(asmOut.StartsWith("Sub"));
        }

        // Mul Tests

        [Test]
        public void MulInstructionIsCreated()
        {
            Instruction MulInstruction = instFactory.Mul(0, 0, 0);
            Assert.AreEqual(MulInstruction.Code, InstructionCodes.Mul);
        }

        [Test]
        public void MulInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Mul r1, r2, r3 ; this is a Mul instruction";
            Instruction MulInstruction = instFactory.Mul(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(MulInstruction.Code, InstructionCodes.Mul);
            string asmOut = MulInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Mul"));
            Assert.IsTrue(asmOut.StartsWith("Mul"));
        }

        // Div Tests

        [Test]
        public void DivInstructionIsCreated()
        {
            Instruction DivInstruction = instFactory.Div(0, 0, 0);
            Assert.AreEqual(DivInstruction.Code, InstructionCodes.Div);
        }

        [Test]
        public void DivInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Div r1, r2, r3 ; this is a Div instruction";
            Instruction DivInstruction = instFactory.Div(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(DivInstruction.Code, InstructionCodes.Div);
            string asmOut = DivInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Div"));
            Assert.IsTrue(asmOut.StartsWith("Div"));
        }

        // Inc Tests

        [Test]
        public void IncInstructionIsCreated()
        {
            Instruction IncInstruction = instFactory.Inc(0);
            Assert.AreEqual(IncInstruction.Code, InstructionCodes.Inc);
        }

        [Test]
        public void IncInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Inc r1, r2, r3 ; this is a Inc instruction";
            Instruction IncInstruction = instFactory.Inc(0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(IncInstruction.Code, InstructionCodes.Inc);
            string asmOut = IncInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Inc"));
            Assert.IsTrue(asmOut.StartsWith("Inc"));
        }

        // Dec Tests

        [Test]
        public void DecInstructionIsCreated()
        {
            Instruction DecInstruction = instFactory.Dec(0);
            Assert.AreEqual(DecInstruction.Code, InstructionCodes.Dec);
        }

        [Test]
        public void DecInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Dec r1, r2, r3 ; this is a Dec instruction";
            Instruction DecInstruction = instFactory.Dec(0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(DecInstruction.Code, InstructionCodes.Dec);
            string asmOut = DecInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Dec"));
            Assert.IsTrue(asmOut.StartsWith("Dec"));
        }

        // Compare Tests

        [Test]
        public void CompareInstructionIsCreated()
        {
            Instruction CompareInstruction = instFactory.Compare(0, 0);
            Assert.AreEqual(CompareInstruction.Code, InstructionCodes.Compare);
        }

        [Test]
        public void CompareInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Compare r1, r2, r3 ; this is a Compare instruction";
            Instruction CompareInstruction = instFactory.Compare(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(CompareInstruction.Code, InstructionCodes.Compare);
            string asmOut = CompareInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Compare"));
            Assert.IsTrue(asmOut.StartsWith("Compare"));
        }

        // ClearCompare Tests

        [Test]
        public void ClearCompareInstructionIsCreated()
        {
            Instruction ClearCompareInstruction = instFactory.ClearCompare();
            Assert.AreEqual(ClearCompareInstruction.Code, InstructionCodes.ClearCompare);
        }

        [Test]
        public void ClearCompareInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "ClearCompare r1, r2, r3 ; this is a ClearCompare instruction";
            Instruction ClearCompareInstruction = instFactory.ClearCompare().CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(ClearCompareInstruction.Code, InstructionCodes.ClearCompare);
            string asmOut = ClearCompareInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("ClearCompare"));
            Assert.IsTrue(asmOut.StartsWith("ClearCompare"));
        }

        // JE Tests

        [Test]
        public void JEInstructionIsCreated()
        {
            Instruction JEInstruction = instFactory.JE(0,0);
            Assert.AreEqual(JEInstruction.Code, InstructionCodes.JE);
        }

        [Test]
        public void JEInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "JE r1, $0 ; this is a JE instruction";
            Instruction JEInstruction = instFactory.JE(0,0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(JEInstruction.Code, InstructionCodes.JE);
            string asmOut = JEInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("JE"));
            Assert.IsTrue(asmOut.StartsWith("JE"));
        }

        // JNE Tests

        [Test]
        public void JNEInstructionIsCreated()
        {
            Instruction JNEInstruction = instFactory.JNE(0, 0);
            Assert.AreEqual(JNEInstruction.Code, InstructionCodes.JNE);
        }

        [Test]
        public void JNEInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "JNE r1, $0 ; this is a JNE instruction";
            Instruction JNEInstruction = instFactory.JNE(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(JNEInstruction.Code, InstructionCodes.JNE);
            string asmOut = JNEInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("JNE"));
            Assert.IsTrue(asmOut.StartsWith("JNE"));
        }

        // JGT Tests

        [Test]
        public void JGTInstructionIsCreated()
        {
            Instruction JGTInstruction = instFactory.JGT(0, 0);
            Assert.AreEqual(JGTInstruction.Code, InstructionCodes.JGT);
        }

        [Test]
        public void JGTInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "JGT r1, $0 ; this is a JGT instruction";
            Instruction JGTInstruction = instFactory.JGT(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(JGTInstruction.Code, InstructionCodes.JGT);
            string asmOut = JGTInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("JGT"));
            Assert.IsTrue(asmOut.StartsWith("JGT"));
        }

        // JLT Tests

        [Test]
        public void JLTInstructionIsCreated()
        {
            Instruction JLTInstruction = instFactory.JLT(0, 0);
            Assert.AreEqual(JLTInstruction.Code, InstructionCodes.JLT);
        }

        [Test]
        public void JLTInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "JLT r1, $0 ; this is a JLT instruction";
            Instruction JLTInstruction = instFactory.JLT(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(JLTInstruction.Code, InstructionCodes.JLT);
            string asmOut = JLTInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("JLT"));
            Assert.IsTrue(asmOut.StartsWith("JLT"));
        }

        // JZ Tests

        [Test]
        public void JZInstructionIsCreated()
        {
            Instruction JZInstruction = instFactory.JZ(0, 0);
            Assert.AreEqual(JZInstruction.Code, InstructionCodes.JZ);
        }

        [Test]
        public void JZInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "JZ r1, $0 ; this is a JZ instruction";
            Instruction JZInstruction = instFactory.JZ(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(JZInstruction.Code, InstructionCodes.JZ);
            string asmOut = JZInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("JZ"));
            Assert.IsTrue(asmOut.StartsWith("JZ"));
        }

        // JNZ Tests

        [Test]
        public void JNZInstructionIsCreated()
        {
            Instruction JNZInstruction = instFactory.JNZ(0, 0);
            Assert.AreEqual(JNZInstruction.Code, InstructionCodes.JNZ);
        }

        [Test]
        public void JNZInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "JNZ r1, $0 ; this is a JNZ instruction";
            Instruction JNZInstruction = instFactory.JNZ(0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(JNZInstruction.Code, InstructionCodes.JNZ);
            string asmOut = JNZInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("JNZ"));
            Assert.IsTrue(asmOut.StartsWith("JNZ"));
        }

        
        // And Tests

        [Test]
        public void AndInstructionIsCreated()
        {
            Instruction AndInstruction = instFactory.And(0, 0, 0);
            Assert.AreEqual(AndInstruction.Code, InstructionCodes.And);
        }

        [Test]
        public void AndInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "And r1, r2, r3 ; this is a And instruction";
            Instruction AndInstruction = instFactory.And(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(AndInstruction.Code, InstructionCodes.And);
            string asmOut = AndInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("And"));
            Assert.IsTrue(asmOut.StartsWith("And"));
        }

        
        // Or Tests

        [Test]
        public void OrInstructionIsCreated()
        {
            Instruction OrInstruction = instFactory.Or(0, 0, 0);
            Assert.AreEqual(OrInstruction.Code, InstructionCodes.Or);
        }

        [Test]
        public void OrInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Or r1, r2, r3 ; this is a Or instruction";
            Instruction OrInstruction = instFactory.Or(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(OrInstruction.Code, InstructionCodes.Or);
            string asmOut = OrInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Or"));
            Assert.IsTrue(asmOut.StartsWith("Or"));
        }


        
        // Not Tests

        [Test]
        public void NotInstructionIsCreated()
        {
            Instruction NotInstruction = instFactory.Not(0, 0, 0);
            Assert.AreEqual(NotInstruction.Code, InstructionCodes.Not);
        }

        [Test]
        public void NotInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Not r1, r2, r3 ; this is a Not instruction";
            Instruction NotInstruction = instFactory.Not(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(NotInstruction.Code, InstructionCodes.Not);
            string asmOut = NotInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Not"));
            Assert.IsTrue(asmOut.StartsWith("Not"));
        }

        
        // Xor Tests

        [Test]
        public void XorInstructionIsCreated()
        {
            Instruction XorInstruction = instFactory.Xor(0, 0, 0);
            Assert.AreEqual(XorInstruction.Code, InstructionCodes.Xor);
        }

        [Test]
        public void XorInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Xor r1, r2, r3 ; this is a Xor instruction";
            Instruction XorInstruction = instFactory.Xor(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(XorInstruction.Code, InstructionCodes.Xor);
            string asmOut = XorInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Xor"));
            Assert.IsTrue(asmOut.StartsWith("Xor"));
        }

        
        // Nand Tests

        [Test]
        public void NandInstructionIsCreated()
        {
            Instruction NandInstruction = instFactory.Nand(0, 0, 0);
            Assert.AreEqual(NandInstruction.Code, InstructionCodes.Nand);
        }

        [Test]
        public void NandInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Nand r1, r2, r3 ; this is a Nand instruction";
            Instruction NandInstruction = instFactory.Nand(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(NandInstruction.Code, InstructionCodes.Nand);
            string asmOut = NandInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Nand"));
            Assert.IsTrue(asmOut.StartsWith("Nand"));
        }

        
        // Nor Tests

        [Test]
        public void NorInstructionIsCreated()
        {
            Instruction NorInstruction = instFactory.Nor(0, 0, 0);
            Assert.AreEqual(NorInstruction.Code, InstructionCodes.Nor);
        }

        [Test]
        public void NorInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Nor r1, r2, r3 ; this is a Nor instruction";
            Instruction NorInstruction = instFactory.Nor(0, 0, 0).CreateInstruction(instFactory, asmIn);
            Assert.AreEqual(NorInstruction.Code, InstructionCodes.Nor);
            string asmOut = NorInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Nor"));
            Assert.IsTrue(asmOut.StartsWith("Nor"));
        }




    }
}

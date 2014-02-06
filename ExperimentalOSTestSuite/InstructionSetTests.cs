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

        [Test]
        public void NopInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction nopInstruction = instFactory.Nop();
            nopInstruction.Write(buffer, 0);
            Instruction newNopInst = nopInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(nopInstruction.Code, newNopInst.Code);
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

        [Test]
        public void MoveInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction MoveInstruction = instFactory.Move(0, 0);
            MoveInstruction.Write(buffer, 0);
            Instruction newMoveInst = MoveInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(MoveInstruction.Code, newMoveInst.Code);
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

        [Test]
        public void LoadInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction LoadInstruction = instFactory.Load(0, 0, 0, 0);
            LoadInstruction.Write(buffer, 0);
            Instruction newLoadInst = LoadInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(LoadInstruction.Code, newLoadInst.Code);
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

        [Test]
        public void StoreInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction StoreInstruction = instFactory.Store(0, 0, 0, 0);
            StoreInstruction.Write(buffer, 0);
            Instruction newStoreInst = StoreInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(StoreInstruction.Code, newStoreInst.Code);
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

        [Test]
        public void PushInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction PushInstruction = instFactory.Push(0);
            PushInstruction.Write(buffer, 0);
            Instruction newPushInst = PushInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(PushInstruction.Code, newPushInst.Code);
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

        [Test]
        public void PopInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction PopInstruction = instFactory.Pop(0);
            PopInstruction.Write(buffer, 0);
            Instruction newPopInst = PopInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(PopInstruction.Code, newPopInst.Code);
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

        [Test]
        public void InInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction InInstruction = instFactory.In(0, 0);
            InInstruction.Write(buffer, 0);
            Instruction newInInst = InInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(InInstruction.Code, newInInst.Code);
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

        [Test]
        public void OutInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction OutInstruction = instFactory.Out(0, 0);
            OutInstruction.Write(buffer, 0);
            Instruction newOutInst = OutInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(OutInstruction.Code, newOutInst.Code);
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

        [Test]
        public void JumpInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction JumpInstruction = instFactory.Jump(0, 0);
            JumpInstruction.Write(buffer, 0);
            Instruction newJumpInst = JumpInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(JumpInstruction.Code, newJumpInst.Code);
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

        [Test]
        public void CallInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction CallInstruction = instFactory.Call(0, 0);
            CallInstruction.Write(buffer, 0);
            Instruction newCallInst = CallInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(CallInstruction.Code, newCallInst.Code);
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

        [Test]
        public void TerminateInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction TerminateInstruction = instFactory.Terminate();
            TerminateInstruction.Write(buffer, 0);
            Instruction newTerminateInst = TerminateInstruction.Read(instFactory, buffer, 0);
            Assert.AreEqual(TerminateInstruction.Code, newTerminateInst.Code);
        }



    }
}

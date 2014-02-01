using System;
using NUnit;
using NUnit.Framework;
using LagDaemon.ExperimentalOS.CPU.CPUKernel;
using LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet;

namespace ExperimentalOSTestSuite
{
    [TestFixture]
    public class InstructionSetTests
    {
        [Test]
        public void NopInstructionIsCreated()
        {
            Instruction nopInstruction = InstructionFactory.Nop();
            Assert.AreEqual(nopInstruction.Code, InstructionCodes.NOP);
        }

        [Test]
        public void NopInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "NOP ; this is a NOP instruction";
            Instruction nopInstruction = InstructionFactory.Nop().CreateInstruction(asmIn);
            Assert.AreEqual(nopInstruction.Code, InstructionCodes.NOP);
            string asmOut = nopInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("NOP"));
            Assert.IsTrue(asmOut.StartsWith("NOP"));
        }

        [Test]
        public void NopInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction nopInstruction = InstructionFactory.Nop();
            nopInstruction.Write(buffer, 0);
            Instruction newNopInst = nopInstruction.Read(buffer, 0);
            Assert.AreEqual(nopInstruction.Code, newNopInst.Code);
        }


        [Test]
        public void MoveInstructionIsCreated()
        {
            Instruction MoveInstruction = InstructionFactory.Move(0,0);
            Assert.AreEqual(MoveInstruction.Code, InstructionCodes.Move);
        }

        [Test]
        public void MoveInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Move r21, r22 ; this is a Move instruction";
            Instruction MoveInstruction = InstructionFactory.Move(1, 2).CreateInstruction(asmIn);
            Assert.AreEqual(MoveInstruction.Code, InstructionCodes.Move);
            string asmOut = MoveInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Move r21, r22"));
            Assert.IsTrue(asmOut.StartsWith("Move r21, r22"));
        }

        [Test]
        public void MoveInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction MoveInstruction = InstructionFactory.Move(0,0);
            MoveInstruction.Write(buffer, 0);
            Instruction newMoveInst = MoveInstruction.Read(buffer, 0);
            Assert.AreEqual(MoveInstruction.Code, newMoveInst.Code);
        }

        [Test]
        public void LoadInstructionIsCreated()
        {
            Instruction LoadInstruction = InstructionFactory.Load(0, 0, 0, 0);
            Assert.AreEqual(LoadInstruction.Code, InstructionCodes.Load);
        }

        [Test]
        public void LoadInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Load r21, r22, $943567 ; this is a Load instruction";
            Instruction LoadInstruction = InstructionFactory.Load(0, 0, 0, 0).CreateInstruction(asmIn);
            Assert.AreEqual(LoadInstruction.Code, InstructionCodes.Load);
            string asmOut = LoadInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Load r21, r22, $943567"));
            Assert.IsTrue(asmOut.StartsWith("Load r21, r22, $943567"));
        }

        [Test]
        public void LoadInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction LoadInstruction = InstructionFactory.Load(0,0,0,0);
            LoadInstruction.Write(buffer, 0);
            Instruction newLoadInst = LoadInstruction.Read(buffer, 0);
            Assert.AreEqual(LoadInstruction.Code, newLoadInst.Code);
        }


        [Test]
        public void StoreInstructionIsCreated()
        {
            Instruction StoreInstruction = InstructionFactory.Store(0, 0, 0, 0);
            Assert.AreEqual(StoreInstruction.Code, InstructionCodes.Store);
        }

        [Test]
        public void StoreInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Store r21, r22, $943567 ; this is a Store instruction";
            Instruction StoreInstruction = InstructionFactory.Store(0, 0, 0, 0).CreateInstruction(asmIn);
            Assert.AreEqual(StoreInstruction.Code, InstructionCodes.Store);
            string asmOut = StoreInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Store r21, r22, $943567"));
            Assert.IsTrue(asmOut.StartsWith("Store r21, r22, $943567"));
        }

        [Test]
        public void StoreInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction StoreInstruction = InstructionFactory.Store(0, 0, 0, 0);
            StoreInstruction.Write(buffer, 0);
            Instruction newStoreInst = StoreInstruction.Read(buffer, 0);
            Assert.AreEqual(StoreInstruction.Code, newStoreInst.Code);
        }

        [Test]
        public void PushInstructionIsCreated()
        {
            Instruction PushInstruction = InstructionFactory.Push(0);
            Assert.AreEqual(PushInstruction.Code, InstructionCodes.Push);
        }

        [Test]
        public void PushInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Push r21 ; this is a Push instruction";
            Instruction PushInstruction = InstructionFactory.Push(0).CreateInstruction(asmIn);
            Assert.AreEqual(PushInstruction.Code, InstructionCodes.Push);
            string asmOut = PushInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Push r21"));
            Assert.IsTrue(asmOut.StartsWith("Push r21"));
        }

        [Test]
        public void PushInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction PushInstruction = InstructionFactory.Push(0);
            PushInstruction.Write(buffer, 0);
            Instruction newPushInst = PushInstruction.Read(buffer, 0);
            Assert.AreEqual(PushInstruction.Code, newPushInst.Code);
        }


        [Test]
        public void PopInstructionIsCreated()
        {
            Instruction PopInstruction = InstructionFactory.Pop(0);
            Assert.AreEqual(PopInstruction.Code, InstructionCodes.Pop);
        }

        [Test]
        public void PopInstructionsLoadsFromAssemblyLanguage()
        {
            string asmIn = "Pop r21 ; this is a Pop instruction";
            Instruction PopInstruction = InstructionFactory.Pop(0).CreateInstruction(asmIn);
            Assert.AreEqual(PopInstruction.Code, InstructionCodes.Pop);
            string asmOut = PopInstruction.ToString();
            Assert.IsTrue(asmIn.StartsWith("Pop r21"));
            Assert.IsTrue(asmOut.StartsWith("Pop r21"));
        }

        [Test]
        public void PopInstructionEmitsByteCodeAndLoadsFromByteCode()
        {
            byte[] buffer = new byte[10];
            Instruction PopInstruction = InstructionFactory.Pop(0);
            PopInstruction.Write(buffer, 0);
            Instruction newPopInst = PopInstruction.Read(buffer, 0);
            Assert.AreEqual(PopInstruction.Code, newPopInst.Code);
        }


    }
}

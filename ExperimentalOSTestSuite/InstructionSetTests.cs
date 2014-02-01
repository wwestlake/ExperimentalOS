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
            Instruction nopInstruction = InstructionFactory.Nop().CreateInstruction("NOP ; this is a NOP instruction");
            Assert.AreEqual(nopInstruction.Code, InstructionCodes.NOP);
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
            Instruction MoveInstruction = InstructionFactory.Move(1,2).CreateInstruction("Move r21, r22 ; this is a Move instruction");
            Assert.AreEqual(MoveInstruction.Code, InstructionCodes.Move);
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
            Instruction LoadInstruction = InstructionFactory.Load(0,0,0,0).CreateInstruction("Load r21, r22, $943567 ; this is a Move instruction");
            Assert.AreEqual(LoadInstruction.Code, InstructionCodes.Load);
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
            Instruction StoreInstruction = InstructionFactory.Store(0, 0, 0, 0).CreateInstruction("Store r21, r22, $943567 ; this is a Store instruction");
            Assert.AreEqual(StoreInstruction.Code, InstructionCodes.Store);
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
    


    }
}

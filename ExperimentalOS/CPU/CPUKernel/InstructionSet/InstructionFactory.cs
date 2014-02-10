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


using LagDaemon.ExperimentalOS.CPU.Interfaces;
using System;

namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Factory methods for creating instructions
    /// </summary>
    internal class InstructionFactory : IInstructionFactory
    {
        private CPUKernel _kernel;

        internal InstructionFactory(CPUKernel kernel)
        {
            this._kernel = kernel;
        }

        /// <summary>
        /// Create a Nop Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Nop() 
        {
            return Nop(string.Empty);
        }

        /// <summary>
        /// Create a Nop instruction with comment
        /// </summary>
        /// <param name="comment">A Comment</param>
        /// <returns>Instruction</returns>
        public Instruction Nop(string comment) 
        {
            return _kernel.Connect(new NopInstruction(comment));
        }

        /// <summary>
        /// Create a Move instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <returns>Instruction</returns>
        public Instruction Move(int r1, int r2) { return Move(r1, r2, string.Empty); }

        /// <summary>
        /// Create a Move isntruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public Instruction Move(int r1, int r2, string comment) { return _kernel.Connect( new MoveInstruction(r1, r2, comment) ); }

        /// <summary>
        /// Create a Load Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        public Instruction Load(int r1, int r2, int value, int address) { return Load(r1, r2, value, address, string.Empty); }

        /// <summary>
        /// Create a Load Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public Instruction Load(int r1, int r2, int value, int address, string comment) { return _kernel.Connect( new LoadInstruction(r1, r2, value, address, comment) ); }


        /// <summary>
        /// Create a Store Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public Instruction Store(int r1, int r2, int value, int address, string comment) { return _kernel.Connect( new StoreInstruction(r1, r2, value, address, comment) ); }

        /// <summary>
        /// Create a Store Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        public Instruction Store(int r1, int r2, int value, int address) { return Store(r1, r2, value, address, string.Empty); }

        /// <summary>
        /// Create a Push Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public Instruction Push(int r1, string comment) { return _kernel.Connect( new PushInstruction(r1, comment) ); }

        /// <summary>
        /// Create a Push Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns></returns>
        public Instruction Push(int r1) { return Push(r1, string.Empty); }

        /// <summary>
        /// Create a Pop Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public Instruction Pop(int r1, string comment) { return _kernel.Connect( new PopInstruction(r1, comment) ); }

        /// <summary>
        /// Create a Pop Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns></returns>
        public Instruction Pop(int r1) { return Pop(r1, string.Empty); }

        /// <summary>
        /// Create a In Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="port">The port to read from</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public Instruction In(int r1, int port, string comment) { return _kernel.Connect( new InInstruction(r1, port, comment) ); }

        /// <summary>
        /// Create a Pop Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="port">The port to read from</param>
        /// <returns>Instruction</returns>
        public Instruction In(int r1, int port) { return In(r1, port, string.Empty); }

        /// <summary>
        /// Creates an Out Instruction
        /// </summary>
        /// <param name="r1">Register to send to port</param>
        /// <param name="port">Port to write to</param>
        /// <returns>Instruction</returns>
        public Instruction Out(int r1, int port) { return Out(r1, port, string.Empty); }

        /// <summary>
        /// Creates an Out Instruction with comment
        /// </summary>
        /// <param name="r1">Register to send to port</param>
        /// <param name="port">The port to write to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Out(int r1, int port, string comment) { return _kernel.Connect( new OutInstruction(r1, port, comment) ); }

        /// <summary>
        /// Creates an Jump Instruction
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to jump to</param>
        /// <returns>Instruction</returns>
        public Instruction Jump(int r1, int address) { return Jump(r1, address, string.Empty); }

        /// <summary>
        /// Creates an Jump Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to jump to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Jump(int r1, int address, string comment) { return _kernel.Connect( new JumpInstruction(r1, address, comment) ); }

        /// <summary>
        /// Creates a Call Instruction
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <returns>Instruction</returns>
        public Instruction Call(int r1, int address) { return Call(r1, address, string.Empty); }

        /// <summary>
        /// Creates a Call Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Call(int r1, int address, string comment) { return _kernel.Connect( new CallInstruction(r1, address, comment) ); }

        /// <summary>
        /// Creates a Terminate Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Terminate() { return Terminate(string.Empty); }

        /// <summary>
        /// Creates a Terminate Instruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Terminate(string comment) { return _kernel.Connect( new TerminateInstruction(comment) ); }

        /// <summary>
        /// Creates a Terminate Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Return() { return Return(string.Empty); }

        /// <summary>
        /// Creates a Terminate Instruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Return(string comment) { return _kernel.Connect(new ReturnInstruction(comment)); }

        
        /// <summary>
        /// Creates a Add Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Add(int r1, int r2, int r3) { return Add(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a AddInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Add(int r1, int r2, int r3, string comment) { return _kernel.Connect(new AddInstruction(r1, r2, r3, comment)); }

        
        /// <summary>
        /// Creates a Sub Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Sub(int r1, int r2, int r3) { return Sub(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a SubInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Sub(int r1, int r2, int r3, string comment) { return _kernel.Connect(new SubInstruction(r1, r2, r3, comment)); }


        
        /// <summary>
        /// Creates a Mul Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Mul(int r1, int r2, int r3) { return Mul(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a MulInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Mul(int r1, int r2, int r3, string comment) { return _kernel.Connect(new MulInstruction(r1, r2, r3, comment)); }


        
        /// <summary>
        /// Creates a Div Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Div(int r1, int r2, int r3) { return Div(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a DivInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Div(int r1, int r2, int r3, string comment) { return _kernel.Connect(new DivInstruction(r1, r2, r3, comment)); }

        /// <summary>
        /// Creates a And Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction And(int r1, int r2, int r3) { return And(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a AndInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction And(int r1, int r2, int r3, string comment) { return _kernel.Connect(new AndInstruction(r1, r2, r3, comment)); }

        /// <summary>
        /// Creates a Or Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Or(int r1, int r2, int r3) { return Or(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a AndInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Or(int r1, int r2, int r3, string comment) { return _kernel.Connect(new OrInstruction(r1, r2, r3, comment)); }

        /// <summary>
        /// Creates a Not Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Not(int r1, int r2, int r3) { return Not(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a NotInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Not(int r1, int r2, int r3, string comment) { return _kernel.Connect(new NotInstruction(r1, r2, r3, comment)); }

        /// <summary>
        /// Creates a Xor Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Xor(int r1, int r2, int r3) { return Xor(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a XortInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Xor(int r1, int r2, int r3, string comment) { return _kernel.Connect(new XorInstruction(r1, r2, r3, comment)); }



        /// <summary>
        /// Creates a Nand Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Nand(int r1, int r2, int r3) { return Nand(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a NandtInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Nand(int r1, int r2, int r3, string comment) { return _kernel.Connect(new NandInstruction(r1, r2, r3, comment)); }


        /// <summary>
        /// Creates a Nor Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Nor(int r1, int r2, int r3) { return Nor(r1, r2, r3, string.Empty); }

        /// <summary>
        /// Creates a NortInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Nor(int r1, int r2, int r3, string comment) { return _kernel.Connect(new NorInstruction(r1, r2, r3, comment)); }


        /// <summary>
        /// Creates a Inc Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Inc(int r1) { return Inc(r1, string.Empty); }

        /// <summary>
        /// Creates a IncInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Inc(int r1, string comment) { return _kernel.Connect(new IncInstruction(r1, comment)); }


        
        /// <summary>
        /// Creates a Dec Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Dec(int r1) { return Dec(r1, string.Empty); }

        /// <summary>
        /// Creates a DecInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Dec(int r1, string comment) { return _kernel.Connect(new DecInstruction(r1, comment)); }

        
        /// <summary>
        /// Creates a Compare Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction Compare(int r1, int r2) { return Compare(r1, r2, string.Empty); }

        /// <summary>
        /// Creates a CompareInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction Compare(int r1, int r2, string comment) { return _kernel.Connect(new CompareInstruction(r1, r2, comment)); }

        
        /// <summary>
        /// Creates a ClearCompare Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction ClearCompare() { return ClearCompare(string.Empty); }

        /// <summary>
        /// Creates a ClearCompareInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction ClearCompare(string comment) { return _kernel.Connect(new ClearCompareInstruction(comment)); }

        
        /// <summary>
        /// Creates a JE Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction JE(int r1, int address) { return JE(r1, address, string.Empty); }

        /// <summary>
        /// Creates a JEInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction JE(int r1, int address, string comment) { return _kernel.Connect(new JEInstruction(r1, address, comment)); }


        /// <summary>
        /// Creates a JNE Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction JNE(int r1, int address) { return JNE(r1, address, string.Empty); }

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction JNE(int r1, int address, string comment) { return _kernel.Connect(new JNEInstruction(r1, address, comment)); }

        /// <summary>
        /// Creates a JGT Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction JGT(int r1, int address) { return JGT(r1, address, string.Empty); }

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction JGT(int r1, int address, string comment) { return _kernel.Connect(new JGTInstruction(r1, address, comment)); }

        /// <summary>
        /// Creates a JLT Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction JLT(int r1, int address) { return JLT(r1, address, string.Empty); }

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction JLT(int r1, int address, string comment) { return _kernel.Connect(new JLTInstruction(r1, address, comment)); }

        /// <summary>
        /// Creates a JZ Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction JZ(int r1, int address) { return JZ(r1, address, string.Empty); }

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction JZ(int r1, int address, string comment) { return _kernel.Connect(new JZInstruction(r1, address, comment)); }

        /// <summary>
        /// Creates a JNZ Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public Instruction JNZ(int r1, int address) { return JNZ(r1, address, string.Empty); }

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public Instruction JNZ(int r1, int address, string comment) { return _kernel.Connect(new JNZInstruction(r1, address, comment)); }


        public Instruction FromCode(InstructionCodes code)
        {
            switch (code)
            {
                case InstructionCodes.Add:
                    return Add(0,0,0);
                case InstructionCodes.AllocateMemory:
                    break;
                case InstructionCodes.BeginAtomicBlock:
                    break;
                case InstructionCodes.Call:
                    return Call(0, 0);
                    
                case InstructionCodes.Compare:
                    break;
                case InstructionCodes.Dec:
                    break;
                case InstructionCodes.Div:
                    return Div(0,0,0);
                case InstructionCodes.EndAtomicBlock:
                    break;
                case InstructionCodes.FireEvent:
                    break;
                case InstructionCodes.FreeMemory:
                    break;
                case InstructionCodes.In:
                    return In(0, 0);
                    
                case InstructionCodes.Inc:
                    break;
                case InstructionCodes.JE:
                    break;
                case InstructionCodes.JGT:
                    break;
                case InstructionCodes.JLT:
                    break;
                case InstructionCodes.JNE:
                    break;
                case InstructionCodes.Jump:
                    return Jump(0, 0);
                    
                case InstructionCodes.Load:
                    return Load(0, 0, 0, 0);
                    
                case InstructionCodes.Lock:
                    break;
                case InstructionCodes.MemoryClear:
                    break;
                case InstructionCodes.Move:
                    return Move(0, 0);
                    
                case InstructionCodes.Mul:
                    return Mul(0, 0, 0);
                case InstructionCodes.NOP:
                    return Nop();
                    
                case InstructionCodes.Out:
                    return Out(0, 0);
                    
                case InstructionCodes.Pop:
                    return Pop(0);
                    
                case InstructionCodes.Push:
                    return Push(0);
                    
                case InstructionCodes.Return:
                    break;
                case InstructionCodes.SetPriority:
                    break;
                case InstructionCodes.Sleep:
                    break;
                case InstructionCodes.Store:
                    break;
                case InstructionCodes.Sub:
                    return Sub(0, 0, 0);
                case InstructionCodes.Terminate:
                    return Terminate();
                    
                case InstructionCodes.Unlock:
                    break;
                case InstructionCodes.WaitOnEvent:
                    break;
            }
            throw new NotImplementedException(string.Format("Instruction {0} is not yet implemented",code));
        }
    }
}

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
using LagDaemon.ExperimentalOS.CPU.CPUKernel;

namespace LagDaemon.ExperimentalOS.CPU.Interfaces
{
    /// <summary>
    /// InstructionFactory interface
    /// </summary>
    public interface IInstructionFactory
    {

        /// <summary>
        /// Create a new instruction from a Code
        /// </summary>
        /// <param name="code">The Instruction Code</param>
        /// <returns>An Instruction Prototype not configured</returns>
        Instruction FromCode(InstructionCodes code);

        /// <summary>
        /// Create a Nop Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        Instruction Nop();

        /// <summary>
        /// Create a Nop instruction with comment
        /// </summary>
        /// <param name="comment">A Comment</param>
        /// <returns>Instruction</returns>
        Instruction Nop(string comment);

        /// <summary>
        /// Create a Move instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <returns>Instruction</returns>
        Instruction Move(int r1, int r2);

        /// <summary>
        /// Create a Move isntruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        Instruction Move(int r1, int r2, string comment);

        /// <summary>
        /// Create a Load Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        Instruction Load(int r1, int r2, int value, int address, string comment);

        /// <summary>
        /// Create a Load Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        Instruction Load(int r1, int r2, int value, int address);

        /// <summary>
        /// Create a Store Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        Instruction Store(int r1, int r2, int value, int address, string comment);

        /// <summary>
        /// Create a Store Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        Instruction Store(int r1, int r2, int value, int address);

        /// <summary>
        /// Create a Push Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        Instruction Push(int r1, string comment);

        /// <summary>
        /// Create a Push Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns></returns>
        Instruction Push(int r1);

        /// <summary>
        /// Create a Pop Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        Instruction Pop(int r1, string comment);

        /// <summary>
        /// Create a Pop Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns></returns>
        Instruction Pop(int r1);

        /// <summary>
        /// Create a In Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="port">The port to read from</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        Instruction In(int r1, int port, string comment);

        /// <summary>
        /// Create a Pop Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="port">The port to read from</param>
        /// <returns>Instruction</returns>
        Instruction In(int r1, int port);

        /// <summary>
        /// Creates an Out Instruction
        /// </summary>
        /// <param name="r1">Register to send to port</param>
        /// <param name="port">Port to write to</param>
        /// <returns>Instruction</returns>
        Instruction Out(int r1, int port);

        /// <summary>
        /// Creates an Out Instruction with comment
        /// </summary>
        /// <param name="r1">Register to send to port</param>
        /// <param name="port">The port to write to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Out(int r1, int port, string comment);

        /// <summary>
        /// Creates an Jump Instruction
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to jump to</param>
        /// <returns>Instruction</returns>
        Instruction Jump(int r1, int address);

        /// <summary>
        /// Creates an Jump Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to jump to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Jump(int r1, int address, string comment);

        /// <summary>
        /// Creates a Call Instruction
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <returns>Instruction</returns>
        Instruction Call(int r1, int address);

        /// <summary>
        /// Creates a Call Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Call(int r1, int address, string comment);


        /// <summary>
        /// Creates a Return Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        Instruction Return();

        /// <summary>
        /// Creates a Return Instruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Return(string comment);

        /// <summary>
        /// Creates a Add Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        Instruction Add(int r1, int r2, int r3);

        /// <summary>
        /// Creates a AddInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Add(int r1, int r2, int r3, string comment);


        /// <summary>
        /// Creates a Sub Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Sub(int r1, int r2, int r3);

        /// <summary>
        /// Creates a SubInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Sub(int r1, int r2, int r3, string comment);



        /// <summary>
        /// Creates a Mul Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Mul(int r1, int r2, int r3);

        /// <summary>
        /// Creates a MulInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Mul(int r1, int r2, int r3, string comment);



        /// <summary>
        /// Creates a Div Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Div(int r1, int r2, int r3);

        /// <summary>
        /// Creates a DivInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Div(int r1, int r2, int r3, string comment);

        /// <summary>
        /// Creates a And Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction And(int r1, int r2, int r3);

        /// <summary>
        /// Creates a AndInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction And(int r1, int r2, int r3, string comment);

        /// <summary>
        /// Creates a Or Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Or(int r1, int r2, int r3);

        /// <summary>
        /// Creates a AndInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Or(int r1, int r2, int r3, string comment);

        /// <summary>
        /// Creates a Not Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Not(int r1, int r2, int r3);

        /// <summary>
        /// Creates a NotInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Not(int r1, int r2, int r3, string comment);

        /// <summary>
        /// Creates a Xor Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Xor(int r1, int r2, int r3);

        /// <summary>
        /// Creates a XortInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Xor(int r1, int r2, int r3, string comment);



        /// <summary>
        /// Creates a Nand Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Nand(int r1, int r2, int r3);

        /// <summary>
        /// Creates a NandtInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Nand(int r1, int r2, int r3, string comment);


        /// <summary>
        /// Creates a Nor Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <returns>Instruction</returns>
        Instruction Nor(int r1, int r2, int r3);

        /// <summary>
        /// Creates a NortInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="r3">Register 3</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Nor(int r1, int r2, int r3, string comment);



        /// <summary>
        /// Creates a Inc Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns>Instruction</returns>
        Instruction Inc(int r1);

        /// <summary>
        /// Creates a IncInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Inc(int r1, string comment);



        /// <summary>
        /// Creates a Dec Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns>Instruction</returns>
        Instruction Dec(int r1);

        /// <summary>
        /// Creates a DecInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Dec(int r1, string comment);

        /// <summary>
        /// Creates a Compare Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <returns>Instruction</returns>
        Instruction Compare(int r1, int r2);

        /// <summary>
        /// Creates a CompareInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Compare(int r1, int r2, string comment);

        /// <summary>
        /// Creates a ClearCompare Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        Instruction ClearCompare();

        /// <summary>
        /// Creates a ClearCompareInstruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction ClearCompare(string comment);

        /// <summary>
        /// Creates a JE Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        Instruction JE(int r1, int address);

        /// <summary>
        /// Creates a JEInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction JE(int r1, int address, string comment);


        /// <summary>
        /// Creates a JNE Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <returns>Instruction</returns>
        Instruction JNE(int r1, int address);

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction JNE(int r1, int address, string comment);

        /// <summary>
        /// Creates a JGT Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <returns>Instruction</returns>
        Instruction JGT(int r1, int address);

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction JGT(int r1, int address, string comment);

        /// <summary>
        /// Creates a JLT Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <returns>Instruction</returns>
        Instruction JLT(int r1, int address);

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction JLT(int r1, int address, string comment);

        /// <summary>
        /// Creates a JZ Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <returns>Instruction</returns>
        Instruction JZ(int r1, int address);

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction JZ(int r1, int address, string comment);

        /// <summary>
        /// Creates a JNZ Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <returns>Instruction</returns>
        Instruction JNZ(int r1, int address);

        /// <summary>
        /// Creates a JNEInstruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="address">The address</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction JNZ(int r1, int address, string comment);


        /// <summary>
        /// Creates a Terminate Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        Instruction Terminate();

        /// <summary>
        /// Creates a Terminate Instruction with comment
        /// </summary>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Terminate(string comment);
    }
}

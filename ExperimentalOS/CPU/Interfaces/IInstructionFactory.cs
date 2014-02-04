﻿using LagDaemon.ExperimentalOS.CPU.CPUKernel;

namespace LagDaemon.ExperimentalOS.CPU.Interfaces
{
    public interface IInstructionFactory
    {
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
        Instruction Load(int r1, int r2, int value, uint address, string comment);

        /// <summary>
        /// Create a Load Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        Instruction Load(int r1, int r2, int value, uint address);

        /// <summary>
        /// Create a Store Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        Instruction Store(int r1, int r2, int value, uint address, string comment);

        /// <summary>
        /// Create a Store Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        Instruction Store(int r1, int r2, int value, uint address);

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
        Instruction Jump(int r1, uint address);

        /// <summary>
        /// Creates an Jump Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to jump to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Jump(int r1, uint address, string comment);

        /// <summary>
        /// Creates a Call Instruction
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <returns>Instruction</returns>
        Instruction Call(int r1, uint address);

        /// <summary>
        /// Creates a Call Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        Instruction Call(int r1, uint address, string comment);

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

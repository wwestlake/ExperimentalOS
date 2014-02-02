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


namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Factory methods for creating instructions
    /// </summary>
    public static class InstructionFactory
    {
        /// <summary>
        /// Create a Nop Instruction
        /// </summary>
        /// <returns>Instruction</returns>
        public static Instruction Nop() { return Nop(string.Empty); }

        /// <summary>
        /// Create a Nop instruction with comment
        /// </summary>
        /// <param name="comment">A Comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Nop(string comment) { return new NopInstruction(comment); }

        /// <summary>
        /// Create a Move instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <returns>Instruction</returns>
        public static Instruction Move(int r1, int r2) { return Move(r1, r2, string.Empty); }

        /// <summary>
        /// Create a Move isntruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Move(int r1, int r2, string comment) { return new MoveInstruction(r1, r2, comment); }

        /// <summary>
        /// Create a Load Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Load(int r1, int r2, int value, uint address, string comment) { return new LoadInstruction(r1, r2, value, address, comment); }

        /// <summary>
        /// Create a Load Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        public static Instruction Load(int r1, int r2, int value, uint address) { return new LoadInstruction(r1, r2, value, address, string.Empty); }

        /// <summary>
        /// Create a Store Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Store(int r1, int r2, int value, uint address, string comment) { return new StoreInstruction(r1, r2, value, address, comment); }

        /// <summary>
        /// Create a Store Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns>Instruction</returns>
        public static Instruction Store(int r1, int r2, int value, uint address) { return new StoreInstruction(r1, r2, value, address, string.Empty); }

        /// <summary>
        /// Create a Push Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Push(int r1, string comment) { return new PushInstruction(r1, comment); }

        /// <summary>
        /// Create a Push Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns></returns>
        public static Instruction Push(int r1) { return new PushInstruction(r1); }

        /// <summary>
        /// Create a Pop Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Pop(int r1, string comment) { return new PopInstruction(r1, comment); }

        /// <summary>
        /// Create a Pop Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <returns></returns>
        public static Instruction Pop(int r1) { return new PopInstruction(r1); }

        /// <summary>
        /// Create a In Instruction with comment
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="port">The port to read from</param>
        /// <param name="comment">Comment</param>
        /// <returns>Instruction</returns>
        public static Instruction In(int r1, int port, string comment) { return new InInstruction(r1, port, comment); }

        /// <summary>
        /// Create a Pop Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="port">The port to read from</param>
        /// <returns>Instruction</returns>
        public static Instruction In(int r1, int port) { return new InInstruction(r1, port); }

        /// <summary>
        /// Creates an Out Instruction
        /// </summary>
        /// <param name="r1">Register to send to port</param>
        /// <param name="port">Port to write to</param>
        /// <returns>Instruction</returns>
        public static Instruction Out(int r1, int port) { return new OutInstruction(r1, port); }

        /// <summary>
        /// Creates an Out Instruction with comment
        /// </summary>
        /// <param name="r1">Register to send to port</param>
        /// <param name="port">The port to write to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Out(int r1, int port, string comment) { return new OutInstruction(r1, port, comment); }

        /// <summary>
        /// Creates an Jump Instruction
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to jump to</param>
        /// <returns>Instruction</returns>
        public static Instruction Jump(int r1, uint address) { return new JumpInstruction(r1, address); }

        /// <summary>
        /// Creates an Jump Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to jump to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Jump(int r1, uint address, string comment) { return new JumpInstruction(r1, address, comment); }

        /// <summary>
        /// Creates a Call Instruction
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <returns>Instruction</returns>
        public static Instruction Call(int r1, uint address) { return new CallInstruction(r1, address); }

        /// <summary>
        /// Creates a Call Instruction with comment
        /// </summary>
        /// <param name="r1">Index modifier to address or address</param>
        /// <param name="address">Address to call to</param>
        /// <param name="comment">The comment</param>
        /// <returns>Instruction</returns>
        public static Instruction Call(int r1, uint address, string comment) { return new CallInstruction(r1, address, comment); }

    }
}

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


namespace LagDaemon.ExperimentalOS.CPU.CPUKernel
{
    /// <summary>
    /// Defines the CPU instruction set
    /// </summary>
    public enum InstructionCodes
    {
        /// <summary>
        /// No operation
        /// NOP
        /// </summary>
        /// <remarks>Inst completed</remarks>
        NOP,

        /// <summary>
        /// Moves data from register 1 to register 2
        /// Move r1, r2
        /// </summary>
        /// <remarks>inst completed</remarks>
        Move,

        /// <summary>
        /// Loads data from memory to a register
        /// Load r1, value          ; imediate
        /// Load r1, $address       ; direct addressing
        /// Load r1, r2            ; indirect addressing
        /// Load r1, r2, $address   ; indexed indirect addressing  
        /// </summary>
        /// <remarks>inst completed</remarks>
        Load,

        /// <summary>
        /// stores data from a register or imnediate to memory
        /// Store r1, value         // imediate value to address in r1
        /// Store r1, $address      // direct addressing
        /// Store r1, r2            // indirect addressing address in r2
        /// Store r1, r2, $address  // indexed indirect addressing imediate address + r2 index
        /// </summary>
        /// <remarks>inst completed</remarks>
        Store,

        /// <summary>
        /// pushes a register onto the stack
        /// Push r1
        /// </summary>
        /// <remarks>inst completed</remarks>
        Push,

        /// <summary>
        /// pops data from the stack into a register
        /// Pop R1
        /// </summary>
        /// <remarks>inst completed</remarks>
        Pop,

        /// <summary>
        /// reads from an input port to a register
        /// In r1, $port            // port number imedediate
        /// In r1, r2               // port numher in register 2
        /// </summary>
        /// <remarks>inst completed</remarks>
        In,
 
        /// <summary>
        /// writes froma register to an output port
        /// Out r1, $port           
        /// Out r1, r2
        /// </summary>
        /// <remarks>inst completed</remarks>
        Out,

        /// <summary>
        /// jumps the execution address to the specified address in a register
        /// Jump $address           // imediate address
        /// Jump r1                 // address in r1
        /// Jump r1, $address        // r1 indexes into address (address + r1)
        /// <remarks>inst completed</remarks>
        /// </summary>
        Jump,

        /// <summary>
        /// pushes the current address to the stack then jumps the desired address
        /// Call $address
        /// Call r1
        /// Call r1, $address
        /// <remarks>inst completed</remarks>
        /// </summary>
        Call,

        /// <summary>
        /// returns from a call by popping the addess from the stack
        /// Return
        /// <remarks>inst completed</remarks>
        /// </summary>
        Return,

        /// <summary>
        /// Add register 2 to register 3 and stores the result in register 1
        /// Add r1, r2, r3
        /// <remarks>inst completed</remarks>
        /// </summary>
        Add,

        /// <summary>
        /// Subtracts r3 from r2 stores result in r1
        /// Sub r1, r2, r3
        /// <remarks>inst completed</remarks>
        /// </summary>
        Sub,

        /// <summary>
        /// Multiplies r2 by r3 stores result in r1
        /// Mul r1, r2, r3
        /// </summary>
        /// <remarks>inst completed</remarks>
        Mul,

        /// <summary>
        /// Divides r2 by r3 stores result in r1
        /// Div r1, r2, r3
        /// </summary>
        /// <remarks>inst completed</remarks>
        Div,

        /// <summary>
        /// Ands r2 by r3 stores result in r1
        /// Div r1, r2, r3
        /// </summary>
        And,

        /// <summary>
        /// Ors r2 by r3 stores result in r1
        /// Div r1, r2, r3
        /// </summary>
        Or,

        /// <summary>
        /// Nots r2 by r3 stores result in r1
        /// Div r1, r2, r3
        /// </summary>
        Not,

        /// <summary>
        /// Xors r2 by r3 stores result in r1
        /// Div r1, r2, r3
        /// </summary>
        Xor,

        /// <summary>
        /// Not Ands r2 by r3 stores result in r1
        /// Div r1, r2, r3
        /// </summary>
        Nand,

        /// <summary>
        /// Not Ors r2 by r3 stores result in r1
        /// Div r1, r2, r3
        /// </summary>
        Nor,

        /// <summary>
        /// Increments register r1 by 1
        /// Inc r1
        /// </summary>
        /// <remarks>inst completed</remarks>
        Inc,

        /// <summary>
        /// Decrements r1 by 1
        /// Dec r1
        /// </summary>
        /// <remarks>inst completed</remarks>
        Dec,

        /// <summary>
        /// Compares r1 to r2 and sets the comparison flag to be acted upon my a conditional instruction
        /// Compare r1, r2
        /// </summary>
        /// <remarks>inst completed</remarks>
        Compare,

        /// <summary>
        /// Clears the compare flag to Cleared
        /// ClearCompare
        /// </summary>
        /// <remarks>inst completed</remarks>
        ClearCompare,


        /// <summary>
        /// Jump IFF conditional flag is Equal
        /// JE $address
        /// JE r1
        /// JE r1, $address
        /// </summary>
        /// <remarks>inst completed</remarks>
        JE,

        /// <summary>
        /// Jump IFF conditional flag is Not Equal (any state other than equal)
        /// JNE $address
        /// JNE r1
        /// JNE r1, $address
        /// </summary>
        /// <remarks>inst completed</remarks>
        JNE,

        /// <summary>
        /// Jump IFF conditional flag is Greater Than
        /// JGT $address
        /// JGT r1
        /// JGT r1, $address
        /// </summary>
        /// <remarks>inst completed</remarks>
        JGT,

        /// <summary>
        /// Jump IFF coditional flag is Less Than
        /// JLT $address
        /// JLT r1
        /// JLT r1, $address
        /// </summary>
        /// <remarks>inst completed</remarks>
        JLT,

        /// <summary>
        /// Jump IFF zero flag is true
        /// JZ $address
        /// JZ r1
        /// JZ r1, $address
        /// </summary>
        /// <remarks>inst completed</remarks>
        JZ,

        /// <summary>
        /// Jump IFF zero flag is not true
        /// JNZ $address
        /// JNZ r1
        /// JNZ r1, $address
        /// </summary>
        /// <remarks>inst completed</remarks>
        JNZ,


        /// <summary>
        /// Alllocates memory to the processor memory manager and places the allocated memory handle in the designated register r1
        /// AllocateMemory r1, num
        /// </summary>
        AllocateMemory,

        /// <summary>
        /// Frees previously allocated memory as designated by the handle in r1
        /// FreeMemory r1
        /// </summary>
        FreeMemory,

        /// <summary>
        /// Clears the memory starting at the address in r1 for number of bytes in r2
        /// MemoryClear r1, r2
        /// </summary>
        MemoryClear,

        /// <summary>
        /// Terminates the currently running process where r1 contains an exit code for the process which will be returned to the OS Kernel
        /// Terminate r1
        /// <remarks>inst completed</remarks>
        /// </summary>
        Terminate,

        // --------------------------------------------------- Multitasking CPU Instructions -----------------------------------------

        /// <summary>
        /// Obtains a lock on a process where num is the lock number asscociated with the calling process
        /// Lock num
        /// Lock r1
        /// </summary>
        Lock,

        /// <summary>
        /// Unlocks a lock obtained by Lock
        /// Unlock num
        /// Unlock r1
        /// </summary>
        Unlock,

        /// <summary>
        /// Causes the currently executing process to sleep by the specified time in Miliseconds
        /// Sleep num
        /// Sleep r1
        /// </summary>
        Sleep,

        /// <summary>
        /// Sets the priority of the currently executing process
        /// SetPriority num
        /// SetPriority r1
        /// </summary>
        SetPriority,

        /// <summary>
        /// Waits for an event designated by the event handle in r1
        /// WaitOnEvent r1
        /// </summary>
        WaitOnEvent,

        /// <summary>
        /// Fires the event in r1
        /// FireEvent r1
        /// </summary>
        FireEvent,

        /// <summary>
        /// Starts an atomic block (this block will not be interupted by taks switching) and returns an AtomicBlock handle in r1
        /// The atomic block begins with the next executing instruction and ends when EndAtomicBlock is encountered with the 
        /// appropriate AtomicBlockHandle
        /// BeginAtomicBlock r1
        /// </summary>
        BeginAtomicBlock,

        /// <summary>
        /// Ends an AtomicBlock started with BeginAtomicBlock.  r1 must contain the atomic block number that is ending
        /// EndAtomicBlock r1
        /// </summary>
        EndAtomicBlock,


        /// <summary>
        /// Starts multi tasking.
        /// EnterMultitaskingMode
        /// </summary>
        EnterMultitaskingMode,
    }
}

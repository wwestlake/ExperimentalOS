
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
        /// <returns></returns>
        public static Instruction Load(int r1, int r2, int value, uint address, string comment) { return new LoadInstruction(r1, r2, value, address, comment); }

        /// <summary>
        /// Create a Load Instruction
        /// </summary>
        /// <param name="r1">Register 1</param>
        /// <param name="r2">Register 2</param>
        /// <param name="value">Imediate value</param>
        /// <param name="address">Address</param>
        /// <returns></returns>
        public static Instruction Load(int r1, int r2, int value, uint address) { return new LoadInstruction(r1, r2, value, address, string.Empty); }
    
    
    }
}

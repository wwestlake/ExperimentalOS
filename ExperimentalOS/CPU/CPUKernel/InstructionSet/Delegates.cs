
namespace LagDaemon.ExperimentalOS.CPU.CPUKernel.InstructionSet
{
    /// <summary>
    /// Used to connect an instruction to the CPU Kernal code that executes the instruction
    /// </summary>
    /// <param name="instruction">The instruction being executed</param>
    public delegate void ExecuteInstruction(Instruction instruction);
}

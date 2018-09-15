namespace AcceleratedTool.Commands
{
    public interface ICommand
    {
    }

    public interface ICommand<in TCriteria, out TResult> : ICommand
    {
        TResult Execute(TCriteria criteria);
    }

    public interface IWriteCommand<in TCriteria> : ICommand
    {
        void Execute(TCriteria criteria);
    }

    public interface IReadCommand<out TResult> : ICommand
    {
        TResult Execute();
    }
}

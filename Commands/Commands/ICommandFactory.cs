namespace AcceleratedTool.Commands
{
    public interface ICommandFactory
    {
        TCommand Create<TCommand>()
            where TCommand : ICommand;
        void Release<TCommand>(TCommand query)
            where TCommand : ICommand;
    }
}

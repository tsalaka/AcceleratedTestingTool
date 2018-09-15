namespace AcceleratedTool.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandFactory _commandFactory;

        public CommandExecutor(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public TResult Execute<TCriteria, TResult>(TCriteria criteria)
        {
            var command = _commandFactory.Create<ICommand<TCriteria, TResult>>();
            try
            {
                return command.Execute(criteria);
            }
            finally
            {
                _commandFactory.Release(command);
            }
        }

        public void Execute<TCriteria>(TCriteria criteria)
        {
            var command = _commandFactory.Create<IWriteCommand<TCriteria>>();
            try
            {
                command.Execute(criteria);
            }
            finally
            {
                _commandFactory.Release(command);
            }
        }

        public TResult Execute<TResult>()
        {
            var command = _commandFactory.Create<IReadCommand<TResult>>();
            try
            {
                return command.Execute();
            }
            finally
            {
                _commandFactory.Release(command);
            }
        }
    }
}

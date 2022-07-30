using System.Linq.Expressions;

namespace CommandPattern;

public class Account
{
    public int Balance { get; set; }

    public void Process(Command command)
    {
        switch (command.TheAction)
        {
            case Command.Action.Withdraw:
                if (command.Amount <= Balance)
                {
                    command.Success = true;
                    Balance -= command.Amount;
                }
                else
                {
                    command.Success = false;
                }
                break;
            case Command.Action.Deposit:
                if (command.Amount > 0)
                {
                    Balance += command.Amount;
                    command.Success = true;
                }
                else
                {
                    command.Success = false;
                }
                break;
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
}
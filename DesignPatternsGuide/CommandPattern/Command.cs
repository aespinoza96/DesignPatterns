namespace CommandPattern;

public class Command
{
    public enum Action
    {
        Deposit,
        Withdraw
    }
    
    public Action TheAction { get; set; }
    public int Amount { get; set; }
    public bool Success { get; set; }
}
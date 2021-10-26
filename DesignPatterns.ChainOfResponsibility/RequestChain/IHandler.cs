namespace DesignPatterns.ChainOfResponsibility.RequestChain
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        string Handle(string request);
    }
}

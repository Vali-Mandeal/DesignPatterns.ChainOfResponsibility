using DesignPatterns.ChainOfResponsibility.Helpers;

namespace DesignPatterns.ChainOfResponsibility.RequestChain.ConcreteHandlers
{
    // Last Handle in the Chain.
    // It will not call any further Handler.
    public class DatabaseHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (RandomGenerator.NextBoolean())
                return request + "\n - value not found in Database";

            return request + "\n - found in Database";
        }
    }
}

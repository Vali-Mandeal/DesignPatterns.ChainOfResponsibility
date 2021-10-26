using DesignPatterns.ChainOfResponsibility.Helpers;

namespace DesignPatterns.ChainOfResponsibility.RequestChain.ConcreteHandlers
{
    public class ValidationHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (RandomGenerator.NextBoolean())
                return request + "\n - failed Validation";


            request += "\n - passed Validation";
            return base.Handle(request);
        }
    }
}

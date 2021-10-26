using DesignPatterns.ChainOfResponsibility.Helpers;

namespace DesignPatterns.ChainOfResponsibility.RequestChain.ConcreteHandlers
{
    // First Handle in the Chain for Secure Requests
    public class AuthenticationHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (RandomGenerator.NextBoolean())
                return request + "\n - failed Authentication";


            request += "\n - passed Authentication";
            return base.Handle(request);
        }
    }
}

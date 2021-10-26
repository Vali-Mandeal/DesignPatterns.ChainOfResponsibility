using DesignPatterns.ChainOfResponsibility.Helpers;

namespace DesignPatterns.ChainOfResponsibility.RequestChain.ConcreteHandlers
{
    public class AuthorizationHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (RandomGenerator.NextBoolean())
                return request + "\n - failed Authorization";


            request += "\n - passed Authorization";
            return base.Handle(request);
        }
    }
}

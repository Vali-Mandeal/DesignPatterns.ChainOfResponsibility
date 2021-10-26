using DesignPatterns.ChainOfResponsibility.Helpers;

namespace DesignPatterns.ChainOfResponsibility.RequestChain.ConcreteHandlers
{
    // First Handle in the Chain for Insecure Requests
    public class CacheHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (RandomGenerator.NextBoolean())
            {
                request += "\n - value found in Cache";
                return request;
            }


            request += "\n - value not found in Cache";
            return base.Handle(request);
        }
    }
}

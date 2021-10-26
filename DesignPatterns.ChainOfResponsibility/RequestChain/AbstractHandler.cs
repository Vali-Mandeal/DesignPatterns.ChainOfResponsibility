namespace DesignPatterns.ChainOfResponsibility.RequestChain
{
    // The default chaining behavior can be implemented inside a base handler
    // class.
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;

            // Returning a handler from here will let us link handlers in a
            // convenient way like this:
            // authentication.SetNext(authorization).SetNext(dog);
            return handler;
        }

        public virtual string Handle(string request)
        {
            if (_nextHandler is null)
            {
                return null;
            }
            else
            {
                return _nextHandler.Handle(request);
            }
        }
    }
}

using System;
using DesignPatterns.ChainOfResponsibility.Helpers;
using DesignPatterns.ChainOfResponsibility.RequestChain;
using DesignPatterns.ChainOfResponsibility.RequestChain.ConcreteHandlers;

namespace DesignPatterns.ChainOfResponsibility
{
    // Chain for Secure Requests is: Authentication -> Authorization -> Validation -> Cache -> Database
    // Chain for Insecure Requests is: Cache -> Database
    class Program
    {
        private static AuthenticationHandler _authentication;
        private static AuthorizationHandler _authorization;
        private static ValidationHandler _validation;
        private static CacheHandler _cache;
        private static DatabaseHandler _database;

        static void Main()
        {
            InitDependencies();

            var userChoice = GetUserChoice();

            switch (userChoice)
            {
                case 1:
                    SetInsecureChain();
                    HandleResilientRequest(_cache, "Insecure Request");
                    break;
                case 2:
                    SetSecureChain();
                    HandleResilientRequest(_authentication, "Secure Request");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        private static void InitDependencies()
        {
            _authentication = new AuthenticationHandler();
            _authorization = new AuthorizationHandler();
            _validation = new ValidationHandler();
            _cache = new CacheHandler();
            _database = new DatabaseHandler();
        }

        private static int GetUserChoice()
        {
            Console.WriteLine(PredefinedMessages.InitialMessage);

            return Convert.ToInt32(Console.ReadLine());
        }

        private static void SetInsecureChain()
        {
            _cache.SetNext(_database);
        }

        private static void SetSecureChain()
        {
            _authentication
                .SetNext(_authorization)
                .SetNext(_validation)
                .SetNext(_cache)
                .SetNext(_database);
        }

        private static void HandleResilientRequest(IHandler handler, string message)
        {
            var retryCounter = 0;
            while (true)
            {
                var status = handler.Handle(message);
                retryCounter++;

                Console.WriteLine(status);
                Console.WriteLine($" => retries: {retryCounter}\n\n");

                if (IsRequestCompleted(status))
                    return;
            }
        }
            
        // This is for simplicity
        // We consider a request finished, when a value was found in Cache
        // Or when it finishes Database stage (that means either found ot not found)
        private static bool IsRequestCompleted(string status)
        {
            const string foundInCache = "value found in Cache";
            const string database = "Database";

            return status.Contains(foundInCache) || status.Contains(database);
        }
    }
}   

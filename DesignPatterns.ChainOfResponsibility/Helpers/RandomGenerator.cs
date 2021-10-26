using System;

namespace DesignPatterns.ChainOfResponsibility.Helpers
{
    public class RandomGenerator
    {
        public static bool NextBoolean()
        {
            var random = new Random();
            return random.Next(2) == 1;
        }
    }
}
    
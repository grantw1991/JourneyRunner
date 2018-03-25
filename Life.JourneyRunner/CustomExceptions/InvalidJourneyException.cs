using System;

namespace Life.JourneyRunner.CustomExceptions
{
    public class InvalidJourneyException : Exception
    {
        public InvalidJourneyException(string message)
            : base(message) { }
    }
}

using System;

namespace BeagleStreet.JourneyRunner.CustomExceptions
{
    public class InvalidJourneyException : Exception
    {
        public InvalidJourneyException(string message)
            : base(message) { }
    }
}

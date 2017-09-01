using System;

namespace BeagleStreet.Net.JourneyRunner.CustomExceptions
{
    public class InvalidJourneyException : Exception
    {
        public InvalidJourneyException(string message)
            : base(message) { }
    }
}

using System;

namespace BeagleStreet.Net.JourneyRunner.CustomExceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message)
            : base(message) { }
    }
}

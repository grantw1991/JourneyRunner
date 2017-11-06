using System;

namespace BeagleStreet.JourneyRunner.CustomExceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message)
            : base(message) { }
    }
}

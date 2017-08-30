using System;

namespace BeagleStreet.Net.JourneyRunner
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message)
            : base(message) { }
    }
}

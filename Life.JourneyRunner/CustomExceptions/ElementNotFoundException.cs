using System;

namespace Life.JourneyRunner.CustomExceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message)
            : base(message) { }
    }
}

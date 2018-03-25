using Life.JourneyRunner.CustomExceptions;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner
{
    public class JourneyValidator
    {
        public bool IsJourneyValid(Journey journey)
        {
            if(journey == null)
                throw new InvalidJourneyException("Invalid!!!!!");

            

            return true;
        }
    }
}

using Life.JourneyRunner.CustomExceptions;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

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

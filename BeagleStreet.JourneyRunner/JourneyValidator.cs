using BeagleStreet.JourneyRunner.CustomExceptions;
using BeagleStreet.JourneyRunner.Models;

namespace BeagleStreet.JourneyRunner
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
